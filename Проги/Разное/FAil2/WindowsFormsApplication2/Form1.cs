using System;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApplication2
{
  public partial class Fail1 : Form
  {
    OpenFileDialog ofd = new OpenFileDialog();
    public Fail1()
    {
      InitializeComponent();
    }

    private void FinBt_Click(object sender, EventArgs e)
    {
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        StreamReader sr = new StreamReader(ofd.FileName);
        try
        {
          MessageBox.Show(Convert.ToString(Finder.Parser(sr.ReadToEnd(), int.Parse(FinBox.Text))));
        }
        catch
        {
          MessageBox.Show("Введен нечисловой символ или неправильно отформатирован файл.");
        }
        sr.Close();
      }
    }
  }
}
