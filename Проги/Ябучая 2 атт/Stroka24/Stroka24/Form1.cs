using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stroka24
{
  public partial class MainFormStroka24 : Form
  {
    public MainFormStroka24()
    {
      InitializeComponent();
    }

    private void buttonWordFinder_Click(object sender, EventArgs e)
    {
      char Letter;
      if (txbSymb.Text.Length == 1 && txbIn.Text != "")
      {
        txbOut.Text = null;
        Letter = txbSymb.Text[0];
        string[] Str = Thinker.Finder(txbIn.Text, Letter);
        if (Str.Length == 0)
          txbOut.Text = "Слов, подходящих условию, нет.";
        else
          for (int i = 0; i < Str.Length; i++)
            txbOut.Text += Str[i] + ' ';
      }
      else
        txbOut.Text = "Вы не ввели символ для поиска, ввели несколько или не ввели строку для поиска.";    
    }          
  }
}
