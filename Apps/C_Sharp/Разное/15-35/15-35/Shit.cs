using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _15_35
{
  public partial class Shit : Form
  {
    OpenFileDialog ofd = new OpenFileDialog();
    SaveFileDialog sfd = new SaveFileDialog();
    MyLib.FuckingStackClass MyStack;
    public Shit()
    {
      InitializeComponent();
    }

    private void _ctrlBaton_Click(object sender, EventArgs e)
    {
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        try
        {
          StreamReader Reader = new StreamReader(ofd.FileName);
          MyStack = MyLib.FuckingStackLogic.Parser(Reader.ReadToEnd());
          Reader.Close();
        }
        catch
        {
          MessageBox.Show("Fuck you, fucking faggot!", "Fuck you");
        }
      }
      if (sfd.ShowDialog() == DialogResult.OK)
      {
        StreamWriter Writer = new StreamWriter(sfd.FileName);
        Writer.Write(MyLib.FuckingStackLogic.ReturnShit(MyStack));
        Writer.Close();
      }
    }
  }
}
