using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CyclesVIITest
{
    class Program
    {
        static void Main(string[] args)
        /*VII. Сравнить результаты с точным значением функции, для которой данная сумма определяет 
         * приближенное значение при x, лежащем в интервале (-R, R). R = 1. */
        {
            double x = 0, First = 0, Second = 1, Temp = 1, E = 0, Dif = 0;
            int sign = -1, n = 0, N = 0;
            Console.WriteLine("Вас приветствует программа, проверяющая равенство двух функций при X,\nлежащем в промежутке от -1 до 1 не включительно.\nПервая функция: 1/sqrt(1+x)\nВторая функция: 1 - 1 * x/2 + (1 * 3) * x^2/(2 * 4) - ...");
            Console.Write("Введите X: ");
            double.TryParse(Console.ReadLine(), out x);
            if (x != 0)
            {
                Console.Write("Выберите задачу - А или Б: ");
                string Caser = Console.ReadLine();
                {
                    switch (Caser)
                    {
                        case "А":
                            {
                                Console.Write("Введите E: ");
                                double.TryParse(Console.ReadLine(), out E);

                                for (int i = 1; Math.Abs(Temp) > E; i++, sign = -sign)
                                {
                                    Temp *= (2 * i - 1) * x / (2 * i);
                                    Second += sign * Temp;
                                    n++;
                                }
                                First = 1 / Math.Sqrt(1 + x);
                                Dif = First - Second;
                                Console.WriteLine("X = {0}\nФункции имеют приблизительную точность до E после {1} итераций:\nПервая функция равна {2}\nВторая функция равна {3},\n dif = {4}", x, n, First, Second, Dif);
                            }
                            break;
                        case "Б":
                            Console.Write("Введите N: ");
                            int.TryParse(Console.ReadLine(), out N);
                            for (int i = 1; i <= N; i++, sign = -sign)
                            {
                                Temp *= (2 * i - 1) * x / (2 * i);
                                Second += sign * Temp;

                            }
                            First = 1 / Math.Sqrt(1 + x);
                            Dif = First - Second;
                            Console.WriteLine("X = {0}\nФункция при заданном Х равна {1}, real={2};  dif={3}", x, Second, First, Dif);
                            break;
                    }
                }
            }
            else
                Console.WriteLine("Судя по всему, Вы ввели X как число с точкой вместо запятой или Х,\nне удовлетворяющий условию, либо N как отрицательное число.");
            Console.WriteLine("Для выхода из программы нажмите Enter.");
            Console.ReadLine();
        }
    }
}
