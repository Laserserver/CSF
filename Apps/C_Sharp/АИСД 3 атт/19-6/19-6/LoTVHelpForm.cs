using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _19_6
{
  public partial class LoTVHelpForm : Form
  {
    public LoTVHelpForm()
    {
      InitializeComponent();
    }

    private void LoTVHelpForm_Load(object sender, EventArgs e)
    {
      int w = Screen.PrimaryScreen.Bounds.Width;
      Location = new Point(w - this.Width, 30);
    }

    private void _ctrlRad1_CheckedChanged(object sender, EventArgs e)
    {
      LoTVMainForm.flTools = Convert.ToByte((sender as RadioButton).Tag);
    }
  }
}
