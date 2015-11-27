using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _7_21
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      dataIn.ColumnCount = 1;
      dataOut.ColumnCount = 1;
    }

    private void butMake_Click(object sender, EventArgs e)
    {
      int[] Arr = new int[dataIn.RowCount - 1];
      for (int i = 0; i < dataIn.RowCount - 1; i++)
        if (!int.TryParse(Convert.ToString(dataIn.Rows[i].Cells[0].Value), out Arr[i]))
          MessageBox.Show("Вы пытаетесь ввести неверные знаки.");
      Arr = Returner.Change(Arr);
      for (int i = 0; i < Arr.Length; i++)
      {
        dataOut.RowCount = dataIn.RowCount;
        dataOut.Rows[i].Cells[0].Value = Arr[i];
      }
    }
  }
}
