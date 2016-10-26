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
      public double x, y, z;
      public MyPoint(double X, double Y, double Z)
      {
        x = X;
        y = Y;
        z = Z;
      }
    }
    public class MyEdge
    {
      public int P1, P2;
      public MyEdge(int FP, int SP)
      {
        this.P1 = FP;
        this.P2 = SP;
      }
    }
    public class MyPolygon
    {
      public double cameraDist;
      public double cameraCoeff;
      public int firstPoint, secondPoint, thirdPoint, fourthPoint;
      public double MaxZ;
      public double[] Vector;
      public int Type;
      public double[] Equation;
      public double LightCoeff;
      public MyPolygon(int P1, int P2, int P3)
      {
        Type = 3;
        this.firstPoint = P1;
        this.secondPoint = P2;
        this.thirdPoint = P3;
      }
      public MyPolygon(int P1, int P2, int P3, int P4)
      {
        Type = 4;
        this.firstPoint = P1;
        this.secondPoint = P2;
        this.thirdPoint = P3;
        this.fourthPoint = P4;
      }
      
    }
  }
}
