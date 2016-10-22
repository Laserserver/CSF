using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace YaispTwoEight
{
  public static class DrawingClass
  {

    public static void DrawCashBox()
    {
      MainForm.LogicsCanvas.DrawLine(Pens.Black, 0, 465, 740, 465);
      MainUnitProcessor.MainMachine.DrawCashBox(MainForm.LogicsCanvas);
      MainUnitProcessor.MainMachine.DrawMoney(MainForm.LogicsCanvas);
    }
    public static void DrawCurrentCustomer()
    {
      if (MainUnitProcessor.CurrentCustomer != null)
        MainUnitProcessor.CurrentCustomer.DrawCustomer(MainForm.LogicsCanvas);
    }
    public static void DrawQueue()
    {
      if (MainUnitProcessor.Queue != null)
        MainUnitProcessor.Queue.ReDrawQueue(MainForm.LogicsCanvas);
    }
    public static void GetImage()
    {
      DrawCashBox();
      DrawCurrentCustomer();
      DrawQueue();
    }

    public static void RefillCashBox()
    {
      MainUnitProcessor.MainMachine.FillMoney();
    }

    public static Brush GetColor(int type)
    {
      switch (type)
      {
        case 10:
          return Brushes.Olive;
        case 50:
          return Brushes.LightBlue;
        case 100:
          return Brushes.DarkGoldenrod;
        case 500:
          return Brushes.Violet;
        case 1000:
          return Brushes.Cyan;
        default: //5000
          return Brushes.DarkOrange;
      }
    }
  }
}
