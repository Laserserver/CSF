namespace QPro {
    public struct TransferItem {
        public SocketState BrowserSocket;
        public HttpHeaders Headers;

        public HttpRequestLine HttpRequestLine;

        public SocketState RemoteSocket;
        public HttpStatusLine ResponseStatusLine;
        public RequestProcessingState State;

        public string Response { get; set; }
    }
}