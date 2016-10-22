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
      public int FP, SP, TP, FrP;
      public int NF, NS, NT, NFr;
      public double[] Vector;
      public int Type;
      public int MaxZ;
      public double LightCoeff;
      public MyPolygon(int FP, int SP, int TP)
      {
        Type = 3;
        this.FP = FP;
        this.SP = SP;
        this.TP = TP;
      }
      public MyPolygon(int FP, int SP, int TP, int FrP)
      {
        Type = 4;
        this.FP = FP;
        this.SP = SP;
        this.TP = TP;
        this.FrP = FrP;
      }
    }
  }
}
