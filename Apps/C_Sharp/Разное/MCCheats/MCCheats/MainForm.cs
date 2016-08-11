using System;
using System.Drawing;
using System.Windows.Forms;

namespace MCCheats
{
  public partial class MainForm : Form
  {
    MouseEventArgs TempE;
    public MainForm()
    {
      InitializeComponent();
    }

    private void _ctrlBtnClear_Click(object sender, EventArgs e)
    {
      _ctrlBaton.Location = new Point(500,500);
    }

    private void _ctrlPanel_MouseMove(object sender, MouseEventArgs e)
    {
      int Vector = (int)(Math.Sqrt((e.X - _ctrlBaton.Location.X) * (e.X - _ctrlBaton.Location.X) + (e.Y - _ctrlBaton.Location.Y) * (e.Y - _ctrlBaton.Location.Y)));
      if (Vector < 100)
      {
        int DeltaX = TempE.X - e.X;
        int DeltaY = TempE.Y - e.Y;
        _ctrlBaton.Location = new Point(_ctrlBaton.Location.X - DeltaX, _ctrlBaton.Location.Y - DeltaY);
      }
      TempE = e;
    }
  }
}
