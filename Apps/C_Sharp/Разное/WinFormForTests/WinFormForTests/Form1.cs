using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormForTests
{
    public partial class Form1 : Form
    {
        int A = 0;
        public Form1()
        {
            InitializeComponent();
            CtrlPanel.MouseWheel += new MouseEventHandler(MouseScrollEvent);
        }

        void MouseScrollEvent(object sender, MouseEventArgs e)
        {
            /*if (e.Delta > 0)
                A++;
            else
                A--;
            CtrlLbl.Text = A.ToString();*/
            MessageBox.Show("Sas");
        }

        private void CtrlButStart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                CtrlLb.Items.Add("Говноигра " + (i + 1));
            CtrlWeb.Navigate("http://gog.com");
        }
    }
}
