using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Yaisp3_v._0._1
{
  class DrawingClass
  {
    public Graphics CanvasControl;
    protected Graphics _CanvasLogics;
    protected Bitmap _CanvasImage;

    public int I1 = 0, I2 = 0, J1 = 0, J2 = 0;
    public double x1p = -50, y1p = -50, x2p = 50, y2p = 50;
    public double x1old = -50, y1old = -50, x2old = 50, y2old = 50; //Константные координаты истинного масштаба

    public DrawingClass(System.Windows.Forms.Control Control)
    {
      CanvasControl = Control.CreateGraphics();
      _CanvasImage = new Bitmap(Control.Width, Control.Height);
      I2 = Control.Width;
      J2 = Control.Height;
      _CanvasLogics = Graphics.FromImage(_CanvasImage);
    }
    public void DropBitm()
    {
      CanvasControl.Dispose();
      _CanvasLogics.Dispose();
      _CanvasImage.Dispose();
    }
    public void DrawImage()
    {
      CanvasControl.DrawImage(_CanvasImage, 0, 0);
    }

    protected int GetScreenX(double x)
    {
      return I1 + (int)((x - x1p) * (I2 - I1) / (x2p - x1p));
    }
    protected int GetScreenY(double y)
    {
      return J1 + (int)((y - y1p) * (J1 - J2) / (y1p - y2p));
    }
    protected double GetGraphX(int I)
    {
      return x1p + (I - I1) * (x2p - x1p) / (I2 - I1);
    }
    protected double GetGraphY(int J)
    {
      return y1p + (J - J1) * (y2p - y1p) / (J2 - J1);
    }

    public void Move(int MouseX, int MouseY, int OldCoordsX, int OldCoordsY)    //Движение изображения
    {
      double dx = GetGraphX(MouseX) - GetGraphX(OldCoordsX);
      double dy = GetGraphY(MouseY) - GetGraphY(OldCoordsY);

      x1p -= dx;
      y1p -= dy;
      x2p -= dx;
      y2p -= dy;
    }
    public void SetNormalZoom()
    {
      x1p = x1old;
      x2p = x2old;
      y1p = y1old;
      y2p = y2old;
    }
    public void Zoom(int IX, int IY, int Delta)
    {
      double x = GetGraphX(IX);
      double y = GetGraphY(IY);
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

  class DrawingClassMap : DrawingClass
  {
    public DrawingClassMap(System.Windows.Forms.Control Control) : base(Control)
    {

    }
    public void DrawMap()
    {
      MainUnitProcessor.CityGetDrawingData();
      /*for блаблабла рисовка домов, дорог и баннеров*/
    }
  }
  class DrawingClassCityCreator : DrawingClass
  {
    private int CityWidth, CityHeight;
    public DrawingClassCityCreator(System.Windows.Forms.Control Control, int CWidth, int CHeight) : base(Control)
    {
      CityHeight = CHeight;
      CityWidth = CWidth;
    }
    public void ClearCanvas()
    {
      _CanvasLogics.Clear(Color.White);
    }
    public void DrawGrid()
    {
      _CanvasLogics.DrawLine(Pens.Red, GetScreenX(0), GetScreenY(-500), GetScreenX(0), GetScreenY(500));
      _CanvasLogics.DrawLine(Pens.Blue, GetScreenX(-500), GetScreenY(0), GetScreenX(500), GetScreenY(0));
      for (int i = 0; i <= CityHeight; i++)
        _CanvasLogics.DrawLine(Pens.Black, GetScreenX(0), GetScreenY(i * -5),
          GetScreenX(CityWidth * 5), GetScreenY(i * -5));
      for (int i = 0; i <= CityWidth; i++)
        _CanvasLogics.DrawLine(Pens.Black, GetScreenX(i * 5), GetScreenY(0),
          GetScreenX(i * 5), GetScreenY(CityHeight * -5));
    }
    public void DrawCurrentObject(int X, int Y, int Width, int Height)
    {
      double PapX = GetGraphX(X) - 2.5;
      double PapY = GetGraphY(Y) - 2.5;
      int a = GetScreenX(PapX),
        b = GetScreenY(PapY),
        c = Math.Abs(a - GetScreenX(PapX - 5 * Width)),
        d = Math.Abs(b - GetScreenY(PapY + 5 * Height));
      _CanvasLogics.FillRectangle(Brushes.Green, a, b, c, d);
      _CanvasLogics.DrawRectangle(Pens.Black, a, b, c, d);
    }
    public bool FindPlaceInMatrix(int X, int Y, out int Row, out int Col)
    {
      Row = Col = 0;
      int PapX = (int)GetGraphX(X);
      int PapY = (int)GetGraphY(Y);
      Col = PapX / 5;
      Row = CityHeight - Math.Abs(PapY / 5) - 1;
      return !(Col >= CityWidth || Row >= CityHeight || Row < 0 || Col < 0);
    }
    public void DrawCityElement(int MatrRow, int MatrCol)
    {
      int ScrX = GetScreenX(5 * MatrCol);
      int LastX = GetScreenX(5 * MatrCol + 5);

      int ScrY = GetScreenY(-CityHeight * 5 + 5 * MatrRow);
      int LastY = GetScreenY(-CityHeight * 5 + 5 * MatrRow + 5);

      _CanvasLogics.FillRectangle(Brushes.Gray, ScrX, ScrY, LastX - ScrX, Math.Abs(ScrY - LastY));
    }
  }
}
