using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcFunc7
{
  class Finder
  {
    public static int Number(int[,] MyArr, bool MaxInMin, bool Row)
    {
      if (MaxInMin)
        if (Row)
          return Maxer(MyArr, 0, 1);
        else
          return Maxer(MyArr, 1, 0);
      else
        if (Row)
          return Miner(MyArr, 0, 1);
        else
          return Miner(MyArr, 1, 0);
    }
    public static int Maxer(int[,] Matrix, int Row, int Col)
    {
      int[] NewArr = new int[0];
      for (int i = 0; i < Matrix.GetLength(Row); i++)
      {
        int Min = int.MaxValue;
        for (int j = 0; j < Matrix.GetLength(Col); j++)
          if (Col == 1)
          {
            if (Matrix[i, j] < Min)
              Min = Matrix[i, j];
          }
          else
            if (Matrix[j, i] < Min)
              Min = Matrix[j, i];
            Array.Resize(ref NewArr, NewArr.Length + 1);
            NewArr[NewArr.Length - 1] = Min;
      }
      int Max = int.MinValue;
      for (int l = 0; l < NewArr.Length; l++)
        if (NewArr[l] > Max)
          Max = NewArr[l];
      return Max;
    }


    public static int Miner(int[,] Matrix, int Row, int Col)
    {
      int[] NewArr = new int[0];
      for (int i = 0; i < Matrix.GetLength(Row); i++)
      {
        int Max = int.MinValue;
        for (int j = 0; j < Matrix.GetLength(Col); j++)
        {
          if (Col == 1)
          {
            if (Matrix[i, j] > Max)
              Max = Matrix[i, j];
          }
          else
            if (Matrix[j, i] > Max)
              Max = Matrix[j, i];
        }
        Array.Resize(ref NewArr, NewArr.Length + 1);
        NewArr[NewArr.Length - 1] = Max;
      }
      int Min = int.MaxValue;
      for (int l = 0; l < NewArr.Length; l++)
        if (NewArr[l] < Min)
          Min = NewArr[l];
      return Min;
    }
  }
}
