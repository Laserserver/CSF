using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProcFunc26
{
  public partial class ProcFunc26 : Form
  {
    int N = 0;
    int M = 0;
    public ProcFunc26()
    {
      InitializeComponent();
    }
    private void btnFind_Click(object sender, EventArgs e)
    {
      if (dgvIn.ColumnCount != 0)
      {
        bool flag = true;
        int[,] Matrix = new int[N, M];
        for (int k = 0; k < N && flag; k++)
          for (int l = 0; l < M; l++)
            if (!int.TryParse(Convert.ToString(dgvIn.Rows[k].Cells[l].Value), out Matrix[k, l]))
            {
              MessageBox.Show("В матрицу введён нечисловой элемент или остались пустые ячейки.", "Ошибка значений");
              flag = false;
              break;
            }
        if (flag)
        {
          int[,]  ResultMatrix = Helper.Delete(Matrix, radbtnRow.Checked, radbtnMin.Checked);
          dgvOut.RowCount = ResultMatrix.GetLength(0);
          dgvOut.ColumnCount = ResultMatrix.GetLength(1);
          for (int i = 0; i < dgvOut.ColumnCount; i++)
            dgvOut.Columns[i].Width = 30;
          for (int k = 0; k < dgvOut.RowCount; k++)
            for (int l = 0; l < dgvOut.ColumnCount; l++)
              dgvOut.Rows[k].Cells[l].Value = ResultMatrix[k,l];
        }
      }
      else
        MessageBox.Show("Не была создана матрица.", "Ошибка матрицы");
    }
    private void btnDel_Click(object sender, EventArgs e)
    {
      dgvIn.ColumnCount = 0;
    }
    private void btnMak_Click(object sender, EventArgs e)
    {
      if (int.TryParse(Convert.ToString(txbN.Text), out N) && int.TryParse(Convert.ToString(txbM.Text), out M))
      {
        dgvIn.RowCount = N;
        dgvIn.ColumnCount = M;
        for (int i = 0; i < M; i++)
          dgvIn.Columns[i].Width = 30;
      }
      else
        MessageBox.Show("В окно ввода введен некорректный символ.", "Ошибка ввода");
    }
  }
}
