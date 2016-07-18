using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15._8
{
    public partial class FormMain : Form
    {
        Dist dist;

        public FormMain()
        {
            InitializeComponent();
            dist = new Dist();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dist.Open(openFileDialog1.FileName);
                textBox2.Lines = dist.st;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dist.SetList();
            textBox1.Lines = dist.Printer();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
