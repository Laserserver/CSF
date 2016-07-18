using System;
using System.Windows.Forms;
using System.IO;

namespace _15_36
{
  public partial class HoTS : Form
  {
    OpenFileDialog OFD = new OpenFileDialog();
    int[] Numbers;
    HoTSQueue NewQueue = new HoTSQueue();
    public HoTS()
    {
      InitializeComponent();
      OFD.DefaultExt = "*.txt";
      OFD.Filter = "TXT|*.txt";
    }

    private void ctrlBaton_Click(object sender, EventArgs e)
    {
      if (OFD.ShowDialog() == DialogResult.OK)
        try
        {
          StreamReader Txt = new StreamReader(OFD.FileName);
          Numbers = Parser.Parse(Txt.ReadToEnd());
          Txt.Close();
        }
        catch
        {
          MessageBox.Show("Неверно отформатирован файл.");
        }
      for (int i = 0; i < Numbers.Length; i++)
        NewQueue.InQueue(Numbers[i]);
      ctrlLblAnswer.Text = "Ответ: " + Logic.FindMaxCount(NewQueue);
    }
  }
}
