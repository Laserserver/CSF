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
    int N = 0;
    int M = 0;
    public FuncProc7()
    {
      InitializeComponent();
    }

    private void btnMaker_Click(object sender, EventArgs e)
    {
      if (int.TryParse(txbNIn.Text, out N) && int.TryParse(txbMIn.Text, out M))
      {
        dgv.RowCount = N;
        dgv.ColumnCount = M;
        for (var i = 0; i < dgv.ColumnCount; i++)
          dgv.Columns[i].Width = 30;
        lblAnswer.Text = "Ответ:";
      }
      else
      {
        lblAnswer.Text = "В поля параметров создания матрицы введены некорректные данные.";
      }
    }
    private void btnFinder_Click(object sender, EventArgs e)
    {
      if (dgv.RowCount != 0 && dgv.RowCount != 0)
      {
        bool flag = true;
        int[,] Matrix = new int[N, M];
        for (int k = 0; k < Matrix.GetLength(0) && flag; k++)
          for (int l = 0; l < Matrix.GetLength(1); l++)
            if (!int.TryParse(Convert.ToString(dgv.Rows[k].Cells[l].Value), out Matrix[k, l]))
            {
              flag = false;
              break;
            }
        if (flag)
          lblAnswer.Text = "Ответ: Элемент, найденный по заданным условиям равен " + Finder.Number(Matrix, radbtnMaxInMin.Checked, radbtnRow.Checked) + ".";
        else
          lblAnswer.Text = "В матрицу введён нечисловой элемент или остались пустые ячейки.";
      }
      else
        lblAnswer.Text = "Не была создана матрица.";
    }
    private void btnDelete_Click(object sender, EventArgs e)
    {
      dgv.Rows.Clear();
    }
    private void btnRes_Click(object sender, EventArgs e)
    {
      dgv.RowCount = 0;
      dgv.ColumnCount = 0;
      dgv.RowCount = N;
      dgv.ColumnCount = M;
      lblAnswer.Text = "Ответ:";
    }
  }
}
