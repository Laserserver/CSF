using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace task21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i, k, m;
            if (!int.TryParse(textBox1.Text, out i))
            {
                MessageBox.Show("");
                return;
            }
            Rhyme.InMyList(i);
            if (!int.TryParse(textBox2.Text, out k))
            {
                MessageBox.Show("");
                return;
            }
      //m = Rhyme.LastNumber(k);
      m = Rhyme.Test(k);
            textBox3.Text = m.ToString();
        }
    }
}
