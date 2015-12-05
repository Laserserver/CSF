using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix17
{
  class Helper
  {
    public static int Finder(int[,] Arr)
    {
      int Max = int.MinValue;
      for (int i = 0; i < Arr.GetLength(1); i++)
      {
        int Min = int.MaxValue;
        for (int k = 0; k < Arr.GetLength(0); k++)
          if (Arr[k, i] < Min)
            Min = Arr[k, i];
        if (Min > Max)
          Max = Min;
      }
      return Max;
    }
  }
}