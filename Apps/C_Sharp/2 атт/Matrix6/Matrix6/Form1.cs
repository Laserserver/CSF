using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Matrix6
{
  public partial class Matrix6 : Form
  {
    int N = 0;
    int M = 0;
    public Matrix6()
    {
      InitializeComponent();
    }

    private void btnMake_Click(object sender, EventArgs e)
    {
      if (int.TryParse(txbN.Text, out N) && int.TryParse(txbM.Text, out M))
      {
        dgvIn.ColumnCount = M;
        dgvIn.RowCount = N;
        for (int i = 0; i < M; i++)
          dgvIn.Columns[i].Width = 30;
      }
      else
        MessageBox.Show("В поля создания матрицы введены некорректные символы.", "Ошибка ввода");
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
      dgvIn.ColumnCount = 0;
      dgvOut.ColumnCount = 0;
    }

    private void btnGet_Click(object sender, EventArgs e)
    {
      if (dgvIn.ColumnCount != 0)
      {
        int[,] Matrix = new int[N, M];
        bool flag = true;
        for (int i = 0; i < N && flag; i++)
          for (int k = 0; k < M; k++)
            if (!int.TryParse(Convert.ToString(dgvIn.Rows[i].Cells[k].Value), out Matrix[i, k]))
            {
              flag = false;
              MessageBox.Show("В матрицу введены некорректные символы.", "Ошибка значений");
              break;
            }
        if (flag)
        {
          double[,] NewMatrix = Cranker.Deriver(Matrix);
          dgvOut.ColumnCount = M;
          dgvOut.RowCount = N;
          for (int i = 0; i < N; i++)
            for (int k = 0; k < M; k++)
              dgvOut.Rows[i].Cells[k].Value = NewMatrix[i, k];
        }
      }
      else
        MessageBox.Show("Не была создана матрица.", "Ошибка матрицы");
    }
  }
}
