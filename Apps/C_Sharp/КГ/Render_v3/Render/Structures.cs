using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Render
{
  public class Structures
  {
    public class MyPoint
    {
      public double X, Y, Z;
      public MyPoint(double X, double Y, double Z)
      {
        this.X = X;
        this.Y = Y;
        this.Z = Z;
      }
    }
    public class MyEdge
    {
      public int FP, SP;
      public MyEdge(int FP, int SP)
      {
        this.FP = FP;
        this.SP = SP;
      }
    }
    public class MyPolygon
    {
      public double CameraDist;
      public double CameraCoeff;
      public int firstPoint, secondPoint, thirdPoint, fourthPoint;
      public double[] Vector;
      public int Type;
      public double[] Equation;
      public double LightCoeff;
      public MyPolygon(int FP, int SP, int TP)
      {
        Type = 3;
        this.firstPoint = FP;
        this.secondPoint = SP;
        this.thirdPoint = TP;
      }
      public MyPolygon(int FP, int SP, int TP, int FrP)
      {
        Type = 4;
        this.firstPoint = FP;
        this.secondPoint = SP;
        this.thirdPoint = TP;
        this.fourthPoint = FrP;
      }
    }
  }
}
