using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcFunc26
{
  class Helper
  {
    public static int Delete(int[,] Matrix, bool IsRow, bool IsMin)
    {
      if (IsRow)
        return (IsMin ? FindRow(Matrix, true) : FindRow(Matrix, false));
      else
        return (IsMin ? FindColumn(Matrix, true) : FindColumn(Matrix, false));
    }
    public static int MaxEl(int[,] Matrix)
    {
      int Maximum = int.MinValue;
      for (int i = 0; i < Matrix.GetLength(0); i++)
        for (int k = 0; k < Matrix.GetLength(1); k++)
          if (Matrix[i, k] > Maximum)
            Maximum = Matrix[i, k];
      return Maximum;
    }
    public static int MinEl(int[,] Matrix)
    {
      int Minimum = int.MaxValue;
      for (int i = 0; i < Matrix.GetLength(0); i++)
        for (int k = 0; k < Matrix.GetLength(1); k++)
          if (Matrix[i, k] < Minimum)
            Minimum = Matrix[i, k];
      return Minimum;
    }
    public static int FindRow(int[,] Matrix, bool Min)
    {
      bool flag = true;
      int RowNumber = 0;
        for (int i = 0; i < Matrix.GetLength(0) && flag; i++)        
          for (int k = 0; k < Matrix.GetLength(1); k++)
            if (Matrix[i, k] == (Min ? MinEl(Matrix) : MaxEl(Matrix)))
            {
              RowNumber = i;
              flag = false;
              break;
            }        
      return RowNumber;
    }

    public static int FindColumn(int[,] Matrix, bool Min)
    {
      bool flag = true;
      int ColumnNumber = 0;
      for (int i = 0; i < Matrix.GetLength(0) && flag; i++)      
        for (int k = 0; k < Matrix.GetLength(1); k++)
          if (Matrix[i, k] == (Min ? MinEl(Matrix) : MaxEl(Matrix)))
          {
            flag = false;
            ColumnNumber = k;
            break;
          }      
      return ColumnNumber;
    }
    public static int[,] DelRow(int[,] Matrix, bool Min)
    {
      if (Min) //Удалить строку с минимальным
      {
        for (int i = 0; i < Matrix.GetLength(0); i++)
        Matrix[FindRow(Matrix, true), i] = 0;
        return Matrix;
      }
      else //Удалить строку с максимальным
      {
        return Matrix;
      }
    }
    public static int[,] DelCol(int[,] Matrix, bool Min)
    {
      if (Min) //Удалить столбец с минимальным
      {
        return Matrix;
      }
      else //Удалить столбец с максимальным
      {
        return Matrix;
      }
    }
  }
}
