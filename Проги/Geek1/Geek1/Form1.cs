using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Geek1
{
  public partial class MainForm : Form
  {
    int Counter = 0;
    Random rnd;
    char[] Special = new char[] { '#', '$', '%', '&', '*', '@', '+', '-', '?' };
    Dictionary<string, double> Metric;
    public MainForm()
    {
      InitializeComponent();
      rnd = new Random();
      Metric = new Dictionary<string, double>();
      Metric.Add("мм", 1);
      Metric.Add("см", 10);
      Metric.Add("дм", 100);
      Metric.Add("м", 1000);
      Metric.Add("км", 1000000);
      Metric.Add("мили", 1609344);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      //Lst();
      clbPass.SetItemChecked(0, true);
    }

    private void tsmiExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void tsmiAbout_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Программа для Гикбрейнз содержит ряд небольших программ, кооторые могут пригодиться в жизни. А, главное, научить меня основам программирования Windows Forms.\nАвтор - Mexahoid", "О программе");
    }

    private void butIncr_Click(object sender, EventArgs e)
    {
      Counter++;
      lblCount.Text = Counter.ToString();
    }

    private void butDecr_Click(object sender, EventArgs e)
    {
      Counter--;
      lblCount.Text = Counter.ToString();
    }

    private void butZero_Click(object sender, EventArgs e)
    {
      Counter = 0;
      lblCount.Text = Counter.ToString();
    }

    private void btnRnd_Click(object sender, EventArgs e)
    {
      int n;
      n = rnd.Next(Convert.ToInt32(nudFrom.Value), Convert.ToInt32(nudTo.Value) + 1);
      lblRndAns.Text = Convert.ToString(n);
      if (chkbxRnd.Checked == true)
      {
        int j = 0;

        while (txbRnd.Text.IndexOf(n.ToString()) != -1)
        {
          n = rnd.Next(Convert.ToInt32(nudFrom.Value), Convert.ToInt32(nudTo.Value) + 1);
          j++;
          if (j > n)
            break;
        }
        if (j <= n)
          txbRnd.AppendText(n + "\n");

      }
      else
        txbRnd.AppendText(n + "\n");
    }

    private void btnRndClear_Click(object sender, EventArgs e)
    {
      txbRnd.Clear();
    }

    private void btnRndCopy_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(txbRnd.Text);
    }

    private void tsmiLstAddDate_Click(object sender, EventArgs e)
    {
      rtbLst.AppendText(DateTime.Now.ToShortDateString() + "\n");
    }

    private void tsmiLstAddTime_Click(object sender, EventArgs e)
    {
      rtbLst.AppendText(DateTime.Now.ToShortTimeString() + "\n");
    }

    private void tsmiLstSave_Click(object sender, EventArgs e)
    {
      try
      {
        rtbLst.SaveFile("FuckYou.rtf");
      }
      catch
      {
        MessageBox.Show("Ошибка при сохранении.");
      }
    }

    void Lst()
    {
      try
      {
        rtbLst.LoadFile("FuckYou.rtf");
      }
      catch
      {
        MessageBox.Show("Ошибка при загрузке.");
      }
    }

    private void tsmiLstLoad_Click(object sender, EventArgs e)
    {
      Lst();
    }

    private void btnPass_Click(object sender, EventArgs e)
    {
      if (clbPass.CheckedItems.Count == 0)
        return;
      string Pass = null;
      for (int i = 0; i < nudPassLngt.Value; i++)
      {
        int n = rnd.Next(0, clbPass.CheckedItems.Count);
        string Temp = clbPass.CheckedItems[n].ToString();
        switch (Temp)
        {
          case "Цифры":
            Pass += rnd.Next(10).ToString();
            break;
          case "Прописные буквы":
            Pass += Convert.ToChar(rnd.Next(65, 90));
            break;
          case "Строчные буквы":
            Pass += Convert.ToChar(rnd.Next(97, 122));
            break;
          default:
            Pass += Special[rnd.Next(Special.Length)];
            break;
        }
        txbPassOut.Text = Pass;
        Clipboard.SetText(Pass);
      }
    }

    private void btnConv_Click(object sender, EventArgs e)
    {
      double m1 = Metric[cmbConvIn.Text];
      double m2 = Metric[cmbConvOut.Text];
      double Num = Convert.ToDouble(txbConvIn.Text);
      txbConvOut.Text = (Num * m1 / m2).ToString();
    }

    private void btnConvSwap_Click(object sender, EventArgs e)
    {
      string Temp = cmbConvIn.Text;
      cmbConvIn.Text = cmbConvOut.Text;
      cmbConvOut.Text = Temp;
    }

    private void cmbConvMetr_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (cmbConvMetr.Text)
      {
        case "Длина":
          Metric.Clear();
          Metric.Add("мм", 1);
          Metric.Add("см", 10);
          Metric.Add("дм", 100);
          Metric.Add("м", 1000);
          Metric.Add("км", 1000000);
          Metric.Add("мили", 1609344);
          cmbConvIn.Items.Clear();
          cmbConvIn.Items.Add("мм");
          cmbConvIn.Items.Add("см");
          cmbConvIn.Items.Add("дм");
          cmbConvIn.Items.Add("м");
          cmbConvIn.Items.Add("км");
          cmbConvIn.Items.Add("мили");
          cmbConvOut.Items.Clear();
          cmbConvOut.Items.Add("мм");
          cmbConvOut.Items.Add("см");
          cmbConvOut.Items.Add("дм");
          cmbConvOut.Items.Add("м");
          cmbConvOut.Items.Add("км");
          cmbConvOut.Items.Add("мили");
          cmbConvIn.Text = "мм";
          cmbConvOut.Text = "мм";
          break;
        case "Масса":
          Metric.Clear();
          Metric.Add("г", 1);
          Metric.Add("кг", 1000);
          Metric.Add("цт", 100000);
          Metric.Add("т", 1000000);
          Metric.Add("фунт", 453.6);
          Metric.Add("унц", 283);
          cmbConvIn.Items.Clear();
          cmbConvIn.Items.Add("г");
          cmbConvIn.Items.Add("кг");
          cmbConvIn.Items.Add("цт");
          cmbConvIn.Items.Add("т");
          cmbConvIn.Items.Add("фунт");
          cmbConvIn.Items.Add("унц");
          cmbConvOut.Items.Clear();
          cmbConvOut.Items.Add("г");
          cmbConvOut.Items.Add("кг");
          cmbConvOut.Items.Add("цт");
          cmbConvOut.Items.Add("т");
          cmbConvOut.Items.Add("фунт");
          cmbConvOut.Items.Add("унц");
          cmbConvIn.Text = "г";
          cmbConvOut.Text = "г";
          break;
      }
    }
  }
}
