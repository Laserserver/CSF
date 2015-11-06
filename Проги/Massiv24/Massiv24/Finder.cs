using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Massiv24
{
  class Finder
  {
    public static void Result(int[] Num, out int Max, out int MaxNum)
    {
      Max = Num[0];
      Array.Resize(ref Num, Num.Length - 1);
      foreach (int Temp in Num)
      {
        if (Temp > Max)
          Max = Temp;
      }
      MaxNum = Array.IndexOf(Num, Max) + 1;
    }
  }
}
