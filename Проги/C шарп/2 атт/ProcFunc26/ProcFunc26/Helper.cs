using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcFunc26
{
  class Helper
  {
    public static int[,] Delete(int[,] Matrix, bool IsRow, bool IsMin)
    {
      int[,] NewArr = IsRow ? new int[Matrix.GetLength(0) - 1, Matrix.GetLength(1)] : new int[Matrix.GetLength(0), Matrix.GetLength(1) - 1];
      int RowNumber = 0;
      int ColumnNumber = 0;
      int Number = MaxMin(Matrix, IsMin, out RowNumber, out ColumnNumber);
      if (IsRow)
      {
        if (RowNumber != 0)
          for (int i = 0; i < RowNumber; i++)
            for (int k = 0; k < Matrix.GetLength(1); k++)
              NewArr[i, k] = Matrix[i, k];
        for (int i = RowNumber + 1; i < Matrix.GetLength(0); i++)
          for (int k = 0; k < Matrix.GetLength(1); k++)
            NewArr[i - 1, k] = Matrix[i, k];
      }
      else
      {
        if (ColumnNumber != 0)
          for (int i = 0; i < ColumnNumber; i++)
            for (int k = 0; k < Matrix.GetLength(0); k++)
              NewArr[k, i] = Matrix[k, i];
        for (int i = ColumnNumber + 1; i < Matrix.GetLength(1); i++)
          for (int k = 0; k < Matrix.GetLength(0); k++)
            NewArr[k, i - 1] = Matrix[k, i];
      }
      return NewArr;
    }
    public static int MaxMin(int[,] Matrix, bool IsMin, out int ii, out int ki)
    {
      ki = 0;
      ii = 0;
      int Element = Matrix[0, 0];
      for (int i = 0; i < Matrix.GetLength(0); i++)
        for (int k = 0; k < Matrix.GetLength(1); k++)
          if ((IsMin && Matrix[i, k] > Element) || (!IsMin && Matrix[i, k] < Element))
          {
            Element = Matrix[i, k];
            ii = i;
            ki = k;
          }
      return Element;
    }
  }
}
