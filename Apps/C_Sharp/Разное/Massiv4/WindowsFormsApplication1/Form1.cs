using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  public partial class MyForm : Form
  {
    public MyForm()
    {
      InitializeComponent();
      dataIn.RowCount = 1;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      int[] Arr = new int [dataIn.RowCount - 1];
      for (int i = 0; i < dataIn.RowCount - 1; i++)
        if (!int.TryParse(Convert.ToString(dataIn.Rows[i].Cells[0].Value), out Arr[i]))
          MessageBox.Show("В массив введены некорректные символы.");
      Arr = Help.Find(Arr);
      for (int i = 0; i < Arr.Length; i++)
      {
        dataOut.RowCount = Arr.Length;
        dataOut.Rows[i].Cells[0].Value = Arr[i];
      }
    }
  }
}
