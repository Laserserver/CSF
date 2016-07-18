using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spisky4
{
  public partial class Form1 : Form
  {
    MyList list; // = new MyList();
    Random rnd = new Random();

    public Form1()
    {
      InitializeComponent();
      ctrlDgv.RowCount = 1;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      list = new MyList();
      for (int i = 0; i < ctrlDgv.RowCount - 1; i++)
        list.Add(Convert.ToString(ctrlDgv.Rows[i].Cells[0].Value));
      list = list.SortDel();
      string[] arr = list.Printer();
      ctrlDgvout.RowCount = arr.Length;
      for (int i = 0; i < arr.Length; i++)
        ctrlDgvout.Rows[i].Cells[0].Value = arr[i];
    }

    private void button2_Click(object sender, EventArgs e)
    {
      ctrlDgvout.RowCount = 0;
      ctrlDgv.RowCount = 1;
    }
  }
}
