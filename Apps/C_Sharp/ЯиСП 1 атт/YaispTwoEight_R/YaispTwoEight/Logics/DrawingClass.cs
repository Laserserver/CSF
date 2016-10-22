using System.Drawing;
using System.Collections.Generic;

namespace YaispTwoEight
{
  public static class DrawingClass
  {
    public static Graphics PictureBoxCanvas;
    public static Graphics LogicsCanvas;
    public static Bitmap ImageCanvas;

    public static void GetImage()
    {
      DrawCashBox();
      DrawOutlaw();
      DrawQueue();
    }
    public static void DrawCashBox()
    {
      LogicsCanvas.DrawLine(Pens.Black, 0, 465, 740, 465);
      Point[] Points = new Point[5] {
        new Point(60, 170),
        new Point(125, 170),
        new Point(170, 295),
      new Point(170, 465),
      new Point(60, 465)};
      LogicsCanvas.FillPolygon(Brushes.LightGray, Points);
      LogicsCanvas.DrawPolygon(Pens.Black, Points);
      LogicsCanvas.FillPolygon(MainUnitProcessor.GetActiveState() ? Brushes.LightBlue : Brushes.LightSlateGray, new Point[] {new Point(134, 195),  new Point(139, 193), new Point(170, 277), new Point(165, 280)});
      LogicsCanvas.DrawString("Всего денег на сумму: " + MainUnitProcessor.GetMoneyCount().ToString() + " p.", new Font("Arial", 20, FontStyle.Bold), Brushes.DarkBlue, 50, 50);
    }
    public static void MainDrawMethod()
    {
      LogicsCanvas.Clear(Color.White);
      GetImage();
      PictureBoxCanvas.DrawImage(ImageCanvas, 0, 0);
    }
    private static void DrawOutlaw()
    {
      if (MainUnitProcessor.Outlaw != null)
        DrawWithParameters(MainUnitProcessor.Outlaw.GetParameters());
    }
    private static void DrawQueue()
    {
      if (MainUnitProcessor.Queue != null)
      {
        List<int[]> Queue = MainUnitProcessor.Queue.ReDrawQueue();
        foreach (int[] Arr in Queue)
          DrawWithParameters(Arr);
      }
    }
    private static void DrawWithParameters(int[] Arr)
    {
      int X, Y, Shirt, Pants, State, Moving, Desire;
      X = Arr[0];
      Y = Arr[1];
      Shirt = Arr[2];
      Pants = Arr[3];
      State = Arr[4];
      Moving = Arr[5];
      Desire = Arr[6];
      LogicsCanvas.FillRectangle(GetColor(Shirt), X, Y, 40, 100);
      LogicsCanvas.DrawRectangle(Pens.Black, X, Y, 40, 100);
      LogicsCanvas.DrawRectangle(Pens.Black, X + 10, Y + 15, 20, 80);
      LogicsCanvas.FillRectangle(GetColor(Pants), X + 5, Y + 100, 30, 100);
      LogicsCanvas.DrawRectangle(Pens.Black, X + 5, Y + 100, 30, 100);
      LogicsCanvas.DrawEllipse(Pens.Black, X + 5, Y - 30, 30, 30);
      Rectangle Rect = new Rectangle(X - 5, Y - 100, 50, 50);
      switch (State)
      {
        case 1:  //Только идет
          LogicsCanvas.FillEllipse(Brushes.Yellow, Rect);
          LogicsCanvas.FillRectangle(Brushes.Black, X + 10, Y - 65, 20, 3);
          LogicsCanvas.FillEllipse(Brushes.Black, X + 5, Y - 85, 10, 10);
          LogicsCanvas.FillEllipse(Brushes.Black, X + 25, Y - 85, 10, 10);
          break;
        case 2:  //Получил
          LogicsCanvas.FillEllipse(Brushes.LightGreen, Rect);
          LogicsCanvas.FillClosedCurve(Brushes.Black, new Point[6] {
                new Point(X + 10, Y - 68),
                new Point(X + 20, Y - 65),
                new Point(X + 30, Y - 68),
                new Point(X + 30, Y - 65),
                new Point(X + 20, Y - 62),
                new Point(X + 10, Y - 65) });
          LogicsCanvas.FillEllipse(Brushes.Black, X + 5, Y - 85, 10, 10);
          LogicsCanvas.FillEllipse(Brushes.Black, X + 25, Y - 85, 10, 10);
          break;
        case 3:  //Не получил
          LogicsCanvas.FillEllipse(Brushes.Red, Rect);
          LogicsCanvas.FillClosedCurve(Brushes.Black, new Point[6] {
                new Point(X + 10, Y - 65),
                new Point(X + 20, Y - 68),
                new Point(X + 30, Y - 65),
                new Point(X + 30, Y - 62),
                new Point(X + 20, Y - 65),
                new Point(X + 10, Y - 62) });
          LogicsCanvas.FillEllipse(Brushes.Black, X + 5, Y - 82, 10, 10);
          LogicsCanvas.FillEllipse(Brushes.Black, X + 25, Y - 82, 10, 10);
          break;
        case 4: //Думает
          LogicsCanvas.FillEllipse(Brushes.Orange, Rect);
          LogicsCanvas.FillRectangle(Brushes.Black, X + 15, Y - 65, 10, 3);
          LogicsCanvas.FillEllipse(Brushes.Black, X + 5, Y - 89, 10, 10);
          LogicsCanvas.FillEllipse(Brushes.Black, X + 25, Y - 89, 10, 10);
          break;
      }
      if (Moving == 3)
        LogicsCanvas.DrawEllipse(Pens.Black, X + 25, Y - 20, 4, 4);
      else
        LogicsCanvas.DrawEllipse(Pens.Black, X + 10, Y - 20, 4, 4);
      LogicsCanvas.DrawString(Desire.ToString() + " p.", new Font("Arial", 10), Brushes.Black, X + 5, Y - 50);
      LogicsCanvas.DrawEllipse(Pens.Black, Rect);
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
