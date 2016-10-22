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
    private static Tuple<Structures.MyPoint[], Structures.MyPolygon[], Structures.MyEdge[]> _MainData;
    public static Graphics TempGraphics;
    public static Bitmap Canvas;
    private static bool _edgesOnly; //!!
    private static int  //!!
      windowWidth = 0,   //Ширина
      windowHeigth = 0;
    public static double
      fxc = 0,
      fyc = 0,
      fzc = 0.5,
      leftXViewingBoundary = -2,
      rightXViewingBoundary = 2,
      upperYViewingBoundary = -2,
      lowerYViewingBoundary = 2;
    public static bool hasNormalsVisible = false;
    public static double alphaAngle = 0, betaAngle = 0;
    public static void SetMonitor(int X, int Y)
    {
      windowWidth = X;
      windowHeigth = Y;
    }
    public static void SetState(bool Edges)
    {
      _edgesOnly = Edges;
    }
    public static void GetData(Tuple<Structures.MyPoint[], Structures.MyPolygon[], Structures.MyEdge[]> Data)
    {
        _MainData = Data;
    }
    public static void ChangeWindowXY(int u, int v, int Delta)
    {
      double coeff;
      double x = _XX(u);
      double y = _YY(v);
      if (Delta < 0)
        coeff = 1.03;
      else
        coeff = 0.97;
      leftXViewingBoundary = x - (x - leftXViewingBoundary) * coeff;
      rightXViewingBoundary = x + (rightXViewingBoundary - x) * coeff;
      upperYViewingBoundary = y - (y - upperYViewingBoundary) * coeff;
      lowerYViewingBoundary = y + (lowerYViewingBoundary - y) * coeff;
    }
    private static double _XX(int I)
    {
      return leftXViewingBoundary + I * (rightXViewingBoundary - leftXViewingBoundary) / windowWidth;
    }
    private static double _YY(int J)
    {
      return lowerYViewingBoundary + J * (upperYViewingBoundary - lowerYViewingBoundary) / windowHeigth;
    }
    public static void SetDelta(MouseEventArgs e0, MouseEventArgs e)
    {
      double dx = _XX(e.X) - _XX(e0.X);
      double dy = _YY(e.Y) - _YY(e0.Y);
      leftXViewingBoundary -= dx;
      upperYViewingBoundary -= dy;
      rightXViewingBoundary -= dx;
      lowerYViewingBoundary -= dy;
    }

    public static void Draw()
    {
      if (_edgesOnly)
        _Draw(new _DelSwitch(DrawEdge));
      else
        _Draw(new _DelSwitch(_DrawPolygon));
    }
    private static void _Draw(_DelSwitch Del)
    {
      using (Graphics g = Graphics.FromImage(Canvas))
      {
        MainUnitProcessor.Model.InvokeAlgorithms();
        g.Clear(Color.Black);
        MatricesAndVectors.MatrixProjection Proj = new MatricesAndVectors.MatrixProjection(1);
        Point P0, P1;
        P0 = Translate3DTo2D(new Structures.MyPoint(-3, 0, 0));
        P1 = Translate3DTo2D(new Structures.MyPoint(3, 0, 0));
        g.DrawLine(Pens.Red, P0, P1);
        P0 = Translate3DTo2D(new Structures.MyPoint(0, -3, 0));
        P1 = Translate3DTo2D(new Structures.MyPoint(0, 3, 0));
        g.DrawLine(Pens.Green, P0, P1);
        P0 = Translate3DTo2D(new Structures.MyPoint(0, 0, -3));
        P1 = Translate3DTo2D(new Structures.MyPoint(0, 0, 3));
        g.DrawLine(Pens.Blue, P0, P1);
        Structures.MyPolygon[] Polygons = _MainData.Item2;
        for (int i = 0; i < MainUnitProcessor.Model.polygonLength; i++)
          Del(Polygons[i]);
      }
    }

    private delegate void _DelSwitch(Structures.MyPolygon Pol);
    private static void _DrawPolygon(Structures.MyPolygon Pol)
    {
      using (Graphics g = Graphics.FromImage(Canvas))
      {
        g.SmoothingMode = SmoothingMode.HighQuality;
        int R;
        int G;
        int B;
        if (Pol.LightCoeff >= 0)  //!
        {
          R = (int)((255 * Pol.LightCoeff + 240 * Pol.CameraDist) / 2);
          G = (int)((255 * Pol.LightCoeff + 150 * Pol.CameraDist) / 2);
          B = (int)((255 * Pol.LightCoeff + 20 *  Pol.CameraDist) / 2);
          /*}
          else
          {
            R = (int)(24 * MC);
            G = (int)(15 * MC);
            B = (int)(2 * MC);
          }*/

          SolidBrush Br = new SolidBrush(Color.FromArgb(R, G, B));
          Structures.MyPoint[] Points = _MainData.Item1;

          Point P0 = Translate3DTo2D(Points[Pol.firstPoint - 1]);
          Point P1 = Translate3DTo2D(Points[Pol.secondPoint - 1]);
          Point P2 = Translate3DTo2D(Points[Pol.thirdPoint - 1]);
          if (Pol.Type == 3)
            g.FillPolygon(Br, new Point[] { P0, P1, P2 });
          else
          {
            Point P3 = Translate3DTo2D(Points[Pol.fourthPoint - 1]);
            g.FillPolygon(Br, new Point[] { P0, P1, P2, P3 });
          }

          if (hasNormalsVisible)
            g.DrawLine(Pens.Red, Translate3DTo2D(Points[Pol.firstPoint - 1]), Translate3DTo2D(new Structures.MyPoint(Pol.Vector[0], Pol.Vector[1], Pol.Vector[2])));
        }
      }
    }
    private static void DrawEdge(Structures.MyPolygon Pol)
    {
      using (Graphics g = Graphics.FromImage(Canvas))
      {
        g.SmoothingMode = SmoothingMode.HighQuality;
        Structures.MyPoint[] Points = _MainData.Item1;
        Point P0 = Translate3DTo2D(Points[Pol.firstPoint - 1]);
        Point P1 = Translate3DTo2D(Points[Pol.secondPoint - 1]);
        Point P2 = Translate3DTo2D(Points[Pol.thirdPoint - 1]);
        if (Pol.Type == 3)
          g.DrawPolygon(Pens.White, new Point[] { P0, P1, P2 });
        else
        {
          Point P3 = Translate3DTo2D(Points[Pol.fourthPoint - 1]);
          g.DrawPolygon(Pens.White, new Point[] { P0, P1, P2, P3 });
        }
      }
    }
    private static Point Translate3DTo2D(Structures.MyPoint TempPoint)
    {
        const double empyricParam = -0.2;
      double realXCoord = (TempPoint.X - fxc) * Math.Cos(alphaAngle) - (TempPoint.Y - fyc) * Math.Sin(alphaAngle);
      double realYCoord = ((TempPoint.X - fxc) * Math.Sin(alphaAngle) +
          (TempPoint.Y - fyc) * Math.Cos(alphaAngle)) * Math.Cos(betaAngle) -
          (TempPoint.Z - fzc) * Math.Sin(betaAngle);
      double realZCoord = ((TempPoint.X - fxc) * Math.Sin(alphaAngle) +
          (TempPoint.Y - fyc) * Math.Cos(alphaAngle)) * Math.Sin(betaAngle) +
          (TempPoint.Z - fzc) * Math.Cos(betaAngle);
      realXCoord /= realZCoord * empyricParam + 1;
      realYCoord /= realZCoord * empyricParam + 1;
      int imaginaryXCoord = (int)Math.Round(windowWidth * (realXCoord - leftXViewingBoundary) / (rightXViewingBoundary - leftXViewingBoundary));
      int Y = Convert.ToInt32(windowHeigth * (realYCoord - lowerYViewingBoundary) / (upperYViewingBoundary - lowerYViewingBoundary));
      return new Point(imaginaryXCoord, Y);
    }
  }
}
