using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Render
{

  public static class MyDrawing
  {
    static Tuple<Structures.MyPoint[], Structures.MyPolygon[], Structures.MyEdge[]> MainData;
    public static Graphics g;
    public static Bitmap Canvas;
    static bool EdgesOnly;
    static int
      I1 = 0,
      J1 = 0,
      I2 = 0,   //Ширина
      J2 = 0;
    public static double
   fxc = 0.5,
   fyc = 0.5,
   fzc = 0.5,
   Xmin = -2,
   Xmax = 2,
   Ymin = -2,
   Ymax = 2,
      x1p = -2,
      x2p = 2,
      y1p = -2,
      y2p = 2;
    public static bool Normasl = false;
    static double Alf = 0, Bet = 13;
    public static void SetMonitor(int X, int Y)
    {
      I2 = X;
      J2 = Y;
    }
    public static void SetState(bool Edges)
    {
      EdgesOnly = Edges;
    }
    public static void GetData(Tuple<Structures.MyPoint[], Structures.MyPolygon[], Structures.MyEdge[]> Data)
    {
      MainData = Data;
    }
    public static void ChangeWindowXY(int u, int v, int Delta)
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
    /*  private static double XX(int I)
      {
        return Xmin + I * (Xmax - Xmin) / I2;
      }
      private static double YY(int J)
      {
        return Ymax + J * (Ymin - Ymax) / J2;
      }*/
    public static double XX(int I)          //Перевод Х коры в кору бумаги
    {
      return x1p + (I - I1) * (x2p - x1p) / (I2 - I1);
    }
    public static double YY(int J)          //Перевод Ыгрыка в кору бумаги
    {
      return y1p + (J - J1) * (y2p - y1p) / (J2 - J1);
    }
    static int II(double x)          //Перевод бумажного Х в экранный
    {
      return I1 + (int)((x - x1p) * (I2 - I1) / (x2p - x1p));
    }
    static int JJ(double y)          //Перевод бумажного Y в экранный
    {
      return J1 + (int)((y - y1p) * (J1 - J2) / (y1p - y2p));
    }
    public static void SetDelta(MouseEventArgs e0, MouseEventArgs e)
    {
      double dx = XX(e.X) - XX(e0.X);
      double dy = YY(e.Y) - YY(e0.Y);
      Xmin -= dx;
      Ymin -= dy;
      Xmax -= dx;
      Ymax -= dy;
    }

    public static void Draw()
    {
      if (EdgesOnly)
        _Draw(new Hernya(DrawEdge));
      else
        _Draw(new Hernya(DrawPolygon));
    }
    private static void _Draw(Hernya Del)
    {
      using (Graphics g = Graphics.FromImage(Canvas))
      {
        MainUnitProcessor.Model.InvokeAlgorithms();
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.Clear(Color.Black);
        MatrixesAndVectors.MatrixProjection Proj = new MatrixesAndVectors.MatrixProjection(1);
        Point P0, P1;
        P0 = _IJ(new Structures.MyPoint(-30, 0, 0));
        P1 = _IJ(new Structures.MyPoint(30, 0, 0));
        g.DrawLine(Pens.Red, P0, P1);
        P0 = _IJ(new Structures.MyPoint(0, -3, 0));
        P1 = _IJ(new Structures.MyPoint(0, 3, 0));
        g.DrawLine(Pens.Green, P0, P1);
        P0 = _IJ(new Structures.MyPoint(0, 0, -3));
        P1 = _IJ(new Structures.MyPoint(0, 0, 3));
        g.DrawLine(Pens.Blue, P0, P1);
        Structures.MyPolygon[] Polygons = MainData.Item2;
        for (int i = 0; i < MainUnitProcessor.Model.RLength; i++)
          Del(Polygons[i]);
      }
    }

    private delegate void Hernya(Structures.MyPolygon Pol);
    private static void DrawPolygon(Structures.MyPolygon Pol)
    {
      using (Graphics g = Graphics.FromImage(Canvas))
      {
        int R;
        int G;
        int B;
        double MC = Math.Abs(Pol.CameraCoeff);
        if (Pol.LightCoeff >= 0)  //!
        {
          R = (int)((255 * Pol.LightCoeff + 240 * MC) / 2);
          G = (int)((255 * Pol.LightCoeff + 150 * MC) / 2);
          B = (int)((255 * Pol.LightCoeff + 20 *  MC) / 2 );
        }
        else
        {
          R = (int)(24 * MC);
          G = (int)(15 * MC);
          B = (int)(2 * MC);
        }

        SolidBrush Br = new SolidBrush(Color.FromArgb(R, G, B));
        Structures.MyPoint[] Points = MainData.Item1;

        Point P0 = _IJ(Points[Pol.FP - 1]);
        Point P1 = _IJ(Points[Pol.SP - 1]);
        Point P2 = _IJ(Points[Pol.TP - 1]);
        if (Pol.Type == 3)
          g.FillPolygon(Br, new Point[] { P0, P1, P2 });
        else
        {
          Point P3 = _IJ(Points[Pol.FrP - 1]);
          g.FillPolygon(Br, new Point[] { P0, P1, P2, P3 });
        }
        if (Normasl)
        {
          g.DrawLine(Pens.Red, _IJ(Points[Pol.FP - 1]), _IJ(new Structures.MyPoint(Pol.Vector[0], Pol.Vector[1], Pol.Vector[2])));
        }
      }
    }
    private static void DrawEdge(Structures.MyPolygon Pol)
    {
      using (Graphics g = Graphics.FromImage(Canvas))
      {
        Structures.MyPoint[] Points = MainData.Item1;
        Point P0 = _IJ(Points[Pol.FP - 1]);
        Point P1 = _IJ(Points[Pol.SP - 1]);
        Point P2 = _IJ(Points[Pol.TP - 1]);
        if (Pol.Type == 3)
          g.DrawPolygon(Pens.White, new Point[] { P0, P1, P2 });
        else
        {
          Point P3 = _IJ(Points[Pol.FrP - 1]);
          g.DrawPolygon(Pens.White, new Point[] { P0, P1, P2, P3 });
        }
      }
    }
    private static Point IJ(Structures.MyPoint P)
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
    private static Point _IJ(Structures.MyPoint P)
    {
      Structures.MyPoint Lol = MatrixesAndVectors.VectorMultiply(P, new MatrixesAndVectors.MatrixProjection(3));
      return new Point(II(Lol.X), JJ(Lol.Y));
    }
  }
}
