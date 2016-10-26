using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Render
{
  public static class VectorOperations
  {
    public static double[] VectorMultiply(double[] Vector, Matrices.Matrix Matrix)
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
    public static Structures.MyPoint VectorMultiply(Structures.MyPoint Vector, Matrices.Matrix Matrix)
    {
      double[] Out = new double[4];
      Out[0] = Vector.x * Matrix.MatrixArr[0, 0] + Vector.y * Matrix.MatrixArr[1, 0] + Vector.z * Matrix.MatrixArr[2, 0] + Matrix.MatrixArr[3, 0];
      Out[1] = Vector.x * Matrix.MatrixArr[0, 1] + Vector.y * Matrix.MatrixArr[1, 1] + Vector.z * Matrix.MatrixArr[2, 1] + Matrix.MatrixArr[3, 1];
      Out[2] = Vector.x * Matrix.MatrixArr[0, 2] + Vector.y * Matrix.MatrixArr[1, 2] + Vector.z * Matrix.MatrixArr[2, 2] + Matrix.MatrixArr[3, 2];
      Out[3] = Vector.x * Matrix.MatrixArr[0, 3] + Vector.y * Matrix.MatrixArr[1, 3] + Vector.z * Matrix.MatrixArr[2, 3] + Matrix.MatrixArr[3, 3];
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
    public static double GetCosBetweenVectors(double[] A, double[] B)
    {
      double Temp = VectorGetLength(A) * VectorGetLength(B);
      if (Temp == 0)
        return 0;
      else
        return VectorDotProduct(Normalize(A), Normalize(B)) / Temp;
    }
  }
}
