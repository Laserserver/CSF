using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CyclesXIV
{
    class Program
    {
        static void Main(string[] args)
        /*VII. Сравнить результаты с точным значением функции, для которой данная сумма определяет 
         * приближенное значение при x, лежащем в интервале (-R, R). R = 1. */
        {
            double x = 0, First = 0, Second = 1, Temp = 1;
            int N = 0, sign = -1;
            Console.WriteLine("Вас приветствует программа, проверяющая равенство двух функций при X,\nлежащем в промежутке от -1 до 1 не включительно.\nПервая функция: 1/sqrt(1+x)\nВторая функция: 1 - 1 * x/2 + (1 * 3) * x^2/(2 * 4) - ...");
            Console.Write("Введите X: ");
            double.TryParse(Console.ReadLine(), out x);
            Console.Write("Введите N: ");
            N = int.Parse(Console.ReadLine());
            if (x != 0 && x * x < 1 && N > 0)
            {
                First = 1 / Math.Sqrt(1 + x);
                for (int i = 1; i <= N; i++, sign = -sign)
                {
                    Temp *= (2 * i - 1) * x / (2 * i);
                    Second += sign * Temp;
                    
                }
                Console.WriteLine("X = {0}\nПервая функция при заданном X равна {1}\nВторая функция при заданном Х равна {2}", x, First, Second);
            }
            else
                Console.WriteLine("Судя по всему, Вы ввели X как число с точкой вместо запятой или Х,\nне удовлетворяющий условию, либо N как отрицательное число.");
            Console.WriteLine("Для выхода из программы нажмите Enter.");
            Console.ReadLine();
        }
    }
}
