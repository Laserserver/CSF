using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix6
{
  class Cranker
  {
    public static double[,] Deriver(int[,] Matrix)
    {
      int Max = 0;
      for (int i = 0; i < Matrix.GetLength(0); i++)
        for (int k = 0; k < Matrix.GetLength(1); k++)
          if (Math.Abs(Matrix[i, k]) > (Max))
            Max = Matrix[i, k];
      double[,] NewArr = new double[Matrix.GetLength(0), Matrix.GetLength(1)];
      for (int i = 0; i < Matrix.GetLength(0); i++)
        for (int k = 0; k < Matrix.GetLength(1); k++)
          NewArr[i, k] = Matrix[i, k] * 1.0 / Max;
      return NewArr;
    }
  }
}
