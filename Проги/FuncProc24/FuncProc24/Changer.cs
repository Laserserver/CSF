using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuncProc24
{
  class Changer
  {
    public static int[,] Change(int[,] Matrix, bool FromFirst, bool ToFirst)
    {
      if (FromFirst)
        return (ToFirst ? First(Matrix, true) : First(Matrix, false));
      else
        return (ToFirst ? Last(Matrix, true) : Last(Matrix, false));
    }
    public static int[,] First(int[,] Matrix, bool ToFirst)
    {
      int[] NewAr2 = new int[Matrix.GetLength(0)];
      int[] NewArr = new int[Matrix.GetLength(0)];
      int Mark = 0;
      bool flag = true;
      for (int k = 0; k < Matrix.GetLength(0) - 1; k++)
        NewArr[k] = Matrix[k, 0]; //Запись первого столбца в NewArr
      if (ToFirst)
      {
        for (int i = 0; i < Matrix.GetLength(1) - 1; i++)
          if (flag)
            for (int k = 0; k < Matrix.GetLength(0) - 1; k++)
              if (Matrix[i, k] < 0)
                break;
              else
                if (Matrix[Matrix.GetLength(0) - 1, k] > 0)
                {
                  flag = false;
                  Mark = k;
                  break;
                }
        for (int i = 0; i < Matrix.GetLength(0) - 1; i++)
        {
          NewAr2[i] = Matrix[i, Mark];
          Matrix[i, Mark] = Matrix[i, 0];
          Matrix[i, 0] = NewArr[i];  //Перезапись первого столбца матрицы            
        }
      }
      else
      {
        for (int i = Matrix.GetLength(1) - 1; i > 0; i++)
          if (flag)
            for (int k = 0; k < Matrix.GetLength(0) - 1; k++)
              if (Matrix[k, i] < 0)
                break;
              else
                if (Matrix[Matrix.GetLength(0) - 1, i] > 0)
                {
                  flag = false;
                  Mark = i;
                  break;
                }
        for (int i = 0; i < Matrix.GetLength(0) - 1; i++)
        {
          NewAr2[i] = Matrix[i, Mark];
          Matrix[i, Mark] = Matrix[i, 0];
          Matrix[i, 0] = NewArr[i];           
        }
      }
      return Matrix;
    }
    public static int[,] Last(int[,] Matrix, bool ToFirst)
    {
      int[] NewAr2 = new int[Matrix.GetLength(0)];
      int[] NewArr = new int[Matrix.GetLength(0)];
      int Mark = 0;
      bool flag = true;
      for (int k = 0; k < Matrix.GetLength(1) - 1; k++)
        NewArr[k] = Matrix[k, Matrix.GetLength(0) - 1];  //Запись последнего столбца в NewArr
      if (ToFirst)
      {
        for (int i = 0; i < Matrix.GetLength(1) - 1; i++)
          if (flag)
            for (int k = 0; k < Matrix.GetLength(0) - 1; k++)
              if (Matrix[i, k] < 0)
                break;
              else
                if (Matrix[Matrix.GetLength(0) - 1, k] > 0)
                {
                  flag = false;
                  Mark = i;
                  break;
                }
        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
          NewAr2[i] = Matrix[i, Mark];
          Matrix[i, Mark] = Matrix[i, Matrix.GetLength(1) - 1];
          Matrix[i, Matrix.GetLength(1) - 1] = NewArr[i];  //Перезапись последнего столбца матрицы            
        }
      }
      else
      {
        for (int i = Matrix.GetLength(1) - 1; i > 0; i++)
          if (flag)
            for (int k = 0; k < Matrix.GetLength(0) - 1; k++)
              if (Matrix[k, i] < 0)
                break;
              else
                if (Matrix[Matrix.GetLength(0) - 1, i] > 0)
                {
                  flag = false;
                  Mark = i;
                  break;
                }
        for (int i = 0; i < Matrix.GetLength(0) - 1; i++)
        {
          NewAr2[i] = Matrix[i, Mark];
          Matrix[i, Mark] = Matrix[i, Matrix.GetLength(1) - 1];
          Matrix[i, Matrix.GetLength(1) - 1] = NewArr[i];
        }
      }
      return Matrix;
    }
  }
}
