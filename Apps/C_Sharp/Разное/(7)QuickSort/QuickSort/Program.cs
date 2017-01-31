using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        
        static void Main()
        {
            Console.WriteLine("Введите размер массива:");
            int L = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[L];

            Console.WriteLine("Введите массив:");
            for (int t = 0; t < L; t++)
            {
                a[t] = Convert.ToInt32(Console.ReadLine());
            }
            int left=0; int right=L-1;

            QuickSort(a, left, right);

        }
        public static void QuickSort(int[] a, int left, int right)
        {
            int L = a.Length;
            int comp = 0;
            int temp;
            int x = a[left];
            int i = 0;
            int j = right;

            while (i <= j)
            {
                while (a[i] < x)
                {
                    ++i;
                    comp++;
                }
                while (a[j] > x)
                {
                    --j;
                    comp++;
                }
                if (i <= j)
                {
                    temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                    i++;
                    j--;
                }
            }
            if (i < right)
            {
                QuickSort(a, i, right);
            }
            if (j > left)
            {
                QuickSort(a, left, j);
            }

            Console.WriteLine("Отсортированный массив:");
            for (int k = 0; k < L; k++)
            {
                Console.WriteLine(a[k]);
            }

            Console.WriteLine("Количество перестановок: {0}", comp);
            Console.ReadKey();
        }
        }
    }
    

