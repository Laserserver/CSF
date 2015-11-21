using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Massiv7
{
  class T_finder
  {
    public static bool TFinder(int[] Num)
    {      
      if (Num.Length <= 1)
        return false;
      else
      {
        for (int i = 1; i < Num.Length; i++)
        {
          if (!((Num[i] > 0 && Num[i - 1] < 0 && Num[i - 1] != 0) ||
            (Num[i] < 0 && Num[i - 1] > 0 && Num[i - 1] != 0)))
          {
            return false;
          }
        }
      }
      return true;
    }
  }
}