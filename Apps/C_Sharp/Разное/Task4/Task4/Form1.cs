using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Task4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = sort(new int[] {1,2,3}/*read(new StreamReader("input.txt"))*/);
        }

        int[] read(StreamReader file)
        {
            int[] otv;
            string s = file.ReadLine();
            label1.Text = s;
            char[] del = { ' ' };
            string[] z = s.Split(del, StringSplitOptions.RemoveEmptyEntries);
            otv = new int[z.Length];
            for (int i = 0; i < z.Length; i++)
            {
                otv[i] = Convert.ToInt32(z[i]);
            }
            return otv;
        }

        bool sqr(int a, int b)
        {
            count++;
            return a > b;
        }

        int count = 0;

        string sort(int[] list)
        {
            label1.Text = "";
            for (int i = 0; i < list.Length; i++)
            {
                label1.Text += list[i] + " ";
            }
            int n = list.Length;
            for (int i = 1; i < n; i++)
            {
                int newElement = list[i];
                for (int location = i - 1; location > -1; location--)
                {
                    
                    if (sqr(list[location],newElement))
                    {
                        int x = list[location + 1];
                        list[location + 1] = list[location];
                        list[location] = x;
                    }
                }
                /*while (location >= 0 && list[location] > newElement)//произошло сравнение
                {
                    list[location + 1] = list[location];
                    location = location - 1;
                    count++;
                }*/
                //list[0] = newElement;
            }
            string s = "";
            for (int i = 0; i < list.Length; i++)
            {
                s += Convert.ToString(list[i]) + " ";
            }
            s += "\nСравнений:" + Convert.ToString(count);
            return s;
        }
    }
}
