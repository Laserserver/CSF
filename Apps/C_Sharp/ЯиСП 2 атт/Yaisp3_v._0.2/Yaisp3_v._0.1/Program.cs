using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Yaisp3_v._0._1
{
  static class Program
  {
    public static _FormAgency formCreateAgency;
    public static _FormMain formMain;
    public static _FormCity formCity;
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      formMain = new _FormMain();
      formCreateAgency = new _FormAgency();
      formCity = new _FormCity();
      Application.Run(formMain);
    }
  }
}
