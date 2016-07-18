using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _15_21
{
  public partial class LoTV : Form
  {
    OpenFileDialog OFD = new OpenFileDialog();
    int[] Numbers;
    public LoTV()
    {
      InitializeComponent();
    }

    private void ctrlBaton_Click(object sender, EventArgs e)
    {
      if (Numbers != null && Numbers.Length != 0)
      {
        LoTVQueue Queue = new LoTVQueue();
        for (int i = 0; i < Numbers.Length; i++)
          Queue.InQueue(Numbers[i]);
        try
        {
          if (ctrlTxb.Text != "")
          {
            Queue = Thing.CutQueue(int.Parse(ctrlTxb.Text), Queue);

            int Count = Queue.count;
            ctrlDGV.RowCount = Count;
            ctrlDGV.Columns[0].Width = 30;
            for (int i = 0; i < Count; i++)
              ctrlDGV.Rows[i].Cells[0].Value = Queue.OutQueue();
          }
          else
            MessageBox.Show("Пустое окно элемента");
        }
        catch
        {
          MessageBox.Show("Введено неверное число.", "Ошибка");
        }
      }
    }

    private void ctrlLoadBaton_Click(object sender, EventArgs e)
    {
      if (OFD.ShowDialog() == DialogResult.OK)
      {
        StreamReader txt = new StreamReader(OFD.FileName);
        try
        {
          Numbers = Parser.Parse(txt.ReadToEnd());
        }
        catch
        {
          MessageBox.Show("Ошибка форматирования");
        }
        txt.Close();
      }
      ctrlDGVPreview.RowCount = Numbers.Length;
      ctrlDGVPreview.Columns[0].Width = 30;
      for (int i = 0; i < Numbers.Length; i++)
        ctrlDGVPreview.Rows[i].Cells[0].Value = Numbers[i];

    }
  }
}
