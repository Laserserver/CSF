using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _19_6
{
    static class Program
    {
        public static LoTVMainForm formMain;
        public static LoTVHelpForm formTools;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formMain = new LoTVMainForm();
            formTools = new LoTVHelpForm();
            formTools.Show();
            Application.Run(new LoTVMainForm());
        }
    }
}
