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
      int Num = 0;
      int.TryParse(Console.ReadLine(), out Num);
      int i, j, k, n, o = 0, a, t;
      if (Num == 0)
        Console.WriteLine("Что-то пошло не так. Наверное, Вы первым элементом ввели 0.");
      else
      {
        t = i = 0;
        do
        {
          t++;
          j = t;
          while (j > 0)
          {
            j /= 10;
            i++;
          }
        }
        while (i >= Num);
        while (i <= Num && i != 0)
        {
          o = t % 10;
          t /= 10;
          i--;
        }
      }
      Console.WriteLine("K-я цифра. " + o);
      Console.ReadLine();
    }
  }
}