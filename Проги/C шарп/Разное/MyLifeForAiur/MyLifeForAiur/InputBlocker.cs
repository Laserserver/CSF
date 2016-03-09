using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MyLifeForAiur
{
  static class InputBlocker
  {
    [DllImport("user32.dll")]
    static extern bool BlockInput(bool fBlockIt);

    private static Timer _timer = new Timer();

    static InputBlocker()
    {
      _timer.Tick += new EventHandler(_timer_Tick);
    }

    private static void _timer_Tick(object sender, EventArgs e)
    {
      BlockInput(false);
      _timer.Stop();
    }

    public static void BlockInput(int ms)
    {
      BlockInput(true);
      _timer.Interval = ms;
      _timer.Start();
    }
  }
}
