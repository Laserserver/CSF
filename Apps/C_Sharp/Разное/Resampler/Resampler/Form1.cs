using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resampler
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void _ctrlBaton_Click(object sender, EventArgs e)
    {
      _ctrlLblOutX.Text = "X: " + Logics.SetX(int.Parse(_ctrlTxbInX.Text));
      _ctrlLblOutY.Text = "Y: " + Logics.SetY(int.Parse(_ctrlTxbInY.Text));
    }
  }
}
