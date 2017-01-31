using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _5task1
{
    class Sort
    {
        public static int counter1 = 0;
        public static int counter2 = 0;
        public static int counter3 = 0;
        public static int counter4 = 0;
        public static int counter5 = 0;

        public static int SortSimple(int[] a)
        {   
            for (int i = 1; i <= a.Length - 1; i++)
            {
                int tmp = a[i]; 
                int j = i - 1;
                a[0] = tmp;
                while (j >= 1 && tmp < a[j])
                {
                    a[j + 1] = a[j--];
                    counter1++;
                }
                a[j + 1] = tmp;
                counter1++;
            }
            return counter1;
        }

        public static int SortBinary(int[] a)
        {
            int counter = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int tmp = a[i]; 
                int left = 0; 
                int right = i - 1;
                while (left <= right)
                {
                    counter++;
                    int m = (left + right) / 2;
                    if (tmp < a[m])
                        right = m - 1;
                    else left = m + 1;
                }
                for (int j = i - 1; j >= left; j--)
                {
                    a[j + 1] = a[j];
                }
                a[left] = tmp;
            }
            return counter;
        }

        public static int SortShell(int[] mass) // Шелла 
        {
            int Count = 0;
            int d = mass.Length / 2; // начальное значение интервала 
            while (d > 0) // цикл с уменьшением интервала до 1 
            {
                bool Ok = true; // пузырьковая сортировка с интервалом d 
                while (Ok) // цикл, пока есть перестановки 
                {
                    Ok = false;
                    for (int i = 0; i < mass.Length - d; i++) // сравнение эл-тов на интервале d 
                    { 
                        counter3++;
                        if (mass[i] > mass[i + d])
                        {
                            counter3++;
                            int t = mass[i]; mass[i] = mass[i + d]; mass[i + d] = t; // перестановка 
                            Ok = true; // признак перестановки 
                            Count++;
                        }
                    }
                }
                d = d / 2; // уменьшение интервала 
            }
            return counter3;
        }

        public static int quickSort(int[] mas, int l, int r, int counter)
        {
            int temp;
            counter = 0;
            int x = mas[l + (r - l) / 2];
            //запись эквивалентна (l+r)/2, 
            //но не вызввает переполнения на больших данных 
            int i = l;
            int j = r;
            //код в while обычно выносят в процедуру particle 
            while (i <= j)
            {
                while (mas[i] < x) i++;
                while (mas[j] > x) j--;

                if (i <= j)
                {
                    counter++;
                    temp = mas[i];
                    mas[i] = mas[j];
                    mas[j] = temp;
                    i++;
                    j--;
                }
                counter4++;
            }
            if (i < r)
            {
                quickSort(mas, i, r, counter);
                counter4++;
            }

            if (l < j)
            {
                quickSort(mas, l, j, counter);
                counter4++;
            }
            return counter4;
        }

        public static int[] SortSl(int[] a)
        {

            if (a.Length < 1)
                throw new ArgumentException();
            if (a.Length == 1)
                return a;
            int middle = a.Length / 2;
            int[] left = SortSl(a.Take(middle).ToArray());
            int[] right = SortSl(a.Skip(middle).ToArray());
            int length = left.Length + right.Length;
            int j = 0, k = 0;
            int[] result = new int[length];
            for (int i = 0; i < length; i++)
            {
                if (k >= right.Length || j < left.Length && left[j] < right[k])
                {
                    result[i] = left[j];
                    j++;
                    counter5++;
                }
                else
                {
                    result[i] = right[k];
                    k++;
                    counter5++;
                }

            }
            return result;
        }
    }
}
