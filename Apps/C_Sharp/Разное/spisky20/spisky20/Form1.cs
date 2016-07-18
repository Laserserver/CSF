using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spisky20
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        MyQueue queue;
      //  MyQueue queue2;
        int t;
        int count;
        int f;
        public Form1()
        {
            InitializeComponent();
            queue = new MyQueue();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int n = 20;
          //  queue.createTheQ(n);

            queue = new MyQueue();
            for (int i = 0; i < 20; i++)
            {
                t = rnd.Next(-50, 50);
                
                queue.InQueue(t);
               
                //  queue.InQueue(rnd.Next(-50,50));
                if (t >= 0)
                    f++;
                else
                    count = f++;
            }
       //  queue2 = new MyQueue();
            textBox1.Lines =queue.Printer() ;
            for (int i =0; i < (count); i++)
            {
                queue.InQueue(queue.OutQueue());
            }
            queue.OutQueue();
            for (int i =0; i < (19-count); i++)
            {
                queue.InQueue(queue.OutQueue());
            }
           textBox2.Lines = queue.Printer();
           //  MessageBox.Show(count.ToString()+1);// вывод рандома
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            queue = new MyQueue();
            for (int i= 0; i<19; i ++)
                queue.OutQueue();
            textBox1.Lines = queue.Printer();
            textBox2.Lines = queue.Printer();
        }
    }
}
