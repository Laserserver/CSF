using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaisp2Att
{

    public partial class Form1 : Form
    {
        public delegate int MyDel(int A, int B);
        MyDel md = (a, b) => a + b;
        public delegate string MyStr(string A);
        MyStr st = MyDouble;

        private static string MyDouble(string Inp) => Inp + Inp;

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                Button b = new Button();
                b.Parent = this;
                b.Location = new Point(0, i * 25);
                b.Width = 70;
                b.Text = "Button " + i;
                b.Click += (sender, e) =>
                  MessageBox.Show(((Button)sender).Text);
            }
        }

        public static void ForEach<T>(T[] array, Action<T> action)
        {
            foreach (T thing in array)
                action(thing);
        }
        public static T[] FindAll<T>(T[] array, Predicate<T> match)
        {
            T[] Out = new T[0];
            int L = 0;
            foreach (T thing in array)
                if (match(thing))
                {
                    Array.Resize(ref Out, ++L);
                    Out[L - 1] = thing;
                }
            return Out;
        }
        private void Sas()
        {
            int C = md(5, 7);
            string Ass = "abc";
            Ass = st(Ass);
            MessageBox.Show(C.ToString() + ' ' + Ass);
            ForEach(new string[] { "Ты идиот?", "Ты идиот?", "Ты идиот?", "Идиот" }, Inp => MessageBox.Show("Мне что, потанцевать нельзя?", Inp, MessageBoxButtons.YesNo, MessageBoxIcon.Question));
        }
        private void Sas2()
        {
            int[] Arr = new int[] { 1, 6, 7, 14, 23, 21, 40, 28, 24, 56 };
            Arr = FindAll(Arr, Num => Num % 7 == 0);
            ForEach(Arr, Inp => MessageBox.Show(Inp.ToString()));
        }
        public static void Sort<T>(T[] array, IComparer<T> comparer)
        {
            //foreach (T thing in array)
            //  //comparer(thing);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
