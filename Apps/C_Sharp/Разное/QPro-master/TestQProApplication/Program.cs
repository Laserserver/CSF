using System;
using QPro;
using QPro.Rules;

namespace TestQProApplication {
    class Program {
        private static bool aborted;
        private static ConsoleUtils.ConsoleHandlerRoutine consoleHandlerRoutine;

        private static QProxy proxy;

        static void Main(string[] args) {
            InitializeConsoleHandlerRoutine();

            InitializeProxy();

            Console.WriteLine("Server started");
            Console.WriteLine("To exit press CTRL+C");
            proxy.Start();

            while (aborted == false) {
                var keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.G) {
                    try {
                        var rule = proxy.Rules[1];
                        var items = proxy.GetItemsFromCacheByRule(rule);
                        foreach (var qItemCach in items) {
                            if (qItemCach.Response != null) {
                                Console.WriteLine("{0}", qItemCach.Response);
                                Console.WriteLine("\n");
                                // proxy.RemoveItemFromCache(qItemCach.Key);
                            }
                        }
                    }
                    catch (Exception e) {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        private static void InitializeConsoleHandlerRoutine() {
            consoleHandlerRoutine = ConsoleHandlerRoutine;
            ConsoleUtils.SetConsoleCtrlHandler(consoleHandlerRoutine, true);
        }

        private static void InitializeProxy() {
            proxy = new QProxy();

            var rule = new QRegexRule(@"http://w1.dwar.ru/hunt_conf.php");
            rule.Behavior = QBehavior.Skip;
            rule.IsStoreResponse = true;
            proxy.AddRule(rule);

            // +.dwar*.ru/esrv*/* -> .*.dwar.*.ru/esrv.*/.*$
            var chatRule = new QRegexRule(@".*.dwar.*.ru/esrv.*/.*$");
            chatRule.Behavior = QBehavior.Skip;
            chatRule.IsStoreResponse = true;
            chatRule.IsAllStoreResponse = true;
            proxy.AddRule(chatRule);
        }

        private static bool ConsoleHandlerRoutine(CtrlTypes type) {
            switch (type) {
                case CtrlTypes.CTRL_C_EVENT:
                case CtrlTypes.CTRL_BREAK_EVENT:
                case CtrlTypes.CTRL_CLOSE_EVENT:
                case CtrlTypes.CTRL_LOGOFF_EVENT:
                case CtrlTypes.CTRL_SHUTDOWN_EVENT:
                    StoppingProxy();
                    break;
            }
            return true;
        }

        private static void StoppingProxy() {
            proxy.Stop();

            ConsoleUtils.SetConsoleCtrlHandler(consoleHandlerRoutine, false);
            Console.WriteLine("Server stopped");

            Console.WriteLine("Press any key to continue exit");

            aborted = true;
        }
    }
}
