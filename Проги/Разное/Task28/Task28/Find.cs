using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
  class Find
  {
    public static int Finder(int[] Mass, out int Ind)
    {
      Ind = 0;
      int Temp = int.MaxValue;
      for (int i = 0; i < Mass.Length; i++)
        if (Temp > Mass[i])
          Temp = Mass[i];
      for (int i = 0; i < Mass.Length; i++)
        if (Mass[i] == Temp)
        {
          Ind = i;
          break;
        } 
      return Temp;
    }
  }
}
