using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FuncProc24
{
  public partial class FP24 : Form
  {
    int N = 0;
    int M = 0;
    public FP24()
    {
      InitializeComponent();
    }

    private void btnMaker_Click(object sender, EventArgs e)
    {
      if (int.TryParse(txbN.Text, out N) && int.TryParse(txbM.Text, out M))
      {
        dgv.RowCount = N;
        dgv.ColumnCount = M;
        for (int i = 0; i < M; i++)
          dgv.Columns[i].Width = 30;
      }
      else
        MessageBox.Show("В поля параметров создания матрицы введены некорректные данные.", "Ошибка");
    }

    private void btnFinder_Click(object sender, EventArgs e)
    {
      if (dgv.RowCount != 0 && dgv.RowCount != 0)
      {
        bool flag = true;
        int[,] Matrix = new int[N, M];
        for (int k = 0; k < N && flag; k++)
            for (int l = 0; l < M; l++)
              if (!int.TryParse(Convert.ToString(dgv.Rows[k].Cells[l].Value), out Matrix[k, l]))
              {
                flag = false;
                break;
              }
        if (flag)
        {
          Matrix = Changer.Change(Matrix, radbtnFirst.Checked, radbtnToFirst.Checked);
          dgv2.RowCount = N;
          dgv2.ColumnCount = M;
          for (int i = 0; i < M; i++)
            dgv2.Columns[i].Width = 30;
          for (int k = 0; k < N; k++)
            for (int l = 0; l < M; l++)
              dgv2.Rows[k].Cells[l].Value = Matrix[k, l];
        }
        else
          MessageBox.Show("В матрицу введён нечисловой элемент или остались пустые ячейки.", "Ошибка");
      }
      else
        MessageBox.Show("Не была создана матрица.", "Ошибка");
    }

    private void btnRes_Click(object sender, EventArgs e)
    {
      dgv.ColumnCount = 0;
      dgv.ColumnCount = M;
      dgv.RowCount = N;
      for (int i = 0; i < M; i++)
        dgv.Columns[i].Width = 30;
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
      dgv.Rows.Clear();
    }
  }
}
