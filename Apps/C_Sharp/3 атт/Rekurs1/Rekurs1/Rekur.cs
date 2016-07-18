using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Rekurs1
{
  public partial class Rekur : Form
  {
    OpenFileDialog ofd = new OpenFileDialog();
    
    public Rekur()
    {
      InitializeComponent();
      ofd.DefaultExt = "*.txt";
      ofd.Filter = "TXT files|*.txt";
    }

    private void baton_Click(object sender, EventArgs e)
    {
      try
      {
        lblAns.Text = "Ответ\n" + Rekurs.DoIt(rtbIn.Text, 0);
      }
      catch
      {
        MessageBox.Show("Ошибка в обработке файла.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void batonLoad_Click(object sender, EventArgs e)
    {
      if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK && ofd.FileName.Length > 0)
        rtbIn.LoadFile(ofd.FileName, RichTextBoxStreamType.PlainText);
          
    }
  }
}
