using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;
using System.Windows.Controls;

namespace WPFGraphics
{
  class LoTVLogics
  {
    public static void drawTriangle(
            Point3D p0, Point3D p1, Point3D p2, Color color, Viewport3D viewport)
    {
      MeshGeometry3D mesh = new MeshGeometry3D();

      mesh.Positions.Add(p0);
      mesh.Positions.Add(p1);
      mesh.Positions.Add(p2);

      mesh.TriangleIndices.Add(0);
      mesh.TriangleIndices.Add(1);
      mesh.TriangleIndices.Add(2);

      SolidColorBrush brush = new SolidColorBrush();
      brush.Color = color;
      Material material = new DiffuseMaterial(brush);

      GeometryModel3D geometry = new GeometryModel3D(mesh, material);
      ModelUIElement3D model = new ModelUIElement3D();
      model.Model = geometry;

      viewport.Children.Add(model);
    }
    static int A = 10, B = 10;
    public static Point3D getPositionTor(double R, double r, double a, double v)
    {

      double sinB = Math.Sin(B * Math.PI / 180);
      double cosB = Math.Cos(B * Math.PI / 180);
      double sinA = Math.Sin(A * Math.PI / 180);
      double cosA = Math.Cos(A * Math.PI / 180);

      Point3D point = new Point3D();
      point.X = (R + r * cosA) * cosB;
      point.Y = r * sinA;
      point.Z = -(R + r * cosA) * sinB;

      return point;
    }
    public static void drawTor(Point3D center, double R, double r, int N, int n, Color color, Viewport3D mainViewport)
    {
      if (n < 2 || N < 2)
      {
        return;
      }

      Model3DGroup tor = new Model3DGroup();
      Point3D[,] points = new Point3D[N, n];

      for (int i = 0; i < N; i++)
      {
        for (int j = 0; j < n; j++)
        {
          points[i, j] = getPositionTor(R, r, i * 360 / (N - 1), j * 360 / (n - 1));
          points[i, j] += (Vector3D)center;
        }
      }

      Point3D[] p = new Point3D[4];
      for (int i = 0; i < N - 1; i++)
      {
        for (int j = 0; j < n - 1; j++)
        {
          p[0] = points[i, j];
          p[1] = points[i + 1, j];
          p[2] = points[i + 1, j + 1];
          p[3] = points[i, j + 1];
          drawTriangle(p[0], p[1], p[2], color, mainViewport);
          drawTriangle(p[2], p[3], p[0], color, mainViewport);

        }
      }
    }
  }
  class LoTVModel
  {
    
    public byte AxisTurn = 1;
    public int I2 = 0, J2 = 0;
    double x0 = 0, y0 = 0, z0 = 0;
    public double
      fxc = 0.5,
      fyc = 0.5,
      fzc = 0.5,
      Xmin = -2,
      Xmax = 2,
      Ymin = -2,
      Ymax = 2;
    double Alf = -3, Bet = 23;
    public double Angle;
    LoTVPoint Center;
    LoTVPoint[] Points;
    LoTVEdge[] Edges;
    public Line[] Lines;
    LoTVPolygon[] Polygons;
    Point3D[] points;
    public int PLength;
    public int LLength;
    public int ELength;
    public int RLength;
    public LoTVModel()
    {
      Points = new LoTVPoint[0];
      PLength = 0;
      Edges = new LoTVEdge[0];
      ELength = 0;
      Polygons = new LoTVPolygon[0];
      RLength = 0;
    }
    double[,] Multiplication(double[,] a, double[,] b)
    {

      double[,] r = new double[a.GetLength(0), b.GetLength(1)];
      for (int i = 0; i < a.GetLength(0); i++)
        for (int j = 0; j < b.GetLength(1); j++)
          for (int k = 0; k < b.GetLength(0); k++)
            r[i, j] += a[i, k] * b[k, j];
      return r;
    }
    static void/*double[,]*/ Multiplication(double[,] a, double angle)
    {
      /*double[,] r = new double[a.GetLength(0), b.GetLength(1)];
      for (int i = 0; i < a.GetLength(0); i++)
        for (int j = 0; j < b.GetLength(1); j++)
          for (int k = 0; k < b.GetLength(0); k++)
            r[i, j] += a[i, k] * b[k, j];
      return r;*/
    }
    public void Rotatick()
    {
      double[,] ConVec = new double[1, 4];
      /*ConVec[0, 0] = Center.X;
      ConVec[0, 1] = Center.Y;
      ConVec[0, 2] = Center.Z;*/
      ConVec[0, 3] = 1;

      double[,] Rx = new double[4, 4];
      double cos = Math.Cos(Angle);
      double sin = Math.Sin(Angle);
      for (int i = 0; i < 4; i++)
        for (int j = 0; j < 4; j++)
          Rx[i, j] = 0;
      Rx[0, 0] = Rx[3, 3] = 1;
      Rx[1, 1] = Rx[2, 2] = cos;
      Rx[1, 2] = sin;
      Rx[2, 1] = -sin;
      for (int i = 0; i < PLength; i++)
      {
        ConVec[0, 0] = Points[i].X;
        ConVec[0, 1] = Points[i].Y;
        ConVec[0, 2] = Points[i].Z;
        ConVec = Multiplication(ConVec, Rx);
        Points[i].X = ConVec[0, 0];
        Points[i].Y = ConVec[0, 1];
        Points[i].Z = ConVec[0, 2];
      }

    }
    public void GeLoTVPoint(LoTVPoint Input, out double Outx, out double Outy)
    {
      double cos = Math.Cos(Alf);
      double sin = Math.Sin(Alf);
      double x = Input.X;
      double y = Input.Y;
      double z = Input.Z;
      x = (x - x0) * cos - (y - y0) * sin;
      y = ((x - x0) * sin + (y - y0) * cos) * cos - (z - z0) * sin;
      z = ((x - x0) * sin + (y - y0) * cos) * sin + (z - z0) * cos;
      Outx = x / ((z / 0.5) + 1);
      Outy = y / ((z / 0.5) + 1);
    }
    public void SetAngle(double x, double y)
    {
      Alf = Math.Atan2(y, x);
      Bet = Math.Sqrt((x / 10) * (x / 10) + (y / 10) * (y / 10));
    }
    public void Parse(string Input)
    {
      double AllX = 0, AllY = 0, AllZ = 0;
      double X, Y, Z;
      string[] Arr = Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
      int Length = Arr.Length;
      string[] Row;
      for (int i = 0; i < Length; i++)
      {
        if (Arr[i] != "" && Arr[i][0] != '#')
          switch (Arr[i].Substring(0, 2))
          {
            case "v ":
              Row = Arr[i].Split(null as string[], StringSplitOptions.RemoveEmptyEntries);
              Array.Resize(ref Points, ++PLength);
              X = double.Parse(Row[1], System.Globalization.CultureInfo.InvariantCulture);
              Y = double.Parse(Row[2], System.Globalization.CultureInfo.InvariantCulture);
              Z = double.Parse(Row[3], System.Globalization.CultureInfo.InvariantCulture);
              AllX += X;
              AllY += Y;
              AllZ += Z;
              Points[PLength - 1] = new LoTVPoint(X, Y, Z);
              break;
            case "f ":
              Row = Arr[i].Split(' ');
              string[] Temp;
              int[] F = new int[3];
              for (int k = 1; k <= 3; k++)
              {
                Temp = Row[k].Split('/');
                F[k - 1] = int.Parse(Temp[0]);
              }
              Array.Resize(ref Polygons, ++RLength);
              Polygons[RLength - 1] = new LoTVPolygon(F[0], F[1], F[2]);
              Array.Resize(ref Edges, ELength + 3);
              ELength += 3;
              Edges[ELength - 3] = new LoTVEdge(F[0], F[1]);
              Edges[ELength - 2] = new LoTVEdge(F[1], F[2]);
              Edges[ELength - 1] = new LoTVEdge(F[2], F[0]);
              break;
          }
      }
      Center = new LoTVPoint(AllX / PLength, AllY / PLength, AllZ / PLength);
    }
    public void Draw()
    {
      Rotatick();
      //using (Graphics g = Graphics.FromImage(Canv))
      LLength = 0;
      Lines = new Line[0];
      {
        //  g.Clear(Colors.Black);
        Point P0, P1;
        P0 = IJ(new LoTVPoint(-300, 0, 0));
        P1 = IJ(new LoTVPoint(300, 0, 0));
        Array.Resize(ref Lines, ++LLength);
        Lines[LLength - 1] = new Line();
        Lines[LLength - 1].Stroke = Brushes.White;
        Lines[LLength - 1].X1 = P0.X;
        Lines[LLength - 1].Y1 = P0.Y;
        Lines[LLength - 1].X2 = P1.X;
        Lines[LLength - 1].Y2 = P1.Y;
        //  g.DrawLine(Pen.Red, P0, P1);
        P0 = IJ(new LoTVPoint(0, -300, 0));
        P1 = IJ(new LoTVPoint(0, 300, 0));
        Array.Resize(ref Lines, ++LLength);
        Lines[LLength - 1] = new Line();
        Lines[LLength - 1].Stroke = Brushes.White;
        Lines[LLength - 1].X1 = P0.X;
        Lines[LLength - 1].Y1 = P0.Y;
        Lines[LLength - 1].X2 = P1.X;
        Lines[LLength - 1].Y2 = P1.Y;
        // g.DrawLine(Pen.Green, P0, P1);
        P0 = IJ(new LoTVPoint(0, 0, -300));
        P1 = IJ(new LoTVPoint(0, 0, 300));
        Array.Resize(ref Lines, ++LLength);
        Lines[LLength - 1] = new Line();
        Lines[LLength - 1].Stroke = Brushes.White;
        Lines[LLength - 1].X1 = P0.X;
        Lines[LLength - 1].Y1 = P0.Y;
        Lines[LLength - 1].X2 = P1.X;
        Lines[LLength - 1].Y2 = P1.Y;
        //g.DrawLine(Blue, P0, P1);
        for (int i = 0; i < ELength; i++)
        {
          P0 = IJ(Points[Edges[i].FP - 1]); // 0*0
          P1 = IJ(Points[Edges[i].SP - 1]);
          Array.Resize(ref Lines, ++LLength);
          Lines[LLength - 1] = new Line();
          Lines[LLength - 1].Stroke = Brushes.White;
          Lines[LLength - 1].X1 = P0.X;
          Lines[LLength - 1].Y1 = P0.Y;
          Lines[LLength - 1].X2 = P1.X;
          Lines[LLength - 1].Y2 = P1.Y;
          //  g.DrawLine(Pen.White, P0, P1);
        }
      }
    }
    LoTVPoint Rotate(LoTVPoint P)
    {
      LoTVPoint Result = new LoTVPoint((P.X - fxc) * Math.Cos(Alf) - (P.Y - fyc) * Math.Sin(Alf),
        ((P.X - fxc) * Math.Sin(Alf) + (P.Y - fyc) * Math.Cos(Alf)) * Math.Cos(Bet) - (P.Z - fzc) * Math.Sin(Bet),
        ((P.X - fxc) * Math.Sin(Alf) + (P.Y - fyc) * Math.Cos(Alf)) * Math.Sin(Bet) + (P.Z - fzc) * Math.Cos(Bet));
      return Result;
    }
    private Point IJ(LoTVPoint P)
    {
      double Xn = (P.X - fxc) * Math.Cos(Alf) - (P.Y - fyc) * Math.Sin(Alf);
      double Yn = ((P.X - fxc) * Math.Sin(Alf) + (P.Y - fyc) * Math.Cos(Alf)) * Math.Cos(Bet) - (P.Z - fzc) * Math.Sin(Bet);
      double Zn = ((P.X - fxc) * Math.Sin(Alf) + (P.Y - fyc) * Math.Cos(Alf)) * Math.Sin(Bet) + (P.Z - fzc) * Math.Cos(Bet);
      //Xn = Xn / (Zn * FA + 1);
      //Yn = Yn / (Zn * FA + 1);
      int X = (int)Math.Round(I2 * (Xn - Xmin) / (Xmax - Xmin));
      int Y = (int)Convert.ToInt32(J2 * (Yn - Ymax) / (Ymin - Ymax));
      return new Point(X, Y);
    }
    private double XX(int I)
    {
      return Xmin + I * (Xmax - Xmin) / I2;
    }
    private double YY(int J)
    {
      return Ymax + J * (Ymin - Ymax) / J2;
    }
  }
  class LoTVPoint
  {
    public double X, Y, Z;
    public LoTVPoint(double X, double Y, double Z)
    {
      this.X = X;
      this.Y = Y;
      this.Z = Z;
    }
  }
  class LoTVEdge
  {
    public int FP, SP;
    public LoTVEdge(int FP, int SP)
    {
      this.FP = FP;
      this.SP = SP;
    }
  }
  class LoTVPolygon
  {
    public int FP, SP, TP;
    public LoTVPolygon(int FP, int SP, int TP)
    {
      this.FP = FP;
      this.SP = SP;
      this.TP = SP;
    }
  }
}
