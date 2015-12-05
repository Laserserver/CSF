using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Massiv7
{
  public partial class frmMass7 : Form
  {
    public frmMass7()
    {
      InitializeComponent();
      //gv.RowCount = 1;
      gv.ColumnCount = 1;
    }
    public void btnTorf_Click(object sender, EventArgs e)
    {
      int[] Numbers = new int[gv.RowCount - 1];      
      for (int i = 0; i < gv.RowCount - 1; i++)
      {
        Numbers[i] = Convert.ToInt32(gv.Rows[i].Cells[0].Value);
      }
      bool t = T_finder.TFinder(Numbers);
      lblAns.Text = "Ответ: " + t.ToString();
    }
  }
}

