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
      int Max = 0;
      Max = Num[0];
      
      {
        foreach (int Temp in Num)
        {
          if (Temp > Max)
            Max = Temp;
        }
        for (MaxNum = 0; MaxNum < Num.Length; MaxNum++)
          if (Num[MaxNum] == Max)
            return Max;
      }
      return Max;
    }
  }
}
