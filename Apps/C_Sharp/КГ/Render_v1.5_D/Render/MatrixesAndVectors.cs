using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Render
{
  public static class MatrixesAndVectors
  {
    public static double[] VectorMultiply(double[] Vector, Matrix Matrix)
    {
      double[] Out = new double[4];
      Out[0] = Vector[0] * Matrix.MatrixArr[0, 0] + Vector[1] * Matrix.MatrixArr[1, 0] + Vector[2] * Matrix.MatrixArr[2, 0] + Vector[3] * Matrix.MatrixArr[3, 0];
      Out[1] = Vector[0] * Matrix.MatrixArr[0, 1] + Vector[1] * Matrix.MatrixArr[1, 1] + Vector[2] * Matrix.MatrixArr[2, 1] + Vector[3] * Matrix.MatrixArr[3, 1];
      Out[2] = Vector[0] * Matrix.MatrixArr[0, 2] + Vector[1] * Matrix.MatrixArr[1, 2] + Vector[2] * Matrix.MatrixArr[2, 2] + Vector[3] * Matrix.MatrixArr[3, 2];
      Out[3] = Vector[0] * Matrix.MatrixArr[0, 3] + Vector[1] * Matrix.MatrixArr[1, 3] + Vector[2] * Matrix.MatrixArr[2, 3] + Vector[3] * Matrix.MatrixArr[3, 3];
      if (Out[3] != 1)
      {
        Out[0] /= Out[3];
        Out[1] /= Out[3];
        Out[2] /= Out[3];
        Out[3] = 1;
      }
      return Out;
    }
    public static Structures.MyPoint VectorMultiply(Structures.MyPoint Vector, Matrix Matrix)
    {
      double[] Out = new double[4];
      Out[0] = Vector.X * Matrix.MatrixArr[0, 0] + Vector.Y * Matrix.MatrixArr[1, 0] + Vector.Z * Matrix.MatrixArr[2, 0] + Matrix.MatrixArr[3, 0];
      Out[1] = Vector.X * Matrix.MatrixArr[0, 1] + Vector.Y * Matrix.MatrixArr[1, 1] + Vector.Z * Matrix.MatrixArr[2, 1] + Matrix.MatrixArr[3, 1];
      Out[2] = Vector.X * Matrix.MatrixArr[0, 2] + Vector.Y * Matrix.MatrixArr[1, 2] + Vector.Z * Matrix.MatrixArr[2, 2] + Matrix.MatrixArr[3, 2];
      Out[3] = Vector.X * Matrix.MatrixArr[0, 3] + Vector.Y * Matrix.MatrixArr[1, 3] + Vector.Z * Matrix.MatrixArr[2, 3] + Matrix.MatrixArr[3, 3];
      if (Out[3] != 1)
      {
        Out[0] /= Out[3];
        Out[1] /= Out[3];
        Out[2] /= Out[3];
        Out[3] = 1;
      }
      return new Structures.MyPoint(Out[0], Out[1], Out[2]);
    }
    public static double[] VectorNormalize(double[] Input)
    {
      double Length = 1;
      Length = VectorGetLength(Input);
      return new double[3] { Input[0] / Length, Input[1] / Length, Input[2] / Length };
    }
    public static double[] VectorCrossProduct(double[] A, double[] B)
    {
      double[] C = new double[3];
      C[0] = A[1] * B[2] - A[2] * B[1];
      C[1] = A[2] * B[0] - A[0] * B[2];
      C[2] = A[0] * B[1] - A[1] * B[0];
      return C;
    }
    public static double VectorGetLength(double[] Arr)
    {
      return Math.Sqrt(Arr[0] * Arr[0] + Arr[1] * Arr[1] + Arr[2] * Arr[2]);
    }
    public static double VectorGetLength(double[] A, double[] B)
    {
      double[] Arr = Normalize(new double[3] {
      B[0] - A[0],
      B[1] - A[1],
      B[2] - A[1]});
      return Math.Sqrt(Arr[0] * Arr[0] + Arr[1] * Arr[1] + Arr[2] * Arr[2]);
    }
    public static double VectorDotProduct(double[] A, double[] B)
    {
      return A[0] * B[0] + A[1] * B[1] + A[2] * B[2];
    }
    public static double[] Normalize(double[] Input)
    {
      double Length = 1;
      Length = VectorGetLength(Input);
      if (Length == 0)
        return new double[3] { 0, 0, 0 };
      else
        return new double[3] { Input[0] / Length, Input[1] / Length, Input[2] / Length };
    }
    public static double GetCosBetweenVectors(double[] A, double [] B)
    {
      double Temp = VectorGetLength(A) * VectorGetLength(B);
      if (Temp == 0)
        return 0;
      else
        return VectorDotProduct(Normalize(A), Normalize(B)) / Temp;
    }

    public class Matrix
    {
      public double[,] MatrixArr;
    }
    public class MatrixProjection : Matrix
    {
      public MatrixProjection(int Axis)
      {
        MatrixArr = new double[4, 4]
        {
          {Axis == 1 ? 0 : 1,0,0,0 },
          {0,Axis == 2 ? 0 : 1,0,0 },
          {0,0,Axis == 3 ? 0 : 1,0 },
          {0,0,0,1 }
        };
      }
    }
    public class MatrixRotation : Matrix
    {
      public MatrixRotation(double Angle, int Type)   //1 - по Х, 2 - по У, 3 - по Z
      {
        double sin = Math.Sin(Angle);
        double cos = Math.Cos(Angle);

        MatrixArr = new double[4, 4]
        {
          {Type == 1 ? 1    : cos, Type == 3 ? sin : 0 , Type == 2 ? -sin :   0,0 },
          {Type == 3 ? -sin : 0  , Type == 2 ? 1 : cos , Type == 1 ?  sin :   0,0 },
          {Type == 2 ? sin  : 0  , Type == 1 ? -sin : 0, Type == 3 ? 1    : cos,0 },
          {           0          ,           0         ,           0           ,1 }
        };

      }
    }
    public class MatrixTranslation : Matrix
    {
      public MatrixTranslation(double x, double y, double z)
      {
        MatrixArr = new double[4, 4]
        {
          {1,0,0,0 },
          {0,1,0,0 },
          {0,0,1,0 },
          {x,y,z,1 }
        };
      }
    }
    public class MatrixSquashing : Matrix
    {
      public MatrixSquashing(double sx, double sy, double sz)
      {
        MatrixArr = new double[4, 4]
        {
          {sx,0,0,0 },
          {0,sy,0,0 },
          {0,0,sz,0 },
          {0,0,0,1 }
        };
      }
      public MatrixSquashing(double allS)
      {
        MatrixArr = new double[4, 4]
        {
          {1,0,0,0 },
          {0,1,0,0 },
          {0,0,1,0 },
          {0,0,0,allS }
        };
      }
    }
    public class MatrixReflection : Matrix
    {
      public MatrixReflection(int Type)
      {

        MatrixArr = new double[4, 4]
        {
          {Type == 1 ? -1 : 1,0,0,0 },
          {0,Type == 2 ? -1 : 1,0,0 },
          {0,0,Type == 3 ? -1 : 1,0 },
          {0,0,0,1 }
        };
      }
    }
  }
}
