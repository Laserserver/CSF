using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _15_6
{
  public partial class LoTV : Form
  {
    ListLogicClass MyList;

    public LoTV()
    {
      InitializeComponent();
      ctrlDGVIn.ColumnCount = 1;
      ctrlDGVIn.Columns[0].Width = 30;
    }

    private void ctrlBaton_Click(object sender, EventArgs e)
    {
      MyList = new ListLogicClass();
      try
      {
        for (int i = ctrlDGVIn.RowCount - 2; i >= 0; i--)
        {
          MyList.AddToList(double.Parse(Convert.ToString(ctrlDGVIn.Rows[i].Cells[0].Value)));
        }
        switch (Answer.Go(MyList))
        {
          case 1:
            MessageBox.Show("Возрастает");
            break;
          case 2:
            MessageBox.Show("Убывает");
            break;
          case 3:
            MessageBox.Show("Ни возрастает, ни убывает");
            break;
        }
      }
      catch
      {
        MessageBox.Show("Неправильные числа", "Ошибка");
      }
    }
  }
}
