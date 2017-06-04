using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextBoxTestingProgram
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void regExpBox1_TextChanged(object sender, EventArgs e)
        {
            textBox.Text = Regex.IsMatch(regExpBox.Text, regExpBox.RegularExpression).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
