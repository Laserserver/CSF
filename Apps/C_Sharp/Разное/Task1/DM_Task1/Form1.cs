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

namespace DM_Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if ((!radioButton1.Checked) & (!radioButton2.Checked) & (!radioButton3.Checked))
            {
                MessageBox.Show("Выберите матрицу, пожалуйста!");
            }
            else
            {
                string file1 = "";
                if (radioButton1.Checked)
                {
                    file1 = "3";
                }
                else
                {
                    if (radioButton2.Checked)
                    {
                        file1 = "10";
                    }
                    else
                    {
                        file1 = "13";
                    }
                }
                try
                {
                    double det;
                    FileStream myStream = new FileStream("inputs/input" + file1 + ".txt", FileMode.Open); 
                    using (StreamReader sr = new StreamReader(myStream))       
                    {
                        int i = 0;
                        string line = "";
                        char[] sep = { ' ' };
                        line = sr.ReadLine();
                        string[] lineSp = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                        int n = lineSp.Length;
                        int[,] matr = new int[n, n];
                        for (int j = 0; j < n; j++)
                        {
                            matr[0, j] = Convert.ToInt32(lineSp[j]);
                        }
                        while ((line = sr.ReadLine()) != null)
                        {
                            i++;
                            lineSp = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                            for (int j = 0; j < n; j++)
                            {
                                matr[i, j] = Convert.ToInt32(lineSp[j]);
                            }
                        }
                        Calculate calc = new Calculate();
                        det = calc.Det(ref matr, n);
                        textBox1.Text = det.ToString();
                    }
                    myStream.Close();
                    FileStream myStream1 = new FileStream("myoutputs/output" + file1 + ".txt", FileMode.Create);
                    using (StreamWriter sw = new StreamWriter(myStream1))
                    {
                        sw.Write(det);
                    }
                    myStream1.Close();
                }
                catch (IOException E)
                {
                    MessageBox.Show(E.ToString());
                    return;
                }
            }
        }
    }
}
