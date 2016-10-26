using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Morphing
{
    static class Program
    {
        public static FormMain formMain;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formMain = new FormMain();
            Application.Run(formMain);
        }
    }
}
