using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProcFunc7
{
  public partial class FuncProc7 : Form
  {
    public FuncProc7()
    {
      InitializeComponent();
    }

    private void btnFinder_Click(object sender, EventArgs e)
    {
      Random rnd = new Random(100);
      int N = 0;
      int M = 0;
      int.TryParse(txbNIn.Text, out N);
      int.TryParse(txbMIn.Text, out M);
      int[,] Matrix = new int[N, M];  //N строк, М столбцов

      for (int k = 0; k < Matrix.GetLength(0); k++)
      {
        for (int l = 0; l < Matrix.GetLength(1); l++)
        {
          txbOutVis.Text += Matrix[k, l] + " ";
        }
        txbOutVis.Text += "\n";
      }
      lblAnswer.Text = "Элемент, найденный по заданным условиям равен " + Finder.Number(N, M) + ".";
      for (int i = 0; i < Matrix.GetLength(0); i++)
      {
        for (int j = 0; j < Matrix.GetLength(1); j++)
        {
          txbOutVis.Text += Matrix[i, j] + " ";
        }
        txbOutVis.Text += "\n";
      }
    }
  }
}
