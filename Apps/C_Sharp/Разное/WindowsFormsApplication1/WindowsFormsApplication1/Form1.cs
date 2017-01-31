using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        dataGridView1.Rows.Clear();
                        dataGridView1.Refresh();
                        SortedDictionary<string, int> words = new SortedDictionary<string, int>();
                        StreamReader fs = new StreamReader(myStream);
                        string s = fs.ReadToEnd();
                        fs.Close();
                        string[] Ass = s.Split(new string[] {" ","\r\n" ,"\n\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                        int Sc = Ass.Length;
                        for (int i = 0; i < Sc; i++)
                        {
                            if (Ass[i] != null)
                            {
                                Console.WriteLine(Ass[i]);
                                if (!words.ContainsKey(Ass[i]))
                                    words.Add(Ass[i], 1);
                                else
                                    words[Ass[i]]++;
                            }
                        }
                        foreach(var word in words)
                        {
                            dataGridView1.Rows.Add(word.Key, word.Value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при открытии файла: " + ex.Message);
                }
            }
        }

        private void закрытьПрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
