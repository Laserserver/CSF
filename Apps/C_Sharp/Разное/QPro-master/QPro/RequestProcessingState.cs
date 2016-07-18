namespace QPro {
    /// <summary>
    ///     Continuation delegate used in the request processing pipeline
    /// </summary>
    public delegate void ProcessingStep();

    /// <summary>
    ///     Maintains the internal state for the request currently being
    ///     processed
    /// </summary>
    public class RequestProcessingState {
        /// <summary>
        ///     Points to the next processing step; must be updated after
        ///     each processing step, setting it to null will stop the
        ///     processing
        /// </summary>
        public ProcessingStep NextStep;

        /// <summary>
        ///     When set to not null, will be called every time a raw fragment
        ///     of a non-empty response message body is received; note that the
        ///     packet handler becomes responsible for sending the response
        ///     (whatever it is) to BrowserSocket
        /// </summary>
        /// <remarks>
        ///     The message body might be compressed (or otherwise modified),
        ///     as specified by the Content-Encoding header. Applications
        ///     should use <c>ProxyLogic.GetResponseMessageStream</c> to
        ///     decompress (whenever necessary) the message stream.
        /// </remarks>
        public SocketState.MessagePacketHandler OnResponseMessagePacket;

        /// <summary>
        ///     Whether the BrowserSocket connection should be kept alive after handling
        ///     the current request, or closed
        /// </summary>
        public bool PersistConnectionBrowserSocket;

        /// <summary>
        ///     Whether the RemoteSocket connection should be kept alive after handling
        ///     the current request, or closed
        /// </summary>
        /// <remarks>
        ///     If set to false, then <c>PersistConnectionBrowserSocket</c> will also be
        ///     set to false, because if no Content-Length has been specified,
        ///     the browser would keep on waiting (BrowserSocket kept-alive, but RemoteSocket
        ///     closed).
        /// </remarks>
        public bool PersistConnectionRemoteSocket;

        /// <summary>
        ///     Whether the request contains a message
        /// </summary>
        public bool RequestHasMessage;

        /// <summary>
        ///     Whether the request message (if any) is being transmitted
        ///     in chunks
        /// </summary>
        public bool RequestMessageChunked;

        /// <summary>
        ///     Length of the request message, if any
        /// </summary>
        public uint RequestMessageLength;

        /// <summary>
        ///     Set to true if no instruction was given in the request headers
        ///     about whether the BrowserSocket connection should persist
        /// </summary>
        public bool UseDefaultPersistBrowserSocket;

        /// <summary>
        ///     Processing state constructor
        /// </summary>
        /// <param name="StartStep">
        ///     First step of the request processing pipeline
        /// </param>
        public RequestProcessingState(ProcessingStep StartStep) {
            NextStep = StartStep;
        }
    };
}