using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Morphing
{
  class TLines
  {
    public static double xMin = -12, yMin = -12, xMax = 12, yMax = 12;
    public static PointF[][] lines = new PointF[2][];
    public static PointF[] tmpLines;
    public static int I1 = 0, J1 = 0, I2, J2;
    private static double[] Coeffs;
    private static int Points = 0;
    private static double ArgMin, ArgMax;
    public static int n20 = 20;

    public static void Init()
    {
      lines[0] = new PointF[Points];
      lines[1] = new PointF[Points];
      double x, y1, y2;
      double step = (ArgMax - ArgMin) / Points * 2;
      for (int i = 0; i < Points; i++)
      {
        x = ArgMax - step * i;
        y1 = Coeffs[0] * x * x + Coeffs[2] * x + Coeffs[4];
        lines[0][i] = new PointF((float)(x), (float)y1);
        y2 = Coeffs[1] * x * x + Coeffs[3] * x + Coeffs[5];
        lines[1][i] = new PointF((float)(x), (float)y2);
      }
    }
    public static bool ParseGraph(string[] Input)
    {
      Coeffs = new double[6];
      for(int i = 0; i < 6; i++)
        if (!double.TryParse(Input[i], System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"), out Coeffs[i]))
          return false;
      if (!int.TryParse(Input[6], System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"), out Points))
        return false;
      if (Points == 0)
        return false;
      if (!double.TryParse(Input[7], System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"), out ArgMin))
        return false;
      if (!double.TryParse(Input[8], System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"), out ArgMax))
        return false;
      return true;
    }

    public static int II(double x)
    {
      return I1 + (int)((x - xMin) * (I2 - I1) / (xMax - xMin));
    }
    public static double XX(int I)
    {
      return xMin + (1D * I - I1) * (xMax - xMin) / (I2 - I1);
    }
    public static int JJ(double y)
    {
      return J2 + (int)((y - yMin) * (J1 - J2) / (yMax - yMin));
    }
    public static double YY(int J)
    {
      return yMin + (1D * J - J2) * (yMax - yMin) / (J1 - J2);
    }

    public static void Draw(Graphics g, bool timer)
    {
      int L = 0;
      if (lines[0] != null)
        L = lines[0].Length;
      Point[] p = new Point[L];

      float x, y;
      g.DrawLine(Pens.Red, II(-50), JJ(0), II(50), JJ(0));
      g.DrawLine(Pens.Blue, II(0), JJ(-50), II(0), JJ(50));
      if (L > 0)
      {
        if (!timer)
        {
          for (int i = 0; i < L; i++)
          {
            x = lines[0][i].X;
            y = lines[0][i].Y;
            g.DrawRectangle(Pens.Green, II(x) - 2, JJ(y) - 2, 4, 4);
            p[i].X = II(x);
            p[i].Y = JJ(y);
          }
          g.DrawCurve(Pens.Green, p);

          for (int i = 0; i < L; i++)
          {
            x = lines[1][i].X;
            y = lines[1][i].Y;
            g.DrawRectangle(Pens.Orange, II(x) - 2, JJ(y) - 2, 4, 4);
            p[i].X = II(x);
            p[i].Y = JJ(y);
          }
          g.DrawCurve(Pens.Orange, p);
        }
        else
        {
          if (tmpLines != null)
          {
            for (int i = 0; i < L; i++)
            {
              x = tmpLines[i].X;
              y = tmpLines[i].Y;
              p[i].X = II(x);
              p[i].Y = JJ(y);
            }
            g.DrawCurve(Pens.Black, p);
          }
        }
      }
    }
    public static void Change(int t)
    {
      tmpLines = new PointF[Points];
      int L = lines[0].Length;
      float x1, x2, y1, y2;
      for (int i = 0; i < L; i++)
      {
        x1 = lines[0][i].X; y1 = lines[0][i].Y;
        x2 = lines[1][i].X; y2 = lines[1][i].Y;
        tmpLines[i].X = x1 + t * (x2 - x1) / n20;
        tmpLines[i].Y = y1 + t * (y2 - y1) / n20;
      }
    }

  }
}
