using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Massiv7
{
  class T_finder
  {
    public static void TFinder(int[] Num, out bool t)
    {
      t = true;
      Array.Resize(ref Num, Num.Length - 1);
      if (Num.Length == 1)
        t = false;
      else
      {
        int k = Array.IndexOf(Num, '0');
        for (int i = 1; i < Num.Length; i++)
        {
          if (((Num[i] > 0 && Num[i - 1] < 0 && k == -1) || (Num[i] < 0 && Num[i - 1] > 0 && k == -1)))
          {
            t = true;
          }
          else
          {
            t = false;
            break;
          }
        }
      }
    }
  }
}
