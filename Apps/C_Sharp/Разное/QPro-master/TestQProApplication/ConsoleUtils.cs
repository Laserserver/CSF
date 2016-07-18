using System.Runtime.InteropServices;

namespace TestQProApplication {
    public enum CtrlTypes : uint {
        CTRL_C_EVENT = 0,
        CTRL_BREAK_EVENT = 1,
        CTRL_CLOSE_EVENT = 2,
        CTRL_LOGOFF_EVENT = 5,
        CTRL_SHUTDOWN_EVENT = 6,
    }

    public static class ConsoleUtils {
        /// <summary>
        ///     Делегат обработки системных событий консоли
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public delegate bool ConsoleHandlerRoutine(CtrlTypes type);

        /// <summary>
        ///     Adds or removes an application-defined HandlerRoutine function from the list of handler functions for the calling process.
        /// </summary>
        /// <param name="handler">A pointer to the application-defined HandlerRoutine function to be added or removed. This parameter can be NULL.</param>
        /// <param name="add">If this parameter is TRUE, the handler is added; if it is FALSE, the handler is removed.</param>
        /// <returns>If the function succeeds, the return value is nonzero</returns>
        [DllImport("kernel32.dll")]
        internal static extern bool SetConsoleCtrlHandler(ConsoleHandlerRoutine handler, bool add);
    }
}
