using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace spisky38
{
    public partial class Form1 : Form
    {
        MyQueue queue;
        OpenFileDialog ofd = new OpenFileDialog();
        int[] Numbers;
        public Form1()
        {
            InitializeComponent();
            queue = new MyQueue();
            ofd.DefaultExt = "*.txt";
            ofd.Filter = "TXT|*.txt";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
                try
                {
                    // FileStream file = new FileStream(@"C:\Users\User\Desktop\projects\spisky38",FileMode.Open);
                    StreamReader f = new StreamReader(ofd.FileName);
            Numbers = Parser.Parse(f.ReadToEnd());
            f.Close();
                }
                catch
                {
                    MessageBox.Show("Неверно отформатирован файл.");
                }
            for (int i = 0; i < Numbers.Length; i++)
                queue.InQueue(Numbers[i]);
            //bool u = true;
            //for (int i =0; i < Numbers.Length; i++)
            // {
            // }
            answer.Text = "Ответ: " + queue.Check();

        }
    }
}
