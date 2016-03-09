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
      int K = 0;
      for (int i = 0; i < Input.Count; i++)
      {
        if (Input[i] != "" && Char.IsDigit(Input[i][0]))
        {
          int.TryParse(Input[i], out N);
          Sum += N;
          K++;
        }
      }
      return Math.Round(Sum / K * 1.0, 2).ToString();
    }
  }
}