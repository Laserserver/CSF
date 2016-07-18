using System;

namespace QPro {
    internal static class ParserHelper {
        public static string ParseProtocolVersion(string HttpProtocol) {
            if (HttpProtocol.StartsWith("HTTP/") == false) {
                throw new HttpProtocolBroken("Unrecognized HTTP version '" + HttpProtocol);
            }
            string version = HttpProtocol.Substring(5);
            if (version.IndexOf('.') < 0 || char.IsDigit(version[0]) == false) {
                throw new HttpProtocolBroken("Invalid HTTP version '" + HttpProtocol);
            }
            return version;
        }
    }

    /// <summary>
    ///     Container for a HTTP request line,
    ///     i.e. the first line of a HTTP request
    /// </summary>
    public class HttpRequestLine {
        private readonly char[] sp = {
            ' '
        };

        private string method;
        private string protocol_version;
        private string uri;

        internal HttpRequestLine(SocketState hs) {
            string line;
            do {
                line = hs.ReadAsciiLine().Trim();
            } while (line.Length == 0);

            string[] items = line.Split(sp, StringSplitOptions.RemoveEmptyEntries);

            if (items.Length != 3) {
                throw new HttpProtocolBroken("Unrecognized request line '" + line + "'");
            }

            RequestLine = line;
            Method = items[0];
            URI = items[1];
            URL = items[1];
            ProtocolVersion = ParserHelper.ParseProtocolVersion(items[2]);
        }

        /// <summary>
        ///     HTTP method (e.g. "GET", "POST", etc.)
        /// </summary>
        /// <remarks>
        ///     This field contains what has been received on the socket, and
        ///     therefore can contain anything, including methods not mentioned
        ///     in the HTTP protocol.
        ///     Method is case-sensitive (RFC 2616, section 5.1.1).
        /// </remarks>
        public string Method {
            get {
                return method;
            }
            set {
                method = value;
                UpdateRequestLine();
            }
        }

        /// <summary>
        ///     The version of the HTTP protocol.
        /// </summary>
        /// <remarks>
        ///     For example, "1.1" means "HTTP/1.1"
        /// </remarks>
        public string ProtocolVersion {
            get {
                return protocol_version;
            }
            set {
                protocol_version = value;
                UpdateRequestLine();
            }
        }

        /// <summary>
        ///     Target URI as seen in the TCP stream
        /// </summary>
        public string URI {
            get {
                return uri;
            }
            set {
                uri = value;
                UpdateRequestLine();
            }
        }

        public string URL { get; set; }

        /// <summary>
        ///     Original request line as seen in the TCP stream
        /// </summary>
        public string RequestLine { get; protected set; }

        internal void SendTo(SocketState hs) {
            hs.WriteAsciiLine(RequestLine);
        }

        /// <summary>
        ///     Return a string representation of the instance
        /// </summary>
        public override string ToString() {
            return RequestLine;
        }

        private void UpdateRequestLine() {
            RequestLine = Method + " " + URI + " HTTP/" + ProtocolVersion;
        }
    }
}