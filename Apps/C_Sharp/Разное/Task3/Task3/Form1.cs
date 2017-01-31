using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] mass = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 25, 25, 26 };//read(new StreamReader("input.txt"));
            label1.Text = posled_poisk(mass);
            //label2.Text = doal_poisk(mass); //19-20
            label3.Text = interpolationSearch(mass); // interpolacionnii_poisk(mass); //4-5
        }

        int[] read(StreamReader file)
        {
            int[] otv;
            string s = file.ReadLine();
            char[] del = { ' ' };
            string[] z = s.Split(del, StringSplitOptions.RemoveEmptyEntries);
            otv = new int[z.Length];
            for (int i = 0; i < z.Length; i++)
            {
                otv[i] = Convert.ToInt32(z[i]);
            }
            s = file.ReadLine();
            return otv;
        }

        float sredznach(int[] mass)//среднее значение
        {
            float a = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                a += mass[i];
            }
            return a / mass.Length;
        }

        string posled_poisk(int[] mass)//последовательный поиск
        {
            int[] chislo_poiskov = new int[mass.Length];
            for (int i = 0; i < mass.Length; i++)
            {
                int iskomoe = mass[i];
                chislo_poiskov[i] = 0;
                for (int j = 0; j < mass.Length; j++)
                {
                    chislo_poiskov[i]++;
                    if (iskomoe == mass[j])
                    {
                        break;
                    }
                }
            }
            return Convert.ToString(sredznach(chislo_poiskov));
        }

        string doal_poisk(int[] mass)//двоичный поиск
        {
            int[] chislo_poiskov = new int[mass.Length];
            for (int i = 0; i < mass.Length; i++)
            {
                int iskomoe = mass[i];
                chislo_poiskov[i] = dual_poisk(mass, iskomoe, 1);
            }
            return Convert.ToString(sredznach(chislo_poiskov));
        }
        int dual_poisk(int[] mass, int iskomoe, int nomber)
        {
            int sred = mass.Length / 2;
            if (mass.Length != 0)
            {
                if (iskomoe == mass[sred])
                {
                    return nomber;
                }
                else
                {
                    int[] a = new int[sred];
                    int[] b = new int[sred];
                    for (int j = 0; j < sred; j++)//1 2 3 4 5 6 7
                    {
                        a[j] = mass[j];//1 2 3
                        b[j] = mass[j + sred + 1];
                    }
                    int vetv = dual_poisk(a, iskomoe, nomber + 1);
                    if (vetv == 0)
                    {
                        return dual_poisk(b, iskomoe, nomber + 1);
                    }
                    else
                    {
                        return vetv;
                    }
                }
            }
            else
            {
                return 0;
            }
        }

        /*string interpolacionnii_poisk(int[] mass)//интерполяционный поиск
        {
            int next;
            int[] chislo_poiskov = new int[mass.Length];
            int left = mass[0] / mass.Length;
            int right = mass[mass.Length - 1] / mass.Length;
            for (int i = 0; i < mass.Length; i++)
            {
                int iskomoe = mass[i];
                next = left + (((right - left) / (mass[right] - mass[left])) * (iskomoe - mass[left]));
                chislo_poiskov[i] = 1;
                if (mass[next] > iskomoe)
                {
                    chislo_poiskov[i]++;
                    return interpolacionnii_poisk(mass, next--, iskomoe);
                }
                else
                {
                    chislo_poiskov[i]++;
                    return interpolacionnii_poisk(mass, next++, iskomoe);
                }
            }
            return Convert.ToString(sredznach(chislo_poiskov));
        }
        string interpolacionnii_poisk(int[] mass, int next, int iskomoe)
        {
            int[] a = new int[next];
            int[] b = new int[mass.Length - next];
            for (int j = 0; j < mass.Length; j++)
            {
                if (j < next)
                {
                    a[j] = mass[j];
                }
                else
                {
                    b[j - next] = mass[j];
                }
            }
            if (a.Length != 1)
            {
                return interpolacionnii_poisk(a);
            }
            else
            {
                if (b.Length != 1)
                {
                    return interpolacionnii_poisk(b);
                }
                else
                {
                    return "0";
                }
            }
        }*/


        public string interpolationSearch(int[] mass)
        {
            int[] chislo_poiskov = new int[mass.Length];
           
            for (int i = 0; i < mass.Length; i++)
            {
                chislo_poiskov[i] = 0;
                int toFind = mass[i];
                int mid;
                int low = 0;
                int high = mass.Length - 1;

                while (mass[low] < toFind && mass[high] > toFind)
                {
                    mid = low + ((toFind - mass[low]) * (high - low)) / (mass[high] - mass[low]);

                    if (mass[mid] < toFind)
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        if (mass[mid] > toFind)
                        {
                            high = mid - 1;
                        }
                        else
                        {
                            chislo_poiskov[i]++;
                            break;//выбрасывает, если находится элемент
                        }
                    }
                }

                if (mass[low] == toFind)
                {
                    chislo_poiskov[i]++;
                }
                else
                {
                    if (mass[high] == toFind)
                    {
                        chislo_poiskov[i]++;
                    }
                }
            }
            return Convert.ToString(sredznach(chislo_poiskov));
        }
    }
}
