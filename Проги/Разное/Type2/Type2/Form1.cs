using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Type2
{
    public partial class Form1 : Form
    {
        RationalNumber x1,x2;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((int.TryParse(znam2.Text, out x2.denominator) && int.TryParse(znam1.Text, out x1.denominator) && int.TryParse(chisl2.Text, out x2.numerator) && int.TryParse(chisl1.Text, out x1.numerator)))
                if (Rational.Equal(x1, x2))
                    MessageBox.Show("Числа равны.");
                else
                    MessageBox.Show("Числа не равны.");
            else
                MessageBox.Show("Введены неправильные числа.");
            
        }
    }

}

