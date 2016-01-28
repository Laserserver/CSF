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
  public partial class Aiur : Form
  {
    public Aiur()
    {
      InitializeComponent();
      gridMass.ColumnCount = 1;
      gridMass.Columns[0].Width = 30;
    }

    private void baton_Click(object sender, EventArgs e)
    {
      int[] Mass = new int[gridMass.RowCount - 1];
      int Temp = 0;
      for (int i = 0; i < gridMass.RowCount - 1; i++)
        if (int.TryParse(Convert.ToString(gridMass.Rows[i].Cells[0].Value), out Temp))
        Mass[i] = Temp;
      lblMin.Text = Convert.ToString(Find.Finder(Mass, out Temp));
      lblInd.Text = Convert.ToString(Temp);
    }
  }
}
