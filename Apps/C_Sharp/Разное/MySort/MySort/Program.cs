using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySort
{
    class Program
    {
        static void Main(string[] args)
        {
            Sorting m = new Sorting();
            int[] arr;
            Console.WriteLine("Введите длину массива:");
            int arrCount = Convert.ToInt32(Console.ReadLine());
            arr = new int[arrCount];
            Random rnd = new Random();
            Console.WriteLine("Исходный массив");
           /* for (int i = 0; i < arrCount; i++)
            {
                arr[i] = rnd.Next(-50, 50);
                Console.WriteLine(arr[i]);
            }*/
          
            for (int i = 0; i < arrCount; i++)
            {
                int temp = Convert.ToInt32(Console.ReadLine());
               arr[i] = temp;
            }
            Console.WriteLine("Отсортированный массив");
          m.InsertionSort(arr, arrCount);
           // m.BubbleSort(arr, arrCount);
            m.print(m.InsertionSort(arr, arrCount), m.ReternNumberOfComparsion());
            for (int i = 0; i < arrCount; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadKey();
        }
    }
}
