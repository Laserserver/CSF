using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace QPro {
    public class QTransfer {
        /// <summary>
        ///     Socket dedicated to the (client) browser-proxy communication
        /// </summary>
        protected SocketState BrowserSocket;

        /// <summary>
        ///     Name of the host to which <c>BrowserSocket</c> is currently
        ///     connected
        /// </summary>
        protected string DestinationHostName;

        /// <summary>
        ///     Port to which <c>BrowserSocket</c> is currently connected
        /// </summary>
        protected int DestinationPort;

        /// <summary>
        ///     Called when RequestLine and RequestHeaders are set
        /// </summary>
        /// <remarks>
        ///     May be used to override State.NextStep
        /// </remarks>
        public Action<TransferItem> OnReceiveRequest;

        /// <summary>
        ///     Called when ResponseStatusLine and ResponseHeaders are set
        /// </summary>
        /// <remarks>
        ///     May be used to override State.NextStep
        /// </remarks>
        public Action<TransferItem> OnReceiveResponse;

        /// <summary>
        ///     Set to a proxy host name if our proxy is not connecting to
        ///     the internet, but to another proxy instead
        /// </summary>
        protected string RelayHttpProxyHost;

        /// <summary>
        ///     Set to a proxy bypass specification if our proxy is not connecting
        ///     to the internet, but to another proxy instead
        /// </summary>
        /// <remarks>
        ///     XXX Bypass not implemented
        /// </remarks>
        protected string RelayHttpProxyOverride;

        /// <summary>
        ///     Set to a proxy port if our proxy is not connecting to
        ///     the internet, but to another proxy instead
        /// </summary>
        protected int RelayHttpProxyPort;

        /// <summary>
        ///     Socket dedicated to the proxy-server (remote) communication
        /// </summary>
        protected SocketState RemoteSocket;

        /// <summary>
        ///     The request headers of the HTTP request currently being handled
        /// </summary>
        protected HttpHeaders RequestHeaders;

        /// <summary>
        ///     The request line of the HTTP request currently being handled
        /// </summary>
        protected HttpRequestLine RequestLine;

        /// <summary>
        ///     The response header line of the HTTP response received
        /// </summary>
        protected HttpHeaders ResponseHeaders;

        /// <summary>
        ///     The response status line of the HTTP response received
        /// </summary>
        protected HttpStatusLine ResponseStatusLine;

        /// <summary>
        ///     Request processing pipeline state
        /// </summary>
        /// <seealso cref="RequestProcessingState" />
        protected RequestProcessingState State;

        public QTransfer(SocketState state) {
            BrowserSocket = state;
            RemoteSocket = null;
        }

        public bool LogicLoop() {
            // In order to enable derived classes to divert the standard
            // HTTP request processing in the most flexible way, the processing
            // is done in a continuation-passing way. That means each step
            // is responsible for updating State.NextStep, as appropriate.

            try {
                State = new RequestProcessingState(ReadRequest);
                while (State.NextStep != null) {
                    State.NextStep();
                }

                return State.PersistConnectionBrowserSocket;
            }
            catch (Exception e) {
                AbortRequest();
                throw;
            }
        }

        /// <summary>
        ///     Interpret a message with respect to its content encoding
        /// </summary>
        protected Stream GetResponseMessageStream(byte[] msg) {
            Stream inS = new MemoryStream(msg);
            return GetResponseMessageStream(inS);
        }

        /// <summary>
        ///     Interpret a message with respect to its content encoding
        /// </summary>
        protected Stream GetResponseMessageStream(Stream inStream) {
            Stream outStream = null;
            string ce = ResponseHeaders.ContentEncoding;
            if (String.IsNullOrEmpty(ce) == false) {
                if (ce.StartsWith("deflate")) {
                    outStream = new DeflateStream(inStream, CompressionMode.Decompress);
                } else {
                    if (ce.StartsWith("gzip")) {
                        outStream = new GZipStream(inStream, CompressionMode.Decompress);
                    } else {
                        if (ce.StartsWith("identity") == false) {
                            throw new RuntimeException("Unsupported Content-Encoding '" + ce + "'");
                        }
                    }
                }
            }

            if (outStream == null) {
                return inStream;
            }
            return outStream;
        }

        /// <summary>
        ///     Compress a byte array based on the content encoding header
        /// </summary>
        /// <param name="output">The content to be compressed</param>
        /// <returns>The compressed content</returns>
        public byte[] CompressResponse(byte[] output) {
            string ce = ResponseHeaders.ContentEncoding;
            if (String.IsNullOrEmpty(ce) == false) {
                if (ce.StartsWith("deflate")) {
                    using (var ms = new MemoryStream()) {
                        using (var ds = new DeflateStream(ms, CompressionMode.Compress, true)) {
                            ds.Write(output, 0, output.Length);
                            ds.Close();
                        }
                        return ms.ToArray();
                    }
                }
                if (ce.StartsWith("gzip")) {
                    using (var ms = new MemoryStream()) {
                        using (var gs = new GZipStream(ms, CompressionMode.Compress, true)) {
                            gs.Write(output, 0, output.Length);
                            gs.Close();
                        }
                        return ms.ToArray();
                    }
                }
                if (ce.StartsWith("identity") == false) {
                    throw new RuntimeException("Unsupported Content-Encoding '" + ce + "'");
                }
            }

            return output;
        }

        /// <summary>
        ///     Get an encoded byte array for a given string
        /// </summary>
        public byte[] EncodeStringResponse(string s, Encoding encoding) {
            byte[] output = encoding.GetBytes(s);
            return CompressResponse(output);
        }

        /// <summary>
        ///     If necessary, connect the remote <c>RemoteSocket</c> socket
        ///     to the given host and port
        /// </summary>
        /// <param name="hostname">Remote host name</param>
        /// <param name="port">Remote port</param>
        /// <remarks>
        ///     If RemoteSocket is already connected to the right host and port,
        ///     the socket is reused as is.
        /// </remarks>
        protected void Connect(string hostname, int port) {
            Debug.Assert(!String.IsNullOrEmpty(hostname));
            Debug.Assert(port > 0);

            if (DestinationHostName != null &&
                DestinationHostName.Equals(hostname) &&
                DestinationPort == port &&
                (RemoteSocket != null && !RemoteSocket.IsSocketDead())) {
                // Nothing to do, just reuse the socket
                return;
            }

            if (RemoteSocket != null) {
                // We have a socket connected to the wrong host (or port)
                RemoteSocket.CloseSocket();
                RemoteSocket = null;
            }

            IPAddress[] ips = Dns.GetHostAddresses(hostname);
            Socket socket = null;
            Exception e = null;
            foreach (var ip in ips) {
                try {
                    socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(ip, port);
                    break;
                }
                catch (Exception ee) {
                    if (ip.Equals(IPAddress.IPv6Loopback)) {
                        // Do not log that
                        continue;
                    }
                    if (e == null) {
                        e = ee;
                    }
                    if (socket != null) {
                        socket.Close();
                        socket = null;
                    }
                }
            }
            if (socket == null) {
                throw e;
            }

            // Checked up, and good to go
            RemoteSocket = new SocketState(socket);
            DestinationHostName = hostname;
            DestinationPort = port;
        }

        /// <summary>
        ///     Pipeline step: read the HTTP request from the client, schedule
        ///     the next step to be <c>SendRequest</c>, and call
        ///     <c>OnReceiveRequest</c>
        /// </summary>
        protected virtual void ReadRequest() {
            try {
                RequestLine = new HttpRequestLine(BrowserSocket);
            }
            catch (IoBroken) {
                // The request line is the first line of a HTTP request.
                // If none comes in a timely fashion, then we eventually
                // get a IoBroken exception, which is common enough
                // not to be rethrown.
                AbortRequest();
                return;
            }
            catch (SocketException) {
                // Ditto
                AbortRequest();
                return;
            }

            RequestHeaders = new HttpHeaders(BrowserSocket);

            if (RequestLine.Method.Equals("CONNECT")) {
                BrowserSocket.Send501();
                AbortRequest();
                return;
            }

            // We call OnReceiveRequest now because Connect() will
            // modify the request URI.
            State.NextStep = SendRequest;

            var item = new TransferItem();
            item.Headers = RequestHeaders;
            item.HttpRequestLine = RequestLine;
            item.BrowserSocket = BrowserSocket;
            item.RemoteSocket = RemoteSocket;
            item.State = State;
            OnReceiveRequest(item);
            RequestLine.URI = item.HttpRequestLine.URL;

            // Now we parse the request to:
            // 1) find out where we should connect
            // 2) find out whether there is a message body in the request
            // 3) find out whether the BrowserSocket connection should be kept-alive
            if (State.NextStep != null) {
                // Step 1)
                if (RelayHttpProxyHost == null) {
                    int NewDestinationPort;
                    string NewDestinationHost = ParseDestinationHostAndPort(RequestLine, RequestHeaders, out NewDestinationPort);
                    Console.WriteLine("Connect to {0}", NewDestinationHost);
                    Connect(NewDestinationHost, NewDestinationPort);
                } else {
                    Connect(RelayHttpProxyHost, RelayHttpProxyPort);
                }

                // Step 2)
                // Find out whether the request has a message body
                // (RFC 2616, section 4.3); if it has, get the message length
                State.RequestHasMessage = false;
                State.RequestMessageLength = 0;
                State.RequestMessageChunked = false;
                if (RequestHeaders.TransferEncoding != null) {
                    State.RequestHasMessage = true;
                    State.RequestMessageChunked = Array.IndexOf(RequestHeaders.TransferEncoding, "chunked") >= 0;
                    Debug.Assert(State.RequestMessageChunked);
                } else if (RequestHeaders.ContentLength != null) {
                    State.RequestMessageLength = (uint)RequestHeaders.ContentLength;

                    // Note: HTTP 1.0 wants "Content-Length: 0" when there
                    // is no entity body. (RFC 1945, section 7.2)
                    if (State.RequestMessageLength > 0) {
                        State.RequestHasMessage = true;
                    }
                }
            }
            // Step 3)
            State.UseDefaultPersistBrowserSocket = true;
            if (RequestHeaders.ProxyConnection != null) {
                // Note: This is not part of the HTTP 1.1 standard. See
                // http://homepage.ntlworld.com./jonathan.deboynepollard/FGA/web-proxy-connection-header.html
                foreach (string i in RequestHeaders.ProxyConnection) {
                    if (i.Equals("close")) {
                        State.PersistConnectionBrowserSocket = false;
                        State.UseDefaultPersistBrowserSocket = false;
                        break;
                    }
                    if (i.Equals("keep-alive")) {
                        State.PersistConnectionBrowserSocket = true;
                        State.UseDefaultPersistBrowserSocket = false;
                        break;
                    }
                }
                if (RelayHttpProxyHost == null) {
                    RequestHeaders.ProxyConnection = null;
                }
            }

            // Note: we do not remove fields mentioned in the
            //  'Connection' header (the specs say we should).
        }

        /// <summary>
        ///     Pipeline step: tunnel the request from the client to the remove
        ///     server, and schedule the next step to be <c>ReadResponse</c>
        /// </summary>
        protected virtual void SendRequest() {
            // Transmit the request to the server
            RequestLine.SendTo(RemoteSocket);
            RequestHeaders.SendTo(RemoteSocket);
            if (State.RequestHasMessage) {
                // Tunnel the request message
                if (State.RequestMessageChunked) {
                    BrowserSocket.TunnelChunkedDataTo(RemoteSocket);
                } else {
                    Debug.Assert(State.RequestMessageLength > 0);
                    BrowserSocket.TunnelDataTo(TunnelRemoteSocket, State.RequestMessageLength);
                }
            }

            State.NextStep = ReadResponse;
        }

        /// <summary>
        ///     Pipeline step: read the HTTP response from the local client,
        ///     schedule the next step to be <c>SendResponse</c>, and call
        ///     <c>OnReceiveResponse</c>
        /// </summary>
        protected virtual void ReadResponse() {
            // Wait until we receive the response, then parse its header
            ResponseStatusLine = new HttpStatusLine(RemoteSocket);
            ResponseHeaders = new HttpHeaders(RemoteSocket);

            // Get PersistConnectionRemoteSocket (RFC 2616, section 14.10)
            bool bUseDefaultPersistPS = true;
            if (ResponseHeaders.Connection != null) {
                foreach (var item in ResponseHeaders.Connection) {
                    if (item.Equals("close")) {
                        State.PersistConnectionRemoteSocket = false;
                        bUseDefaultPersistPS = false;
                        break;
                    }
                    if (item.Equals("keep-alive")) {
                        State.PersistConnectionRemoteSocket = true;
                        bUseDefaultPersistPS = false;
                        break;
                    }
                }
            }
            if (bUseDefaultPersistPS) {
                State.PersistConnectionRemoteSocket = (ResponseStatusLine.ProtocolVersion.Equals("1.0") == false);
            }

            if (State.PersistConnectionRemoteSocket) {
                RemoteSocket.KeepAlive = true;
            } else {
                State.PersistConnectionBrowserSocket = false;
            }

            State.NextStep = SendResponse;
        }

        /// <summary>
        ///     Pipeline: tunnel the HTTP response from the remote server to the
        ///     local client, and end the request processing
        /// </summary>
        protected virtual void SendResponse() {
            if ((ResponseHeaders.TransferEncoding == null && ResponseHeaders.ContentLength == null) == false) {
                // Transmit the response header to the client
                SendResponseStatusAndHeaders();
            }

            // Find out if there is a message body
            // (RFC 2616, section 4.4)
            int sc = ResponseStatusLine.StatusCode;
            if (RequestLine.Method.Equals("HEAD") ||
                sc == 204 || sc == 304 || (sc >= 100 && sc <= 199)) {
                SendResponseStatusAndHeaders();
                CallOnReceiveResponse(ResponseHeaders.ContentEncoding);
                return;
            }

            bool responseMessageChunked = false;
            uint responseMessageLength = 0;
            if (ResponseHeaders.TransferEncoding != null) {
                responseMessageChunked = Array.IndexOf(ResponseHeaders.TransferEncoding, "chunked") >= 0;
                Debug.Assert(responseMessageChunked);
            } else if (ResponseHeaders.ContentLength != null) {
                responseMessageLength = (uint)ResponseHeaders.ContentLength;
                if (responseMessageLength == 0) {
                    CallOnReceiveResponse(ResponseHeaders.ContentEncoding);
                    return;
                }
            } else {
                // We really should have been given a response
                // length. It appears that some popular websites
                // send small files without a transfer-encoding
                // or length.

                // It seems that all of the browsers handle this
                // case so we need to as well.

                var buffer = new byte[512];
                RemoteSocket.TunnelDataTo(ref buffer);

                // Transmit the response header to the client
                ResponseHeaders.ContentLength = (uint)buffer.Length;
                ResponseStatusLine.SendTo(BrowserSocket);
                ResponseHeaders.SendTo(BrowserSocket);

                BrowserSocket.TunnelDataTo(TunnelBrowserSocket, buffer);
                State.NextStep = null;
                return;
            }

            if (State.OnResponseMessagePacket != null) {
                if (State.PersistConnectionRemoteSocket == false) {
                    // Pipeline until the connection is closed
                    RemoteSocket.TunnelDataTo(State.OnResponseMessagePacket);
                } else {
                    if (responseMessageChunked) {
                        RemoteSocket.TunnelChunkedDataTo(State.OnResponseMessagePacket);
                    } else {
                        RemoteSocket.TunnelDataTo(State.OnResponseMessagePacket, responseMessageLength);
                    }
                }
                State.OnResponseMessagePacket(null, 0, 0);
            } else {
                if (State.PersistConnectionRemoteSocket == false) {
                    // Pipeline until the connection is closed
                    RemoteSocket.TunnelDataTo(TunnelBrowserSocket);
                } else {
                    if (responseMessageChunked) {
                        RemoteSocket.TunnelChunkedDataTo(BrowserSocket);
                    } else {
                        RemoteSocket.TunnelDataTo(TunnelBrowserSocket, responseMessageLength);
                    }
                }
            }

            CallOnReceiveResponse(ResponseHeaders.ContentEncoding);
        }

        private void CallOnReceiveResponse(string responseMessageChunked) {
            var transferItem = new TransferItem();
            transferItem.Headers = ResponseHeaders;
            transferItem.HttpRequestLine = RequestLine;
            transferItem.ResponseStatusLine = ResponseStatusLine;
            transferItem.BrowserSocket = BrowserSocket;
            transferItem.RemoteSocket = RemoteSocket;
            transferItem.State = State;
            transferItem.Response = GetResponse(responseMessageChunked);
            OnReceiveResponse(transferItem);

            if (State.PersistConnectionRemoteSocket == false && RemoteSocket != null) {
                RemoteSocket.CloseSocket();
                RemoteSocket = null;
            }

            State.NextStep = null;
        }

        /// <summary>
        ///     Send the response status line and headers from the proxy to
        ///     the client
        /// </summary>
        protected void SendResponseStatusAndHeaders() {
            ResponseStatusLine.SendTo(BrowserSocket);
            ResponseHeaders.SendTo(BrowserSocket);
        }

        /// <summary>
        ///     Message packet handler for tunneling data from RemoteSocket to BrowserSocket
        /// </summary>
        protected void TunnelBrowserSocket(byte[] msg, uint position, uint to_send) {
            if (to_send == 0) {
                return;
            }
            if (BrowserSocket.WriteBinary(msg, position, to_send) < to_send) {
                throw new IoBroken();
            }
        }

        /// <summary>
        ///     Message packet handler for tunneling data from BrowserSocket to RemoteSocket
        /// </summary>
        protected void TunnelRemoteSocket(byte[] msg, uint position, uint to_send) {
            if (to_send == 0) {
                return;
            }
            if (RemoteSocket.WriteBinary(msg, position, to_send) < to_send) {
                throw new IoBroken();
            }
        }

        /// <summary>
        ///     Extract the host and port to use from either the HTTP request
        ///     line, or the HTTP headers; update the request line to remove
        ///     the hostname and port
        /// </summary>
        /// <param name="hrl">
        ///     The HTTP request line; the URI will be updated to remove the
        ///     host name and port number
        /// </param>
        /// <param name="hh_rq">The HTTP request headers</param>
        /// <param name="port">
        ///     When this method returns, contains the request port
        /// </param>
        /// <remarks>
        ///     May modify the URI of <c>hrl</c>
        /// </remarks>
        protected string ParseDestinationHostAndPort(HttpRequestLine hrl, HttpHeaders hh_rq, out int port) {
            string host = null;
            bool bIsConnect = hrl.Method.Equals("CONNECT");
            port = bIsConnect ? 443 : 80;

            bool bIsHTTP1_0 = hrl.ProtocolVersion.Equals("1.0");
            if (hrl.URI.Equals("*")) {
                Debug.Assert(!bIsHTTP1_0);
                goto hostname_from_header;
            }

            // At this point, hrl.URI follows one of these forms:
            // - scheme:(//authority)/abs_path
            // - authority
            // - /abs_path

            int prefix = 0; // current parse position
            if (hrl.URI.Contains("://")) {
                if (hrl.URI.StartsWith("http://")) {
                    prefix = 7; // length of "http://"
                } else {
                    if (hrl.URI.StartsWith("https://")) {
                        prefix = 8; // length of "https://"
                        port = 443;
                    } else {
                        throw new HttpProtocolBroken("Expected scheme missing or unsupported");
                    }
                }
            }

            // Starting from offset prefix, we now have either:
            // 1) authority (only for CONNECT)
            // 2) authority/abs_path
            // 3) /abs_path

            int slash = hrl.URI.IndexOf('/', prefix);
            string authority = null;
            if (slash == -1) {
                // case 1
                authority = hrl.URI;
                Debug.Assert(bIsConnect);
            } else {
                if (slash > 0) {
                    // Strict inequality
                    // case 2
                    authority = hrl.URI.Substring(prefix, slash - prefix);
                }
            }
            if (authority != null) {
                // authority is either:
                // a) hostname
                // b) hostname:
                // c) hostname:port

                int c = authority.IndexOf(':');
                if (c < 0) {
                    // case a)
                    host = authority;
                } else if (c == authority.Length - 1) {
                    // case b)
                    host = authority.TrimEnd('/');
                } else {
                    // case c)
                    host = authority.Substring(0, c);
                    port = int.Parse(authority.Substring(c + 1));
                }

                prefix += authority.Length;
            }

            if (host != null) {
#if false
    // XXX Not sure whether this can happen (without doing ad
    // replacement) or if we want to prevent it
                if (hh_rq.Host != null)
                {
                    // Does hh_rq.Host and host match? (disregarding
                    // the potential ":port" prefix of hh_rq.Host)
                    int c2 = hh_rq.Host.IndexOf(':');
                    string rq_host = c2 < 0 ? hh_rq.Host :
                        hh_rq.Host.Substring(0, c2);
                    if (!rq_host.Equals(host))
                        // Host discrepancy: fix the 'Host' header
                        hh_rq.Host = host;
                }
#endif

                // Remove the host from the request URI, unless the "server"
                // is actually a proxy, in which case the URI should remain
                // unchanged. (RFC 2616, section 5.1.2)
                if (RelayHttpProxyHost == null) {
                    hrl.URI = hrl.URI.Substring(prefix);
                }

                return host;
            }

            hostname_from_header:
            host = hh_rq.Host;
            if (host == null) {
                throw new HttpProtocolBroken("No host specified");
            }
            int cp = host.IndexOf(':');
            if (cp < 0) {
                /* nothing */
            } else if (cp == host.Length - 1) {
                host = host.TrimEnd('/');
            } else {
                host = host.Substring(0, cp);
                port = int.Parse(host.Substring(cp + 1));
            }
            return host;
        }

        private string GetResponse(string responseMessageChunked) {
            if (RemoteSocket.Response == null) {
                return "";
            }

            var str = new StringBuilder();

            var bytes = new byte[0];
            foreach (byte[] byteb in RemoteSocket.Response) {
                int oldIndex = bytes.Length;
                Array.Resize(ref bytes, oldIndex + byteb.Length);
                Array.Copy(byteb, 0, bytes, oldIndex, byteb.Length);
            }

            var nb = new byte[] {};
            var strResponse = Encoding.UTF8.GetString(bytes);

            int size = 0;
            if (strResponse.IndexOf("\r\n") == 4) {
                //var strSize = strResponse.Substring(0, 4);
                //size = Convert.ToInt32(strSize, 16);
                //nb = new byte[bytes.Length - 14];
                Array.Copy(bytes, 6, nb, 0, nb.Length);
            } else {
                nb = new byte[bytes.Length];
                Array.Copy(bytes, nb, nb.Length);
            }

            if (responseMessageChunked != null) {
                if (responseMessageChunked.StartsWith("gzip") || responseMessageChunked.StartsWith("deflate")) {
                    var b2 = new byte[] {};
                    try {
                        using (var stream = GetResponseMessageStream(nb)) {
                            using (var memoryBuffer = new MemoryStream()) {
                                stream.CopyTo(memoryBuffer);
                                b2 = memoryBuffer.ToArray();
                                memoryBuffer.Close();
                            }
                            stream.Close();
                        }
                    }
                    catch (Exception e) {
                        int t = 0;
                    }
                    str.Append(Encoding.UTF8.GetString(b2));
                    return str.ToString();
                }
            }
            str.Append(Encoding.UTF8.GetString(nb));
            return str.ToString();
        }

        /// <summary>
        ///     Pipeline step: close the connections and stop
        /// </summary>
        protected void AbortRequest() {
            if (RemoteSocket != null) {
                RemoteSocket.CloseSocket();
                RemoteSocket = null;
            }
            State.PersistConnectionBrowserSocket = false;
            State.NextStep = null;
        }
    }
}