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
  public partial class StrMainForm : Form
  {
    public StrMainForm()
    {
      InitializeComponent();
      dgv.ColumnCount = 1;
    }
    private void btnRes_Click(object sender, EventArgs e)
    {
      int[] NewArr = new int [dgv.RowCount - 1];
      for (int i = 0; i < dgv.RowCount - 1; i++)
        int.TryParse(Convert.ToString(dgv.Rows[i].Cells[0].Value), out NewArr[i]);     
      int M = 0;
      if (NewArr.Length > 0)
        lblAns.Text = "Элемент - " + Finder.Result(NewArr, out M) + Environment.NewLine + "Индекс элемента - " + M;
      else
        lblAns.Text = "Не введены элементы.";
    }
    private void btnClean_Click(object sender, EventArgs e)
    {
      dgv.RowCount = 1;
      lblAns.Text = null;
    }
  }
}
