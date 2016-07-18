using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ThreadState = System.Threading.ThreadState;

namespace QPro {
    public class QServer {
        private readonly ManualResetEvent listenThreadSwitch;
        private readonly bool useIPv6;

        /// <summary>
        ///     Set of open sockets, indexed by socket identifier
        /// </summary>
        protected Dictionary<Guid, SocketState> ConnectedSockets;

        /// <summary>
        ///     Port used for local browser-proxy communication
        /// </summary>
        protected IPEndPoint EndPoint;

        private Socket ListeningSocket;

        public Action<TransferItem> OnReceiveRequest;
        public Action<TransferItem> OnReceiveResponse;

        /// <summary>
        ///     Timer that calls CheckSockets regularly
        /// </summary>
        private Timer cleanTimer;

        /// <summary>
        ///     Incremented at every client connection
        /// </summary>
        private int lastClientId;

        private Thread listeningThread;

        public QServer(bool useIPv6) {
            this.useIPv6 = useIPv6;

            ConnectedSockets = new Dictionary<Guid, SocketState>();
            InitListenFinished = new ManualResetEvent(false);
            listenThreadSwitch = new ManualResetEvent(false);
            listeningThread = null;
        }

        /// <summary>
        ///     Set to true if the server is about to shut down
        /// </summary>
        protected bool IsShuttingDown { get; private set; }

        /// <summary>
        ///     If not null, specify which address the listening socket should
        ///     be bound to. If null, it will default to the loopback address.
        /// </summary>
        public IPAddress BindAddress { get; set; }

        /// <summary>
        ///     Set if an error has occured while the server was initializing
        ///     the listening thread
        /// </summary>
        public Exception InitListenException { get; protected set; }

        /// <summary>
        ///     Set when the listening thread has finished its initialization
        ///     (either successfully, or an exception has been thrown)
        /// </summary>
        /// <seealso cref="InitListenException" />
        /// <seealso cref="IsListening" />
        public ManualResetEvent InitListenFinished { get; protected set; }

        /// <summary>
        ///     Set to true if the listening thread is currently listening
        ///     for incoming connections
        /// </summary>
        public bool IsListening { get; protected set; }

        public IPEndPoint Start() {
            ListeningSocket = null;
            InitListenException = null;
            InitListenFinished.Reset();
            IsListening = false;
            IsShuttingDown = false;

            listeningThread = new Thread(StartThread) {
                Name = "ListenTCP",
                IsBackground = true
            };
            listeningThread.Start();

            const int cleanTimeout = 300 * 1000; // in ms
            cleanTimer = new Timer(CheckSockets, null, cleanTimeout, cleanTimeout);

            InitListenFinished.WaitOne();
            EndPoint = (IPEndPoint)ListeningSocket.LocalEndPoint;
            return EndPoint;
        }

        public void Stop() {
            if (listeningThread == null) {
                return;
            }

            IsShuttingDown = true;

            listenThreadSwitch.Set();

            cleanTimer.Dispose();
            cleanTimer = null;

            if (listeningThread.IsAlive) {
                // Create a connection to the port to unblock the
                // listener thread
                using (var sock = new Socket(AddressFamily.Unspecified, SocketType.Stream, ProtocolType.Tcp)) {
                    try {
                        sock.Connect(EndPoint);
                        sock.Close();
                    }
                    catch {
                        /* ignore */
                    }
                }

                if (listeningThread.ThreadState == ThreadState.WaitSleepJoin) {
                    listeningThread.Interrupt();
                }
                Thread.Sleep(1000);
                listeningThread.Abort();
            }

            listeningThread = null;
            IsListening = false;
        }

        private void StartThread() {
            try {
                StartListening(ref ListeningSocket);
            }
            catch (Exception e) {
                IsListening = false;
                InitListenException = e;
                InitListenFinished.Set();
                listenThreadSwitch.Set();
            }
            finally {
                if (ListeningSocket != null) {
                    ListeningSocket.Close();
                }
            }
        }

        private void StartListening(ref Socket ListeningSocket) {
            // Note: Do not catch exceptions until we reach the main
            // listening loop, because <c>StartThread</c> should
            // intercept initialization exceptions.

            // Establish the local endpoint for the socket (only on localhost)
            IPAddress lb = BindAddress ?? (useIPv6 ? IPAddress.IPv6Loopback : IPAddress.Loopback);

            // Create a TCP/IP socket
            AddressFamily af = useIPv6
                                   ? AddressFamily.InterNetworkV6
                                   : AddressFamily.InterNetwork;

            ListeningSocket = new Socket(af, SocketType.Stream, ProtocolType.Tcp);
            var endPoint = new IPEndPoint(IPAddress.Loopback, 0);

            // Bind the socket to the local endpoint and listen for incoming
            // connections.
            ListeningSocket.Bind(endPoint);
            ListeningSocket.Listen(1000);

            // Notify that the listening thread is up and running
            IsListening = true;
            InitListenFinished.Set();

            // Main listening loop starts now
            try {
                while (IsShuttingDown == false) {
                    listenThreadSwitch.Reset();
                    if (IsShuttingDown) {
                        break;
                    }

                    ListeningSocket.BeginAccept(AcceptCallback, ListeningSocket);

                    // Wait until a connection is made before continuing
                    listenThreadSwitch.WaitOne();
                }
            }
            catch (Exception e) {}
            finally {}
        }

        /// <summary>
        ///     Callback method for accepting new connections
        /// </summary>
        private void AcceptCallback(IAsyncResult ar) {
            if (listeningThread.ManagedThreadId == Thread.CurrentThread.ManagedThreadId) {
                new Thread(() => AcceptCallback(ar)).Start();
                return;
            }

            if (IsShuttingDown) {
                return;
            }

            // Get the socket that handles the client request
            var listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Signal the main thread to continue
            listenThreadSwitch.Set();

            // Create the state object
            var state = new SocketState(handler);
            state.guid = Guid.NewGuid();

            lock (ConnectedSockets) {
                ConnectedSockets[state.guid] = state;
            }

            QTransfer transfer = null;
            try {
                transfer = new QTransfer(state);
                transfer.OnReceiveRequest = OnReceiveRequest;
                transfer.OnReceiveResponse = OnReceiveResponse;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            if (transfer == null) {
                CloseSocket(state);
                return;
            }

            // No need for asynchronous I/O from now on
            try {
                while (transfer.LogicLoop()) {
                    if (IsShuttingDown || state.IsSocketDead()) {
                        break;
                    }
                }
            }
            catch (SocketException) {
                /* ignore */
            }
            catch (IoBroken) {
                /* ignore */
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine("Closing socket on error");
            }

            CloseSocket(state);
        }

        /// <summary>
        ///     Close broken sockets
        /// </summary>
        /// <remarks>
        ///     This function is called regularly to clean up the list of
        ///     connected sockets.
        /// </remarks>
        private void CheckSockets(object eventState) {
            try {
                lock (ConnectedSockets) {
                    foreach (var kv in ConnectedSockets) {
                        try {
                            Guid id = kv.Key;
                            SocketState state = kv.Value;
                            if (state == null || state.IsSocketDead()) {
                                ConnectedSockets.Remove(id);
                            }
                        }
                        catch (Exception e) {}
                    }
                }
            }
            catch {}
        }

        /// <summary>
        ///     Remove the socket contained in the given state object
        ///     from the connected array list and hash table, then close the
        ///     socket
        /// </summary>
        protected virtual void CloseSocket(SocketState state) {
            lock (ConnectedSockets) {
                SocketState actual_state;
                if (ConnectedSockets.TryGetValue(state.guid, out actual_state) == false) {
                    return;
                }

                Debug.Assert(actual_state == state);
                ConnectedSockets.Remove(state.guid);
            }

            state.CloseSocket();
        }
    }
}