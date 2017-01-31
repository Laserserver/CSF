using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Draw3D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> qwerty = Lib.graph.Core();
            string[] q1 = new string[qwerty.Count];
            for (int i = 0; i < q1.Length; i++)
                q1[i] = qwerty[i];
            textBox2.Lines = q1;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
