using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/*7.	Напишите функцию NonAlpha(str: string), которая
 * получает параметр str типа string и возвращает позицию
 * его первой литеры, не являющейся буквой (как латинского,
 * так и русского алфавитов) строчной или прописной. Например,
 * NonAlpha( 'stev7n' ) дает 5.*/
namespace Temp
{
    public partial class MyString7 : Form
    {
        public MyString7()
        {
            InitializeComponent();
        }

        private void MyButton_Click(object sender, EventArgs e)
        {
          //  int Num = 0;
            string a = null;
            a = InputStringBox.Text;
           // Letter.NonAlpha(a, out Num);
           // a = Convert.ToString(Num);
            MessageBox.Show(a);
        }      
    }
}
