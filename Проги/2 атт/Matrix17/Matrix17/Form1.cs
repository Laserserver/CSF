using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Matrix17
{
  public partial class Matrix17 : Form
  {
    int N = 1;

    public Matrix17()
    {
      InitializeComponent();
    }
    private void btnMake_Click(object sender, EventArgs e)
    {

      if (!int.TryParse(Convert.ToString(txbIn.Text), out N))
        MessageBox.Show("В окне ввода некорректный символ.", "Ошибка ввода");
      else
      {
        dgv.RowCount = N;
        dgv.ColumnCount = N;
        for (int i = 0; i < N; i++)
          dgv.Columns[i].Width = 30;
      }
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
      dgv.ColumnCount = 0;
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
      bool flag = true;
      if (dgv.ColumnCount != 0)
      {
        int[,] Arr = new int[N, N];
        for (int k = 0; k < Arr.GetLength(0) && flag; k++)
            for (int l = 0; l < Arr.GetLength(1); l++)
              if (!int.TryParse(Convert.ToString(dgv.Rows[k].Cells[l].Value), out Arr[k, l]))
              {
                MessageBox.Show("В матрицу введен некорректный символ или остались пустые ячейки.", "Ошибка значений");
                flag = false;
                break;
              }
        if (flag)
          lblOut.Text = Convert.ToString(Helper.Finder(Arr));
      }
      else
        MessageBox.Show("Не была создана матрица.", "Ошибка матрицы");
    }
  }
}
