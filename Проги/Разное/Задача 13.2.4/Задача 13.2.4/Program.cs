using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Задача_13._2._4
{
    //Дано число k и файл, содержащий ненулевые целые числа.
    //Вывести элемент файла с номером k (элементы файла нумеруются от нуля). 
    //Если такой элемент отсутствует, то вывести 0. 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите k: ");
            int k = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите название файла: ");
            string name = Console.ReadLine();
            string[] mas = File.ReadAllLines(name);
            Console.WriteLine();
            if (mas.Length < k) Console.WriteLine("0/no");
            else  Console.WriteLine(mas[k]);
            Console.ReadKey();
            
        }
    }
}
