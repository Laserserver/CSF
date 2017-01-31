using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _5task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int N = 10;
        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            dgv.RowCount = N;
            dgv.ColumnCount = 2;
            for (int i = 0; i < N; i++)
            {
                dgv[0, i].Value = i + 1;
                dgv[1, i].Value = rnd.Next(10*i, (i+1)*10);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int M = dgv.RowCount;
            int[] a = new int[M];
            for (int i = 0; i < M; i++)
            {
               int.TryParse(this.dgv[1, i].Value.ToString(), out a[i]);
            }
            posl.Text += Sort.SortSimple(a);
            bin.Text += Sort.SortBinary(a);
            textBox1.Text += Sort.SortShell(a);
            textBox2.Text += Sort.quickSort(a, 0, a.Length - 1, 0);
            textBox3.Text += Sort.SortSl(a);
        }

             private void Form1_Load(object sender, EventArgs e)
             {

             }

             private void button3_Click(object sender, EventArgs e)
             {
                 Random rnd = new Random();
                 dgv.RowCount = N;
                 dgv.ColumnCount = 2;
                 for (int i = 0; i < N; i++)
                 {
                     dgv[0, i].Value = i + 1;
                     dgv[1, i].Value = rnd.Next(10 * (N - i), (N - i + 1) * 10);
                 }
             }

             private void button4_Click(object sender, EventArgs e)
             {
                 Random rnd = new Random();
                 dgv.RowCount = N;
                 dgv.ColumnCount = 2;
                 for (int i = 0; i < N; i++)
                 {
                     dgv[0, i].Value = i + 1;
                     dgv[1, i].Value = rnd.Next(i*10);
                 }
             }

    }
}
