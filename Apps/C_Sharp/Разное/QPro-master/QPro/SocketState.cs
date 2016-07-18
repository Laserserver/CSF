using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace QPro {
    /// <summary>
    ///     Communication state between two hosts
    /// </summary>
    public class SocketState : IDisposable {
        /// <summary>
        ///     Socket-level event handler for HTTP message packets
        /// </summary>
        /// <param name="packet">
        ///     Buffer containing the message packet, or null if there is
        ///     no more packets in the current message
        /// </param>
        /// <param name="offset">
        ///     Start offset of the packet in the buffer
        /// </param>
        /// <param name="nb_bytes">
        ///     Fragment size in bytes, or 0 if there is no more packets
        /// </param>
        /// <remarks>
        ///     Messages are fragmented because of the limited buffer size, or
        ///     whenever the remote server is sending the message using the
        ///     chunked transfer encoding.
        /// </remarks>
        public delegate void MessagePacketHandler(byte[] packet, uint offset, uint nb_bytes);

        /// <summary>
        ///     Socket UID.
        /// </summary>
        public Guid guid;

        private bool keepAlive;

        /// <summary>
        ///     Wrap a Socket instance into a HttpSocket instance
        /// </summary>
        public SocketState(Socket socket) {
            LowLevelSocket = socket;

            SocketBuffer = new byte[BufferSize];
            sb = new StringBuilder(128);
        }

        /// <summary>
        ///     Set the TCP Keep Alive option on the socket
        /// </summary>
        public bool KeepAlive {
            get {
                return keepAlive;
            }
            set {
                if (keepAlive != value) {
                    LowLevelSocket.SetSocketOption(SocketOptionLevel.Socket,
                                                   SocketOptionName.KeepAlive, value);
                    keepAlive = value;
                }
            }
        }

        /// <summary>
        ///     Close the wrapped socket
        /// </summary>
        public void Dispose() {
            if (LowLevelSocket != null) {
                LowLevelSocket.Close();
                // Note: Socket.Close() just calls Socket.Dispose()
                LowLevelSocket = null;
            }
        }

        #region I/O level 1: plain C# socket interface
        /// <summary>
        ///     Returns the wrapped socket
        /// </summary>
        protected Socket LowLevelSocket = null;

        /// <summary>
        ///     Close the internal socket
        /// </summary>
        public void CloseSocket() {
            if (LowLevelSocket == null) {
                return;
            }
            try {
                LowLevelSocket.Shutdown(SocketShutdown.Both);
            }
            catch {
                /* ignore */
            }

            try {
                LowLevelSocket.Close();
            }
            catch {
                /* ignore */
            }
            LowLevelSocket = null;
        }

        /// <summary>
        ///     Returns true if the socket has been closed, or has become
        ///     unresponsive
        /// </summary>
        public bool IsSocketDead( /*bool bTestSend*/) {
            if (LowLevelSocket == null) {
                return true;
            }
            if (LowLevelSocket.Connected == false) {
                return true;
            }

            // XXX NOT TESTED
            /*
                        // Trick: one way to see if a socket is still valid is
                        // to try and write zero byte to it.
                        if (bTestSend)
                        try
                        {
                            int save = LowLevelSocket.SendTimeout;
                            LowLevelSocket.SendTimeout = 1;
                            LowLevelSocket.Send(Buffer, 0, SocketFlags.None);
                            LowLevelSocket.SendTimeout = save;
                        }
                        catch { return true; }
             */
            return false;
        }
        #endregion

        #region I/O level 2: Buffered line-based and raw I/O
        private const uint BufferSize = 8192;

        private static readonly byte[] b_CRLF = {
            0x0d, 0x0a
        };

        private static readonly char[] c_ChunkSizeEnd = {
            ' ', ';'
        };

        private readonly StringBuilder sb;
        private uint BufferPosition;

        public List<byte[]> Response;

        /// <summary>
        ///     True if ReadAsciiLine may have loaded bytes in the buffer
        ///     that ReadRaw should use
        /// </summary>
        private bool UseLeftOverBytes;

        // 8192 seems to be the default buffer size for the Socket object

        /// <summary>
        ///     How many bytes of data are available in the receive buffer
        ///     (starting at offset 0)
        /// </summary>
        protected uint AvailableData { get; private set; }

        /// <summary>
        ///     Receive buffer
        /// </summary>
        public byte[] SocketBuffer { get; protected set; }

        /// <summary>
        ///     Reads a LF-delimited (or CRLF-delimited) line from the socket,
        ///     and returns it (without the trailing newline character)
        /// </summary>
        /// Content is expected to be in ASCII 8-bit (UTF-8 also works).
        public string ReadAsciiLine() {
            sb.Length = 0;
            bool bHadCR = false;
            while (true) {
                if (AvailableData == 0) {
                    if (ReadRaw() == 0) {
                        // Connection closed while we were waiting for data
                        throw new IoBroken();
                    }
                    UseLeftOverBytes = true;
                }

                // Newlines in HTTP headers are expected to be CRLF.
                // However, for better robustness, RFC 2616 recommends
                // ignoring CR, and considering LF as new lines (section 19.3)
                byte b = SocketBuffer[BufferPosition++];
                AvailableData--;

                if (b == '\n') {
                    break;
                }
                if (bHadCR) {
                    sb.Append('\r');
                }
                if (b == '\r') {
                    bHadCR = true;
                } else {
                    bHadCR = false;
                    var c = (char)b;
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        ///     Read buffered binary data
        /// </summary>
        /// <remarks>
        ///     A read operation (for instance, ReadAsciiLine) may have loaded
        ///     the buffer with some data which ended up not being used.
        ///     If that's the case, then ReadBinary uses it (ReadRaw does not).
        /// </remarks>
        public uint ReadBinary() {
            bool bLeftOver = UseLeftOverBytes;
            UseLeftOverBytes = false;
            if (bLeftOver && AvailableData > 0) {
                if (BufferPosition != 0) {
                    // Move the unread bytes at the beginning of the buffer.
                    // Note that Array.Copy knows how to handle overlaps
                    // correctly, i.e. it's a memmove, not a memcpy.
                    Array.Copy(SocketBuffer, BufferPosition, SocketBuffer, 0, AvailableData);
                }
                uint r = AvailableData;
                AvailableData = 0;
                BufferPosition = 0;
                return r;
            }
            return ReadRaw();
        }

        /// <summary>
        ///     Read a block of data from the socket; unread data that was in the
        ///     buffer is dropped
        /// </summary>
        /// <remarks>
        ///     BufferPosition is reset. If there were unread data in the buffer,
        ///     it's lost.
        /// </remarks>
        protected uint ReadRaw() {
            int r = LowLevelSocket.Receive(SocketBuffer);
            // Notes:
            // - if we are using non-infinite timeouts (not true from
            //  TrotiNet.Test), timeouts would be signalled by thrown
            //  SocketException's.
            // - if we were using non-blocking sockets with no data
            //  available, then again a SocketException would be thrown.
            // So if Receive() returns 0, it really means the connection
            // has been closed.

            Debug.Assert(r >= 0);
            // Note: r = 0 means connection closed

            AvailableData = (uint)r;
            BufferPosition = 0;
            return AvailableData;
        }

        /// <summary>
        ///     Transfer data from this socket to the destination socket
        ///     until this socket closes
        /// </summary>
        /// <returns>The number of bytes sent</returns>
        public uint TunnelDataTo(SocketState dest) {
            uint total_sent = 0;

            try {
                if (AvailableData == 0) {
                    ReadRaw();
                }
                while (AvailableData > 0) {
                    uint sent = dest.WriteBinary(SocketBuffer, BufferPosition, AvailableData);
                    if (sent < AvailableData) {
                        throw new IoBroken();
                    }
                    total_sent += sent;
                    ReadRaw();
                }
            }
            catch (SocketException) {
                /* ignore */
            }

            return total_sent;
        }

        /// <summary>
        ///     Transfer data from the socket to the specified packet handler
        ///     until the socket closes
        /// </summary>
        /// <returns>The number of bytes sent</returns>
        public uint TunnelDataTo(MessagePacketHandler mph) {
            uint total_sent = 0;

            try {
                if (AvailableData == 0) {
                    ReadRaw();
                }
                Response = new List<byte[]>();
                var i = 0;
                while (AvailableData > 0) {
                    mph(SocketBuffer, BufferPosition, AvailableData);
                    var buffer = new byte[AvailableData];
                    Array.Copy(SocketBuffer, (int)BufferPosition, buffer, 0, AvailableData);
                    Response.Add(buffer);
                    i++;
                    total_sent += AvailableData;
                    ReadRaw();
                }
            }
            catch (SocketException) {
                /* ignore */
            }

            return total_sent;
        }

        /// <summary>
        ///     Read <c>nb_bytes</c> bytes from the socket,
        ///     and send it to the destination socket
        /// </summary>
        /// <returns>The number of bytes sent</returns>
        public uint TunnelDataTo(SocketState dest, uint nb_bytes) {
            return TunnelDataTo((b, o, s) => {
                                    if (dest.WriteBinary(b, o, s) < s) {
                                        throw new IoBroken();
                                    }
                                }, nb_bytes);
        }

        /// <summary>
        ///     Read <c>nb_bytes</c> bytes from the socket,
        ///     and send it to the specified packet handler
        /// </summary>
        /// <returns>The number of bytes sent</returns>
        public uint TunnelDataTo(MessagePacketHandler mph, uint nb_bytes) {
            uint total_sent = 0;
            Response = new List<byte[]>();
            while (nb_bytes > 0) {
                if (AvailableData == 0) {
                    if (ReadRaw() == 0) {
                        throw new IoBroken();
                    }
                }
                uint to_send = AvailableData;
                if (to_send > nb_bytes) {
                    UseLeftOverBytes = true;
                    to_send = nb_bytes;
                }
                mph(SocketBuffer, BufferPosition, to_send);
                var buf = new byte[to_send];
                Array.Copy(SocketBuffer, BufferPosition, buf, 0, to_send);
                Response.Add(buf);
                total_sent += to_send;
                nb_bytes -= to_send;
                AvailableData -= to_send;
                BufferPosition += to_send;
            }

            return total_sent;
        }

        /// <summary>
        ///     Sends a buffer to the specified packet handler
        /// </summary>
        /// <returns>The number of bytes sent</returns>
        public uint TunnelDataTo(MessagePacketHandler mph, byte[] buffer) {
            mph(buffer, 0, (uint)buffer.Length);
            return (uint)buffer.Length;
        }

        /// <summary>
        ///     Fills the buffer with an unknown amount of data from the socket
        /// </summary>
        /// <param name="buffer">data from the socket</param>
        /// <returns>total bytes</returns>
        public uint TunnelDataTo(ref byte[] buffer) {
            uint total_sent = 0;
            const uint byte_count = 512;

            if (buffer == null) {
                buffer = new byte[byte_count];
            }

            while (true) {
                if (AvailableData == 0) {
                    if (ReadRaw() == 0) {
                        break;
                    }
                }

                uint to_send = AvailableData;
                UseLeftOverBytes = true;

                if (total_sent + AvailableData > buffer.Length) {
                    Array.Resize(ref buffer, (int)(total_sent + AvailableData) * 2);
                }

                Buffer.BlockCopy(SocketBuffer, (int)BufferPosition, buffer, (int)total_sent, (int)to_send);

                total_sent += to_send;
                AvailableData -= to_send;
                BufferPosition += to_send;
            }

            var file_data = new byte[total_sent];
            Buffer.BlockCopy(buffer, 0, file_data, 0, (int)total_sent);
            buffer = file_data;

            return total_sent;
        }

        /// <summary>
        ///     Write data from a buffer to the socket
        /// </summary>
        public uint TunnelDataTo(byte[] buffer, uint byte_count) {
            uint total_sent = 0;
            while (byte_count > 0) {
                if (AvailableData == 0) {
                    if (ReadRaw() == 0) {
                        throw new IoBroken();
                    }
                }
                uint to_send = AvailableData;
                if (to_send > byte_count) {
                    UseLeftOverBytes = true;
                    to_send = byte_count;
                }

                Buffer.BlockCopy(SocketBuffer, (int)BufferPosition, buffer, (int)total_sent, (int)to_send);

                total_sent += to_send;
                byte_count -= to_send;
                AvailableData -= to_send;
                BufferPosition += to_send;
            }

            return total_sent;
        }

        /// <summary>
        ///     Write an ASCII string, a CR character, and a LF character to the
        ///     socket
        /// </summary>
        public uint WriteAsciiLine(string s) {
            uint r = WriteBinary(Encoding.ASCII.GetBytes(s));
            r += WriteBinary(b_CRLF);
            return r;
        }

        /// <summary>
        ///     Write an array of bytes to the socket
        /// </summary>
        public uint WriteBinary(byte[] b) {
            return WriteBinary(b, 0, (uint)b.Length);
        }

        /// <summary>
        ///     Write the first <c>nb_bytes</c> of <c>b</c> to the socket
        /// </summary>
        public uint WriteBinary(byte[] b, uint nb_bytes) {
            return WriteBinary(b, 0, nb_bytes);
        }

        /// <summary>
        ///     Write <c>nb_bytes</c> of <c>b</c>, starting at offset
        ///     <c>offset</c> to the socket
        /// </summary>
        public uint WriteBinary(byte[] b, uint offset, uint nb_bytes) {
            LowLevelSocket.NoDelay = true;
            int r = LowLevelSocket.Send(b, (int)offset, (int)nb_bytes, SocketFlags.None);
            if (r < 0) {
                r = 0;
            }
            return (uint)r;
        }
        #endregion

        #region I/O level 3: HTTP-based I/O
        private void SendHttpError(string ErrorCodeAndReason) {
            string html_body = "<html>\n <body>\n  <h1>" +
                               ErrorCodeAndReason + "</h1>\n </body>\n</html>";

            WriteBinary(Encoding.ASCII.GetBytes(
                "HTTP/1.0 " + ErrorCodeAndReason + "\r\n" +
                "Connection: close\r\n" +
                "Content-Length: " + html_body.Length + "\r\n" +
                "\r\n" + html_body + "\r\n"));
        }

        /// <summary>
        ///     Send a HTTP 302 redirection over the socket
        /// </summary>
        public void Send302() {
            SendHttpError("302 Found");
        }

        /// <summary>
        ///     Send a HTTP 400 error over the socket
        /// </summary>
        public void Send400() {
            SendHttpError("400 Bad Request");
        }

        /// <summary>
        ///     Send a HTTP 403 error over the socket
        /// </summary>
        public void Send403() {
            SendHttpError("403 Forbidden");
        }

        /// <summary>
        ///     Send a HTTP 404 error over the socket
        /// </summary>
        public void Send404() {
            SendHttpError("404 Not Found");
        }

        /// <summary>
        ///     Send a HTTP 501 error over the socket
        /// </summary>
        public void Send501() {
            SendHttpError("501 Not Implemented");
        }

        /// <summary>
        ///     Tunnel a HTTP-chunked blob of data
        /// </summary>
        /// <param name="dest">The destination socket</param>
        /// <remarks>
        ///     The tunneling stops when the last chunk, identified by a
        ///     size of 0, arrives. The optional trailing entities are also
        ///     transmitted (but otherwise ignored).
        /// </remarks>
        public void TunnelChunkedDataTo(SocketState dest) {
            TunnelChunkedDataTo(dest, (buffer, offset, size) => {
                                          if (dest.WriteBinary(buffer, offset, size) < size) {
                                              throw new IoBroken();
                                          }
                                      });
        }

        /// <summary>
        ///     Tunnel a HTTP-chunked blob of data to the specified packet handler
        /// </summary>
        /// <remarks>
        ///     The tunneling stops when the last chunk, identified by a
        ///     size of 0, arrives. The optional trailing entities are also
        ///     transmitted (but otherwise ignored).
        /// </remarks>
        public void TunnelChunkedDataTo(MessagePacketHandler mph) {
            TunnelChunkedDataTo(null, mph);
        }

        /* Helper function */

        private void TunnelChunkedDataTo(SocketState dest, MessagePacketHandler mph) {
            // (RFC 2616, sections 3.6.1, 19.4.6)
            while (true) {
                string chunk_header = ReadAsciiLine();
                if (chunk_header.Length == 0) {
                    throw new HttpProtocolBroken("Expected chunk header missing");
                }
                int sc = chunk_header.IndexOfAny(c_ChunkSizeEnd);
                string hexa_size = sc > -1
                                       ? chunk_header.Substring(0, sc)
                                       : chunk_header;
                uint size;
                try {
                    size = Convert.ToUInt32(hexa_size, 16);
                }
                catch {
                    string s = chunk_header.Length > 20
                                   ? (chunk_header.Substring(0, 17) + "...")
                                   : chunk_header;
                    throw new HttpProtocolBroken(
                        "Could not parse chunk size in: " + s);
                }

                if (dest != null) {
                    dest.WriteAsciiLine(chunk_header);
                }
                if (size == 0) {
                    break;
                }
                TunnelDataTo(mph, size);
                // Read/write one more CRLF
                string new_line = ReadAsciiLine();
                Debug.Assert(new_line.Length == 0);
                if (dest != null) {
                    dest.WriteAsciiLine(new_line);
                }
            }
            string line;
            do {
                // Tunnel any trailing entity headers
                line = ReadAsciiLine();
                if (dest != null) {
                    dest.WriteAsciiLine(line);
                }
            } while (line.Length != 0);
        }
        #endregion
    }
}