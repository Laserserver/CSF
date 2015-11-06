using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stroka24
{
  public partial class MainFormStroka24 : Form
  {
    public MainFormStroka24()
    {
      InitializeComponent();
    }

    private void buttonWordFinder_Click(object sender, EventArgs e)
    {
      string Answer = null;
      txbOut.Text = (Thinker.Finder(txbIn.Text, txbSymb.Text, out Answer) ? Answer : Answer);
    }
  }
}
