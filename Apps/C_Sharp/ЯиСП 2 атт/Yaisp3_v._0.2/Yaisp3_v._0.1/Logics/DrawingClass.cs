using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Yaisp3_v._0._1
{
  static class MainDrawingClass
  {
    //public static Graphics CanvasControlMap;
    private static Graphics _CanvasLogicsMap;
    private static Bitmap _CanvasMap;

    public static int I1 = 0, I2 = 0, J1 = 0, J2 = 0;
    public static double x1p = -50, y1p = -50, x2p = 50, y2p = 50;
    public const double x1old = -50, y1old = -50, x2old = 50, y2old = 50; //Константные координаты истинного масштаба   

    public static void MakeMapCanvas(int Width, int Height)
    {
      _CanvasMap = new Bitmap(Width, Height);
      _CanvasLogicsMap = Graphics.FromImage(_CanvasMap);
    }
    public static void GetRefControl(System.Windows.Forms.Control Control)
    {
      Control.CreateGraphics();
    }

    //========== Для операций с картой
    private static int II(double x)
    {
      return I1 + (int)((x - x1p) * (I2 - I1) / (x2p - x1p));
    }
    private static int JJ(double y)
    {
      return J1 + (int)((y - y1p) * (J1 - J2) / (y1p - y2p));
    }
    public static double XX(int I)
    {
      return x1p + (I - I1) * (x2p - x1p) / (I2 - I1);
    }
    public static double YY(int J)
    {
      return y1p + (J - J1) * (y2p - y1p) / (J2 - J1);
    }
    public static void MapMove(int MouseX, int MouseY, int OldCoordsX, int OldCoordsY)    //Движение изображения
    {
      double dx = XX(MouseX) - XX(OldCoordsX);
      double dy = YY(MouseY) - YY(OldCoordsY);

      x1p -= dx;
      y1p -= dy;
      x2p -= dx;
      y2p -= dy;
    }
    public static void MapSetNormalZoom()
    {
      x1p = x1old;
      x2p = x2old;
      y1p = y1old;
      y2p = y2old;
    }
    public static void MapZoom(int IX, int IY, int Delta)
    {
      double x = XX(IX);
      double y = YY(IY);
      double coeff = 0;
      if (Delta < 0)
        coeff = 1.03;
      else
        coeff = 0.97;
      x1p = x - (x - x1p) * coeff;  //x1 > x
      x2p = x + (x2p - x) * coeff;
      y1p = y - (y - y1p) * coeff;
      y2p = y + (y2p - y) * coeff;
    }
  }
}
