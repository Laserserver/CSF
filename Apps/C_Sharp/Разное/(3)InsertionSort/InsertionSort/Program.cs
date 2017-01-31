using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сортировка простыми вставками");
            Console.WriteLine("Введите размер массива:");
            int L = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[L];
            int n = 0;
            Console.WriteLine("Первый массив:");
            for (int i = 0; i < L; i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
            }

            int K = InsSort(a,n);
            Console.WriteLine("Отсортированный массив:");
            for (int k = 0; k < L; k++)
            {
                Console.WriteLine(a[k]);
            }
            Console.WriteLine("Счётчик(число операций): {0}", K);
            Console.ReadKey();
        }
        public static int InsSort(int[] a, int n)
        {
            
            int N = a.Length;
            int min = 0, imin = 0, i;
            for (i = 0; i <= N - 2; i++)
            {
                min = a[i]; imin = i;
                // в этом цикле ищем минимальный элемент
                for (int j = i + 1; j <= N - 1; j++)
                    if (a[j] < min)
                    {
                        min = a[j]; imin = j;
                        n++;
                    }
            
                if (i != imin)
                {   // обмен местами мин. элемента с первым
                    // из оставшейся не отсортированной части 
                    a[imin] = a[i];
                    a[i] = min;
                    n++;
                }
                else n++;
            }
            return n;
        }

    }
}
