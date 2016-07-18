using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Posled7
{
    class Program
    {
        static void Main(string[] args)
        {
            /*7.	Вводится последовательность вещественных чисел, оканчивающаяся
             * нулём, и состоящая более чем из одного ненулевого элемента. Определить,
             * имеют ли первое и последнее числа последовательности один знак.*/
            double First = 0, Second = 1;
            short n = 0;
            Console.WriteLine("Вас приветствует программа, определяющая тождественность знаков первого и\nпоследнего членов последовательности.");
            Console.WriteLine("Введите числа по порядку. Чтобы закончить, введите 0.");
            double.TryParse(Console.ReadLine(), out First);
            if (First == 0)
                Console.WriteLine("Что-то пошло не так. Наверное, Вы первым элементом ввели 0.");
            else
            {
                while (Second != 0)
                {
                    Second = double.Parse(Console.ReadLine());
                    n++;
                }
                if (n == 0)
                    Console.WriteLine("Что-то пошло не так. Наверное, Вы ввели только один элемент.");
                else
                Console.WriteLine((Math.Sign(First) == Math.Sign(Second)) ? "Знаки одинаковы" : "Знаки не одинаковы");     
            }
            Console.WriteLine("Для выхода из программы нажмите Enter.");
            Console.ReadLine();
        }
    }
}