using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
  class Help
  {
    public static int[] Find(int[] Arr)
    {
      Array.Sort(Arr);
      int Max = int.MinValue;
      int Min = int.MaxValue;
      for (int i = 0; i < Arr.Length; i++)
        if (Arr[i] > Max)
          Max = Arr[i];
      for (int i = 0; i < Arr.Length; i++)
        if (Arr[i] < Min)
          Min = Arr[i];
      int[] New = new int[0];
      int k = 0;
      for (int i = Min; i < Max; i++)
      
        if (Array.IndexOf(Arr, i) == -1)
        {
          
          Array.Resize(ref New, New.Length + 1);
          New[k] = i;
            k++;
        }
      
      return New;
    }
  }
}
