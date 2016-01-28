using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectRed
{
  class MiddleLogics
  {
    public static string Middle(List<string> Input)
    {
      double Sum = 0;
      int N = 0;
      for (int i = 0; i < Input.Count; i++)
      {
        int.TryParse(Input[i], out N);
        Sum += N;
      }
      return Math.Round(Sum / Input.Count * 1.0, 2).ToString();
    }
  }
}
