using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading;

namespace Graphics_One
{
  class LoTVDrawing
  {
    public static Bitmap bitm;
    public static void LoTVDrawTrain(int X, int Y, bool circle)
    {
      using (Graphics g = Graphics.FromImage(bitm))
      {
        if (circle)
        {
          g.DrawEllipse(Pens.Black, X - 25, Y - 25, 50, 50);
          g.FillEllipse(Brushes.Red, X - 25, Y - 25, 50, 50);
        }
        else
        {
          g.DrawRectangle(Pens.Black, X - 25, Y - 25, 50, 50);
          g.FillRectangle(Brushes.Red, X - 25, Y - 25, 50, 50);
        }
      }
    }
    public static void LoTVPreDraw(Graphics Canvas)
    {
      using (Graphics g = Graphics.FromImage(bitm))
      {
        Brush myBr = Brushes.LimeGreen;
        g.FillRectangle(myBr, 0, 350, 720, 430);
        myBr = Brushes.LightBlue;
        g.FillRectangle(myBr, 0, 0, 720, 350);
      }
    }
    public static void LoTVDraw(Graphics Canvas)
    {
      
      using (Graphics g = Graphics.FromImage(bitm))
      {
        int y = 0;
        for (int x = 0; x < 720; x++)
        {
          y = (int)(-0.002 * x * x + 1.44 * x);
        g.DrawEllipse(Pens.Black, x - 40, y, 80, 80);
          Thread.Sleep(4);
        }
      }
    }
  }
}
