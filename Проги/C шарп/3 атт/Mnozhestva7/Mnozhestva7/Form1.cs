using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mnozhestva7
{
  public partial class Form1 : Form
  {
   // public const HashSet<int> Not = new HashSet<int>();
    const int ij = 0;
    Helper X1 = new Helper(2, 4, 6, 8, 10);
    Helper X2 = new Helper(1, 2, 3, 4, 5);
    Helper X3 = new Helper(2, 3, 5, 7, 8);
    public Form1()
    {      
      InitializeComponent();
    }
    private void FirstOut()
    {
      dgvIn.RowCount = 5;
      dgvIn.ColumnCount = 3;
      for (int i = 0; i < 3; i++)
        dgvIn.Columns[i].Width = 30;
      int l = 0;
      foreach (int i in X1.New)
      {
        dgvIn.Rows[l].Cells[0].Value = i;
        l++;
      }
      l = 0;
      foreach (int i in X2.New)
      {
        dgvIn.Rows[l].Cells[1].Value = i;
        l++;
      }
      l = 0;
      foreach (int i in X3.New)
      {
        dgvIn.Rows[l].Cells[2].Value = i;
        l++;
      }    
    }
    private void SecondOut()
    {
      int l = 0;
      HashSet<int> Y = Helper.Func(X1.New, X2.New, X3.New);
      dgvOut.RowCount = Y.Count;
      foreach (int i in Y)
      {
        dgvOut.Rows[l].Cells[0].Value = i;
        l++;
      }
      dgvOut.Columns[0].Width = 30;
      lblAns.Text = "Ответ: " + Y.Count;
    }
    private void btnFind_Click(object sender, EventArgs e)
    {
      FirstOut();
      SecondOut();
    }
  }
}
