using System.Drawing;

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
      MainUnitProcessor.MainMachine.DrawCashBox(LogicsCanvas);
      MainUnitProcessor.MainMachine.DrawMoney(LogicsCanvas);
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
        MainUnitProcessor.Outlaw.DrawCustomer(LogicsCanvas);
    }
    private static void DrawQueue()
    {
      if (MainUnitProcessor.Queue != null)
        MainUnitProcessor.Queue.ReDrawQueue(LogicsCanvas);
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
