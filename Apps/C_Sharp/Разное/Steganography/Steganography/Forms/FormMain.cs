using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganography
{
    public partial class FormMain : Form
    {
        ClassImage CI;
        public FormMain()
        {
            InitializeComponent();
        }

        private void CtrlTSButtonShow_Click(object sender, EventArgs e)
        {
            if (CI != null)
            {
                FormPreview FP = new FormPreview(CI.GetNormal(), "Превью");
                FP.Show();
            }
        }

        private void CtrlButLoad_Click(object sender, EventArgs e)
        {
            if (CtrlOFD.ShowDialog() == DialogResult.OK)
            {
                CI = new ClassImage(CtrlOFD.FileName);
                int Bites = CI.RetAvailableSize();
                CtrlLblSize.Text = "Допустимый размер данных: \n" + Bites + " бит.\n";
                Bites /= 8;
                CtrlLblSize.Text += Bites + " байт.\n";
                CtrlLblString.Text = "Строка длиной: " + (Bites / 2 - 1) + " знаков.";
                Bites /= 1024;
                CtrlLblSize.Text += Bites + " килобайт.\n";
                Bites /= 1024;
                CtrlLblSize.Text += Bites + " мегабайт.";
                CI.Decode();
            }
        }

        private void CtrlTSButReady_Click(object sender, EventArgs e)
        {
            if (CI != null)
            {
                FormPreview FP = new FormPreview(CI.GetChanged(), "Измененное");
                FP.Show();
            }
        }

        private void CtrlButTest_Click(object sender, EventArgs e)
        {
            CI.EncodeString(CtrlTxb.Text);
        }

        private void CtrlButDecode_Click(object sender, EventArgs e)
        {
            CtrlTxbOut.Text = CI.DecodeString();
        }
    }
}
