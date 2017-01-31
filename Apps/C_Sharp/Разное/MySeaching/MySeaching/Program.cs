using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeaching
{

    class Program
    {

        static void Main(string[] args)
        {
            int[] arr;

            Search s = new Search();
            Console.WriteLine("Введите длину массива:");
            int arrCount = Convert.ToInt32(Console.ReadLine());
            arr = new int[arrCount];
            Random rnd = new Random();
            Console.WriteLine("Исходный массив");
            for (int i = 0; i < arrCount; i++)
            {
               arr[i] = rnd.Next(-50, 50);
               Console.WriteLine(arr[i]);
            }
            Console.WriteLine("Отсортированный массив");
            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            

            s.LinearSearch(arr);
            s.ShowResult();
           //s.BinarySearch(arr);
           // s.ShowResult();


            Console.ReadKey();
        }
    }
}
