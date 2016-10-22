using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TempGraphics
{
  class LoTVModel
  {
    public double[] LightVector;
    public double Zoom;
    public double ZoomCoeff;
    public byte AxisTurn = 1;
    public int I2 = 0, J2 = 0;
    public double xRotation = 0.0;
    public double yRotation = 0.0;
    public double zRotation = 0.0;
    public double
      fxc = 0.5,
      fyc = 0.5,
      fzc = 0.5,
      Xmin = -2,
      Xmax = 2,
      Ymin = -2,
      Ymax = 2;
    double Alf = 0, Bet = 13;
    //public double Angle;
    LoTVPoint Center;
    public Bitmap Canv;
    LoTVPoint Camera;
    LoTVPoint[] Points;
    LoTVEdge[] Edges;
    LoTVPolygon[] Polygons;
    LoTVPoint[] Normals;
    public int NLength;
    public int PLength;
    public int ELength;
    public int RLength;
    public LoTVModel()
    {
      Points = new LoTVPoint[0];
      PLength = 0;
      Edges = new LoTVEdge[0];
      ELength = 0;
      Polygons = new LoTVPolygon[0];
      LightVector = new double[3] { 0, 1, 1 };
      RLength = 0;
      Normals = new LoTVPoint[0];
      NLength = 0;
      Camera = new LoTVPoint(50, 50, 50);
      ZoomCoeff = 1;
    }
    public void Zooming()
    {
      double[] Arr;
      for (int i = 0; i < RLength; i++)
      {
        Arr = ZoomVect(new double[3] { Points[Polygons[i].FP - 1].X, Points[Polygons[i].FP - 1].Y, Points[Polygons[i].FP - 1].X });
        Points[Polygons[i].FP - 1].X = Arr[0];
        Points[Polygons[i].FP - 1].Y = Arr[1];
        Points[Polygons[i].FP - 1].Z = Arr[2];
        Arr = ZoomVect(new double[3] { Points[Polygons[i].SP - 1].X, Points[Polygons[i].SP - 1].Y, Points[Polygons[i].SP - 1].X });
        Points[Polygons[i].SP - 1].X = Arr[0];
        Points[Polygons[i].SP - 1].Y = Arr[1];
        Points[Polygons[i].SP - 1].Z = Arr[2];
        Arr = ZoomVect(new double[3] { Points[Polygons[i].TP - 1].X, Points[Polygons[i].TP - 1].Y, Points[Polygons[i].TP - 1].X });
        Points[Polygons[i].TP - 1].X = Arr[0];
        Points[Polygons[i].TP - 1].Y = Arr[1];
        Points[Polygons[i].TP - 1].Z = Arr[2];
        if (Polygons[i].Type == 4)
        {
          Arr = ZoomVect(new double[3] { Points[Polygons[i].FrP - 1].X, Points[Polygons[i].FrP - 1].Y, Points[Polygons[i].FrP - 1].X });
          Points[Polygons[i].FrP - 1].X = Arr[0];
          Points[Polygons[i].FrP - 1].Y = Arr[1];
          Points[Polygons[i].FrP - 1].Z = Arr[2];
        }
      }
    }
    private double[] ZoomVect(double[] Input)
    {
      return new double[3] { Input[0] * ZoomCoeff, Input[1] / ZoomCoeff, Input[2] / ZoomCoeff };
    }
    public double GetVectorLength(double[] Arr)
    {
      return Math.Sqrt(Arr[0] * Arr[0] + Arr[1] * Arr[1] + Arr[2] * Arr[2]);
    }
    public double DotProduct(double[] A, double[] B)
    {
      return A[0] * B[0] + A[1] * B[1] + A[2] * B[2];
    }
    public void Vectors()
    {
      double Len = 0;
      for (int i = 0; i < RLength; i++)
      {
        Polygons[i].Vector = CrossProduct(new double[] {
          Points[Polygons[i].SP - 1].X - Points[Polygons[i].FP - 1].X,
          Points[Polygons[i].SP - 1].Y - Points[Polygons[i].FP - 1].Y,
          Points[Polygons[i].SP - 1].Z - Points[Polygons[i].FP - 1].Z}, new double[] {
          Points[Polygons[i].TP - 1].X - Points[Polygons[i].FP - 1].X,
          Points[Polygons[i].TP - 1].Y - Points[Polygons[i].FP - 1].Y,
          Points[Polygons[i].TP - 1].Z - Points[Polygons[i].FP - 1].Z});
        Len = Math.Sqrt(Polygons[i].Vector[0] * Polygons[i].Vector[0] + Polygons[i].Vector[1] * Polygons[i].Vector[1] + Polygons[i].Vector[2] * Polygons[i].Vector[2]);
        Polygons[i].Vector[0] = Polygons[i].Vector[0] / Len;
        Polygons[i].Vector[1] = Polygons[i].Vector[1] / Len;
        Polygons[i].Vector[2] = Polygons[i].Vector[2] / Len;
      }
    }
    public double[] Normalize(double[] Input)
    {
      double Length = 1;
      Length = GetVectorLength(Input);
      return new double[3] { Input[0] / Length, Input[1] / Length, Input[2] / Length };
    }
    public double[] CrossProduct(double[] A, double[] B)
    {
      double[] C = new double[3];
      C[0] = A[1] * B[2] - A[2] * B[1];
      C[1] = A[2] * B[0] - A[0] * B[2];
      C[2] = A[0] * B[1] - A[1] * B[0];
      return C;
    }
    private void SortPolygons()
    {
      int j;
      int step = RLength / 2;
      while (step > 0)
      {
        for (int i = 0; i < (RLength - step); i++)
        {
          j = i;
          while ((j >= 0) && (Polygons[j].CameraDist <= Polygons[j + step].CameraDist))
          {
            LoTVPolygon tmp = Polygons[j];
            Polygons[j] = Polygons[j + step];
            Polygons[j + step] = tmp;
            j -= step;
          }
        }
        step = step / 2;
      }
    }
    public void Coeffs()
    {
      for (int i = 0; i < RLength; i++)
      {
        Polygons[i].LightCoeff = DotProduct(Normalize(LightVector), Polygons[i].Vector) / (GetVectorLength(LightVector) * GetVectorLength(Polygons[i].Vector));//Math.Acos(Scalar / (Alf * Bet)) / 18 * 3.14;
        Polygons[i].CameraCoeff = GetVectorLength(Normalize(new double[3] { Polygons[i].Vector[0] - LightVector[0], Polygons[i].Vector[1] - LightVector[1], Polygons[i].Vector[2] - LightVector[2] }));//Math.Acos(Scalar / (Alf * Bet)) / 180 * 3.14;/
        Polygons[i].CameraDist = GetVectorLength(new double[3] {  //Camera.X, Polygons[i].Vector[1] - Camera.Y, Polygons[i].Vector[2] - Camera.Z }));
          /*Camera.X/**/LightVector[0] - (Points[Polygons[i].FP - 1].X + Points[Polygons[i].SP - 1].X + Points[Polygons[i].TP - 1].X) / 3,
          /*Camera.Y/**/LightVector[1] - (Points[Polygons[i].FP - 1].Y + Points[Polygons[i].SP - 1].Y + Points[Polygons[i].TP - 1].Y) / 3,
          /*Camera.Z/**/LightVector[2] - (Points[Polygons[i].FP - 1].Z + Points[Polygons[i].SP - 1].Z + Points[Polygons[i].TP - 1].Z) / 3 });
      }
    }
    /*static double[,] Multiplication(double[,] a, double[,] b)
    {
      double[,] r = new double[a.GetLength(0), b.GetLength(1)];
      for (int i = 0; i < a.GetLength(0); i++)
        for (int j = 0; j < b.GetLength(1); j++)
          for (int k = 0; k < b.GetLength(0); k++)
            r[i, j] += a[i, k] * b[k, j];
      return r;
    }
    /*static void double[,] Multiplication(double[,] a, double angle)
    {
      /*double[,] r = new double[a.GetLength(0), b.GetLength(1)];
      for (int i = 0; i < a.GetLength(0); i++)
        for (int j = 0; j < b.GetLength(1); j++)
          for (int k = 0; k < b.GetLength(0); k++)
            r[i, j] += a[i, k] * b[k, j];
      return r;
    }*/
    /*private double[,] GetMatrix(int type, bool inv, double[] Arr)
    {
      double[,] Matrix = new double[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
      double cos;
      double sin;
      int Mult = inv ? 1 : -1;  //скукожить-раскукожить
      switch (type)
      {
        case 1:  //Сдвиг
          Matrix[3, 0] = Mult * Arr[0];
          Matrix[3, 1] = Mult * Arr[1];
          Matrix[3, 2] = Mult * Arr[2];
          break;
        case 2:  //Скукоживание по Х
          cos = Math.Cos(Mult * Angle);
          sin = Math.Sin(Mult * Angle);
          Matrix[1, 1] = Matrix[2, 2] = cos;
          Matrix[1, 2] = sin;
          Matrix[2, 1] = -sin;
          break;
        case 3:  //Скукоживание по Y
          cos = Math.Cos(-Mult * Angle);
          sin = Math.Sin(-Mult * Angle);
          Matrix[0, 0] = Matrix[2, 2] = cos;
          Matrix[0, 2] = sin;
          Matrix[2, 0] = -sin;
          break;
        case 4:  //Скукоживание по Z
          cos = Math.Cos(Mult * Angle);
          sin = Math.Sin(Mult * Angle);
          Matrix[0, 0] = Matrix[1, 1] = cos;
          Matrix[0, 1] = sin;
          Matrix[1, 0] = -sin;
          break;
      }
      return Matrix;
    }*/
    public static LoTVPoint Translate(LoTVPoint points3D, LoTVPoint oldOrigin, LoTVPoint newOrigin)
    {
      LoTVPoint difference = new LoTVPoint(newOrigin.X - oldOrigin.X, newOrigin.Y - oldOrigin.Y, newOrigin.Z - oldOrigin.Z);
      points3D.X += difference.X;
      points3D.Y += difference.Y;
      points3D.Z += difference.Z;
      return points3D;
    }
    private LoTVPoint Rot(LoTVPoint Point, double Rotation, int Type)
    {
      double cos = Math.Cos(Rotation);
      double sin = Math.Sin(Rotation);
      switch (Type)
      {
        case 1:
          return new LoTVPoint(Point.X, Point.Y * cos + Point.Z * sin, Point.Y * -sin + Point.Z * cos);
        case 2:
          return new LoTVPoint(Point.X * cos + Point.Z * sin, Point.Y, Point.X * -sin + Point.Z * cos);
        case 3:
          return new LoTVPoint(Point.X * cos + Point.Y * sin, Point.X * -sin + Point.Y * cos, Point.Z);
      }
      return new LoTVPoint(Point.X, Point.Y, Point.Z);
    }
    public void Rotatick()
    {
      for (int i = 0; i < PLength; i++)
      {
        Points[i] = Rot(Points[i], xRotation, 1);
        Points[i] = Rot(Points[i], yRotation, 2);
        Points[i] = Rot(Points[i], zRotation, 3);
      }
    }
    /*public void MoveModel(int dist)
    {
      for (int i = 0; i < PLength; i++)
      { 
        switch (AxisTurn)
        {
          case 1:

            break;
          case 2:
            break;
          case 3:
            break;
        }
      }
    }
  /*  public Point GeLoTVPoint(LoTVPoint Input)
    {
      double cos = Math.Cos(Alf);
      double sin = Math.Sin(Alf);
      double x = Input.X;
      double y = Input.Y;
      double z = Input.Z;
      x = (x - x0) * cos - (y - y0) * sin;
      y = ((x - x0) * sin + (y - y0) * cos) * cos - (z - z0) * sin;
      z = ((x - x0) * sin + (y - y0) * cos) * sin + (z - z0) * cos;
      return new Point((int)Math.Round(I2 * (x / ((z / 0.5) + 1) - Xmin) / (Xmax - Xmin)), Convert.ToInt32(J2 * (y / ((z / 0.5) + 1) - Ymax) / (Ymin - Ymax)));
    }*/
    public void SetAngle(double x, double y)
    {
      Alf = Math.Atan2(y, x);
      Bet = Math.Sqrt((x / 10) * (x / 10) + (y / 10) * (y / 10));
    }
    public void Parse(string Input)
    {
      double AllX = 0, AllY = 0, AllZ = 0;
      double X, Y, Z;
      string[] Arr = Input.Split(new string[] { "\n\r", "\n" }, StringSplitOptions.None);
      int Length = Arr.Length;
      string[] Row;
      bool flag = true;
      int FType = 1;  //1 - _ 2 - _/_ 3 - _/_/_ 4 - _//_
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
            case "vn":
              Row = Arr[i].Split(null as string[], StringSplitOptions.RemoveEmptyEntries);
              X = double.Parse(Row[1], System.Globalization.CultureInfo.InvariantCulture);
              Y = double.Parse(Row[2], System.Globalization.CultureInfo.InvariantCulture);
              Z = double.Parse(Row[3], System.Globalization.CultureInfo.InvariantCulture);
              Array.Resize(ref Normals, ++NLength);
              Normals[NLength - 1] = new LoTVPoint(X, Y, Z);
              break;
            case "f ":
              if (flag)
              {
                string[] tmp = Arr[i].Split(' ');
                int Leng = tmp[1].Length;
                tmp = tmp[1].Split('/');
                if (tmp[1][0] != '/')
                  FType = tmp.Length;
                else
                  FType = 4;
                flag = false;
              }
              Row = Arr[i].Split(null as string[], StringSplitOptions.RemoveEmptyEntries);
              int RowLength = Row.Length - 1;
              string[] Temp;
              int[] F = new int[Row.Length - 1];
              int[] N = new int[Row.Length - 1];
              switch (FType)
              {
                case 1:
                  for (int k = 1; k <= RowLength; k++)
                    F[k - 1] = int.Parse(Row[k]);
                  break;
                case 2:
                  for (int k = 1; k <= RowLength; k++)
                  {
                    Temp = Row[k].Split('/');
                    F[k - 1] = int.Parse(Temp[0]);
                    //Здесь воткнуть массив для текстуры
                  }
                  break;
                case 3:
                  for (int k = 1; k <= RowLength; k++)
                  {
                    Temp = Row[k].Split('/');
                    F[k - 1] = int.Parse(Temp[0]);
                    //Здесь воткнуть массив для текстуры
                    N[k - 1] = int.Parse(Temp[2]);
                  }
                  break;
                case 4:
                  //Кек
                  break;
              }
              Array.Resize(ref Polygons, ++RLength);
              if (RowLength == 3)
                Polygons[RLength - 1] = new LoTVPolygon(F[0], F[1], F[2]);
              else
                Polygons[RLength - 1] = new LoTVPolygon(F[0], F[1], F[2], F[3]);

              if (FType > 2)
              {
                Polygons[RLength - 1].NF = N[0];
                Polygons[RLength - 1].NS = N[1];
                Polygons[RLength - 1].NT = N[2];
                if (FType == 4)
                  Polygons[RLength - 1].NFr = N[3];
              }
              switch (FType)
              {

                case 4:
                  Array.Resize(ref Edges, ELength + 4);
                  ELength += 4;
                  Edges[ELength - 4] = new LoTVEdge(F[0], F[1]);
                  Edges[ELength - 3] = new LoTVEdge(F[1], F[2]);
                  Edges[ELength - 2] = new LoTVEdge(F[2], F[3]);
                  Edges[ELength - 1] = new LoTVEdge(F[3], F[0]);
                  break;
                default:
                  Array.Resize(ref Edges, ELength + 3);
                  ELength += 3;
                  Edges[ELength - 3] = new LoTVEdge(F[0], F[1]);
                  Edges[ELength - 2] = new LoTVEdge(F[1], F[2]);
                  Edges[ELength - 1] = new LoTVEdge(F[2], F[0]);
                  break;
              }
              break;
          }
      }
      Vectors();
      Center = new LoTVPoint(AllX / PLength, AllY / PLength, AllZ / PLength);
    }
    public void Draw()
    {
      //Zooming();
      Rotatick();
      Vectors();
      Coeffs();
      SortPolygons();
      using (Graphics g = Graphics.FromImage(Canv))
      {
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.Clear(Color.Black);
        Point P0, P1, P2, P3, PG, PL;
        P0 = IJ(new LoTVPoint(-30, 0, 0));
        P1 = IJ(new LoTVPoint(30, 0, 0));
        g.DrawLine(Pens.Red, P0, P1);
        P0 = IJ(new LoTVPoint(0, -3, 0));
        P1 = IJ(new LoTVPoint(0, 3, 0));
        g.DrawLine(Pens.Green, P0, P1);
        P0 = IJ(new LoTVPoint(0, 0, -3));
        P1 = IJ(new LoTVPoint(0, 0, 3));
        g.DrawLine(Pens.Blue, P0, P1);
        PG = IJ(new LoTVPoint(LightVector[0], LightVector[1], LightVector[2]));
        // g.DrawLine(Pens.Yellow, PL, PL);
        int R;
        int G;
        int B;
        SolidBrush Br;
        LinearGradientBrush LG;
        for (int i = 0; i < RLength; i++)
        {
          P0 = IJ(Points[Polygons[i].FP - 1]);
          P1 = IJ(Points[Polygons[i].SP - 1]);
          P2 = IJ(Points[Polygons[i].TP - 1]);
          PL = IJ(new LoTVPoint(-LightVector[0], -LightVector[1], -LightVector[2]));
          if (Polygons[i].LightCoeff >= 0 && Polygons[i].CameraCoeff >= 0)  //!
          {
            R = ((int)(255 * Polygons[i].LightCoeff));// + (int)(240 * Polygons[i].CameraCoeff)) / 2;
            G = ((int)(255 * Polygons[i].LightCoeff));// + (int)(150 * Polygons[i].CameraCoeff)) / 2;
            B = ((int)(255 * Polygons[i].LightCoeff));// + (int)(20 * Polygons[i].CameraCoeff)) / 2;
            LG = new LinearGradientBrush(PG, PL, Color.FromArgb(R, G, B), Color.FromArgb(0, 0, 0));
            Br = new SolidBrush(Color.FromArgb(R, G, B));
            if (Polygons[i].Type == 3)
              g.FillPolygon(LG, new Point[] { P0, P1, P2 });
            else
            {
              P3 = IJ(Points[Polygons[i].FrP - 1]);
              g.FillPolygon(LG, new Point[] { P0, P1, P2, P3 });
            }
          }
          else
          {
            R = (int)(255 * Polygons[i].CameraCoeff / 100);
            G = (int)(255 * Polygons[i].CameraCoeff / 100);
            B = (int)(255 * Polygons[i].CameraCoeff / 100);
            Br = new SolidBrush(Color.FromArgb(R, G, B));
            LG = new LinearGradientBrush(PG, PL, Color.FromArgb(R, G, B), Color.FromArgb(0, 0, 0));
            if (Polygons[i].Type == 3)
              g.FillPolygon(LG, new Point[] { P0, P1, P2 });
            else
            {
              P3 = IJ(Points[Polygons[i].FrP - 1]);
              g.FillPolygon(LG, new Point[] { P0, P1, P2, P3 });
            }
          }
        }
      }
    }

    private Point IJ(LoTVPoint P)
    {
      double Xn = (P.X - fxc) * Math.Cos(Alf) - (P.Y - fyc) * Math.Sin(Alf);
      double Yn = ((P.X - fxc) * Math.Sin(Alf) + (P.Y - fyc) * Math.Cos(Alf)) * Math.Cos(Bet) - (P.Z - fzc) * Math.Sin(Bet);
      double Zn = ((P.X - fxc) * Math.Sin(Alf) + (P.Y - fyc) * Math.Cos(Alf)) * Math.Sin(Bet) + (P.Z - fzc) * Math.Cos(Bet);
      Xn = Xn / (Zn * -0.2 + 1);
      Yn = Yn / (Zn * -0.2 + 1);
      int X = (int)Math.Round(I2 * (Xn - Xmin) / (Xmax - Xmin));
      int Y = Convert.ToInt32(J2 * (Yn - Ymax) / (Ymin - Ymax));
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
    public void SetDelta(MouseEventArgs e0, MouseEventArgs e)
    {
      double dx = XX(e.X) - XX(e0.X);
      double dy = YY(e.Y) - YY(e0.Y);
      Xmin -= dx;
      Ymin -= dy;
      Xmax -= dx;
      Ymax -= dy;
    }
    public void ChangeWindowXY(int u, int v, int Delta)
    {
      double coeff;
      double x = XX(u);
      double y = YY(v);
      if (Delta < 0)
        coeff = 1.03;
      else
        coeff = 0.97;
      Xmin = x - (x - Xmin) * coeff;
      Xmax = x + (Xmax - x) * coeff;
      Ymin = y - (y - Ymin) * coeff;
      Ymax = y + (Ymax - y) * coeff;
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
    public double CameraDist;
    public double CameraCoeff;
    public int FP, SP, TP, FrP;
    public int NF, NS, NT, NFr;
    public double[] Vector;
    public int Type;
    public double LightCoeff;
    public LoTVPolygon(int FP, int SP, int TP)
    {
      Type = 3;
      this.FP = FP;
      this.SP = SP;
      this.TP = TP;
    }
    public LoTVPolygon(int FP, int SP, int TP, int FrP)
    {
      Type = 4;
      this.FP = FP;
      this.SP = SP;
      this.TP = TP;
      this.FrP = FrP;
    }
  }
}
