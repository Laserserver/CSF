using System;
using System.Collections.Generic;

namespace WindowsFormsApplication2
{
  class Finder
  {
    public static bool Parser(string Input, double KNum)
    {
      List<int[]> OutList = new List<int[]>();
      for (int i = 0; i < Input.Length / 32; i++)
      {
        int[] IntBytes = new int[32];
        for (int k = 0; k < 32; k++)
          IntBytes[k] = int.Parse(Convert.ToString(Input[(i + 1) * 32 - k - 1]));
        OutList.Add(IntBytes);
      }
      List<double> NewInts = new List<double>();
      for (int i = 0; i < OutList.Count; i++)
      {
        double Out = 0;
        for (int k = 0; k < 32; k++)        
          if (OutList[i][k] == 1)
            Out += Math.Pow(2, k);        
        NewInts.Add(Out);
      }
      for (int i = 0; i < NewInts.Count; i++)
        if (NewInts[i] == KNum)
          return true;
      return false;
    }
  }
}
