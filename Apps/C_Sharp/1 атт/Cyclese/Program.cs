using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cycle7
{
    class Program
    {
        static void Main(string[] args)
        {/*7.	Дано натуральное n. Вычислить значение выражения -2/1! + 3/2! + (-1)^n*(n+1)/n!*/
            int n = 0, sign = -1;
            double Sum = 0, temp = 0;
            long fact = 1L;
            Console.WriteLine("Вас приветствует программа, вычисляющая сумму элементов последовательности с\nn-ным членом, равным (-1)^n*(n+1)/n!.");
            Console.WriteLine("Введите n:");
            n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; ++i, sign = -sign)           
            {                
                fact *= i;
                temp = (i + 1.0) / fact;
                Sum += sign * temp;
            }
            Console.WriteLine("Сумма {0} членов равна {1}", n, Sum);
            Console.WriteLine("Для выхода нажмите Enter.");
            Console.ReadLine();
        }
    }
}
