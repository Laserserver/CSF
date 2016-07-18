using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Massiv24
{
  class Finder
  {
    public static int Result(int[] Num, out int MaxNum)
    {
      int Max = int.MinValue;
      MaxNum = 0;
      for (int j = 0; j < Num.Length; j++)
        if (Num[j] > Max)
        {
          Max = Num[j];
          MaxNum = j;
        }
      return Max;
    }
  }
}
