using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Massiv24
{
  public partial class Form1 : Form
  {
    int[] Numbers = new int[1];
    int i = 0;
    public Form1()
    {
      InitializeComponent();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      int.TryParse(txbIn.Text, out Numbers[i]);
      txbIn.Text = null;
      txbVis.Text += Numbers[i].ToString() + " ";
      i++;
      Array.Resize(ref Numbers, i + 1);
    }

    private void btnRes_Click(object sender, EventArgs e)
    {
      int MN = 0, M = 0;
      Finder.Result(Numbers, out M, out MN);
      lblAns.Text = "Макс. - " + M + " Номер - " + MN;
    }

    private void btnClean_Click(object sender, EventArgs e)
    {
      txbVis.Text = null;
      Array.Resize(ref Numbers, 1);
      i = 0;
      lblAns.Text = null;
    }
  }
}
