using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stroka7
{
    public partial class MyMainForm : Form
    {
        int Num = 0;
        string a = null;
        bool Ans = true;
        public MyMainForm()
        {
            InitializeComponent();
        }

        private void ButtonFinder_Click(object sender, EventArgs e)
        {
            a = InputStringBox.Text;
            Letter.NonAlpha(a, out Num, out Ans);
            MessageBox.Show (Ans ? (String.Format("Первый небуквенный символ находится на {0} позиции", Num)) : ("Небуквенных символов нет."));
        }
    }
}
