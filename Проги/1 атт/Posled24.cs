using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Posled24
{
    class Program
    {
        static void Main(string[] args)
        {
            /*24.	Вводится последовательность вещественных чисел, оканчивающаяся нулём,
             * и состоящая более чем из одного ненулевого элемента. Определить, сколько в
             * ней интервалов возрастания.*/
            double First = 0, Second = 0;
            string Str;
            int n = 0, i = 0;
            Console.WriteLine("Введите числа по порядку. Чтобы закончить, введите 0.");
            while ((Str = Console.ReadLine()) != "0")
            {
                double.TryParse(Str, out First);
                i++;
                if (i == 0)
                    goto End;
                else
                {
                    Second += First;
                    double.TryParse(Console.ReadLine(), out First);
                    if (Second <= First)
                    {
                        n++;
                        Second = 0;
                    }
                }
            }
            goto EndNormal;
        End:
            Console.WriteLine("Что-то пошло не так. Наверное, Вы первым элементом ввели 0.");
        EndNormal:
            Console.WriteLine("В данной последовательности {0} интервалов возрастания.", n);
            Console.ReadLine();
        }
    }
}