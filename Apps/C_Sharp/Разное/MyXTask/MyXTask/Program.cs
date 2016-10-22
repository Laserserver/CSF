using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyXTask
{
  class Program
  {
    static void Main(string[] args)
    /*X. Сравнить результаты с точным значением функции, для которой данная сумма определяет 
     * приближенное значение при x, лежащем в интервале (-R, R). R = 1. */
    {
      double x = 0, First = 0, Second = 1, Multiplier = 1, E = 0, Dif = 0;
      int n = 0, N = 0;
      Console.WriteLine("Вас приветствует программа, проверяющая равенство двух функций при X,\nлежащем в промежутке от -1 до 1 не включительно.\nПервая функция: 1/((1+x)*(1+x))\nВторая функция: 1 - 2 * x + 3 * x ^ 2- ...");
      Console.Write("Введите X: ");
      double.TryParse(Console.ReadLine(), out x);
      if (x != 0)
      {
        First = 1 / ((1 + x) * (1 + x));
        Console.Write("Выберите задачу - А или Б: ");
        string Caser = Console.ReadLine();
        {
          switch (Caser)
          {
            case "А":
              {
                Console.Write("Введите E: ");
                double.TryParse(Console.ReadLine(), out E);

                for (int i = 2; Math.Abs(Multiplier) > E; i++)
                {
                  Multiplier *= -x;    //Каждый элемент выглядит как предыдущий, домножаемый на -х
                  Second += i * Multiplier;   //Т.к. (-1)^(i-1) * x^i
                  n++;
                }
                Dif = Math.Abs(First - Second);  //Т.к. второе значение больше
                Console.WriteLine("X = {0}\nФункции имеют приблизительную точность до E после {1} итераций:\nПервая функция равна {2}\nВторая функция равна {3},\nРазность: {4}", x, n, First, Second, Dif);
              }
              break;
            case "Б":
              Console.Write("Введите N: ");
              int.TryParse(Console.ReadLine(), out N);
              for (int i = 2; i <= N; i++)
              {
                Multiplier *= -x;
                Second += i * Multiplier;
              }
              Dif = Math.Abs(First - Second);
              Console.WriteLine("X = {0}\nФункция при заданном Х равна {1},\n Истинное значение: {2},\n Разница: {3}", x, Second, First, Dif);
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
