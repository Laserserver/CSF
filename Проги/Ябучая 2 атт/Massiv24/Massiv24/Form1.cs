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
    public Form1()
    {
      InitializeComponent();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (int.TryParse(txbIn.Text, out Numbers[Numbers.Length - 1]))
      {
        txbIn.Text = null;
        txbVis.Text += Numbers[Numbers.Length - 1].ToString() + " ";
        Array.Resize(ref Numbers, Numbers.Length + 1);
      }
    }

    private void btnRes_Click(object sender, EventArgs e)
    {
      int[] NewArr = Numbers;
      Array.Resize(ref NewArr, NewArr.Length - 1);
      int M = 0;
      if (NewArr.Length != 0)
        lblAns.Text = "Элемент - " + Finder.Result(NewArr, out M) + Environment.NewLine + "Индекс элемента - " + M;
      else
        lblAns.Text = "Не введены элементы.";
    }

    private void btnClean_Click(object sender, EventArgs e)
    {
      txbVis.Text = null;
      Numbers = new int[1];
      lblAns.Text = null;
    }
  }
}
