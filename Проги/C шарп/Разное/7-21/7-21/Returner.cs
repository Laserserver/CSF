using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7_21
{
  class Returner
  {
    public static int[] Change(int[] Arr)
    {
      int[] New = new int[Arr.Length];
      for (int i = 0, k = Arr.Length - 1; i < Arr.Length; i++, k--)
        New[i] = Arr[k];
      return New;
    }
  }
}
