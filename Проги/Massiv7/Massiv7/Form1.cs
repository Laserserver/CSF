using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Massiv7
{
  public partial class frmMass7 : Form
  {
    int[] Numbers = new int[1];
    int i = 0;

    public frmMass7()
    {
      InitializeComponent();
    }
    private void btnAddEl_Click(object sender, EventArgs e)
    {
      int.TryParse(txbNumIn.Text, out Numbers[i]);
      txbNumIn.Text = null;
      txbVisArr.Text += Numbers[i].ToString() + " ";
      i++;
      Array.Resize(ref Numbers, i + 1);
    }

    private void btnTorf_Click(object sender, EventArgs e)
    {
      bool t;
      T_finder.TFinder(Numbers, out t);
      lblAns.Text = (t ? "Ответ: " + t : "Ответ: " + t);
    }

    private void btnClean_Click(object sender, EventArgs e)
    {
      txbVisArr.Text = null;
      Array.Resize(ref Numbers, 1);
      i = 0;
      lblAns.Text = "Ответ:";
    }
  }
}

