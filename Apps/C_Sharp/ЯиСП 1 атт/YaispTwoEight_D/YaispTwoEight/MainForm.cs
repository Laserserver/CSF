using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
/* 8. Смоделировать работу банкомата.
Для банкомата необходимо хранить информацию о количестве купюр разного 
достоинства. К банкомату случайным образом подходят люди.
интервалы времени между появлением клиентов распределены по нормальному 
закону. И запрашивают суммы в пределах от N до M (задается в программе) такие, 
что их потенциально можно набрать разными купюрами.
Сумма всегда выдается наиболее крупными купюрами.
Если в данный момент времени запрашиваемую сумму набрать нельзя, 
пользователь получает отказ. И тогда он может попытаться заказать другую сумму, но не более 2-х раз.
Обслуживание каждого клиента (один запрос) занимает константное кол-во 
времени. Если к банкомату подходит клиент, а с банкоматом в данный момент времени 
работает другой клиент, то первый становится в очередь. Очередь не может быть более 5 клиентов.
Визуализировать процесс. Выбрать и обосновать используемые структуры данных (собственные классы, 
списки и словари).*/
namespace YaispTwoEight
{

  public partial class MainForm : Form
  {
    static Graphics PictureBoxCanvas;
    public volatile static Graphics LogicsCanvas;
    static Bitmap ImageCanvas;
    List<Thread> MyThreads;

    public MainForm()
    {
      InitializeComponent();
      PictureBoxCanvas = _ctrlCanvasPicBx.CreateGraphics();
      ImageCanvas = new Bitmap(_ctrlCanvasPicBx.ClientRectangle.Width, _ctrlCanvasPicBx.ClientRectangle.Height);
      LogicsCanvas = Graphics.FromImage(ImageCanvas);
      MainUnitProcessor.Canv = PictureBoxCanvas;
    }

    public void MyThreading()
    {
      MyThreads = new List<Thread>() {
      new Thread(_thread_Queue_Moving),
      new Thread(_thread_Queue_Adding),
      new Thread(_thread_CashBox),
      new Thread(_thread_Customer),
      new Thread(_thread_Drawing)};
      foreach (Thread tr in MyThreads)
      {
        tr.IsBackground = true;
        tr.Start();
      }
    }
    private static void _thread_Queue_Moving()
    {
      MainUnitProcessor.Thread_Queue_Moving();
    }
    private static void _thread_Queue_Adding()
    {
      MainUnitProcessor.Thread_Queue_Adding();
    }
    private static void _thread_CashBox()
    {
      MainUnitProcessor.Thread_CashBox();
    }
    private static void _thread_Customer()
    {
      MainUnitProcessor.Thread_Customer();
    }
    private static void _thread_Drawing()
    {
      MainUnitProcessor.Thread_Drawing();
    }

    private void _ctrlButDrawCashBox_Click(object sender, EventArgs e)
    {
      MainUnitProcessor.PlaceCashBox();
      _ctrlNumLower.Enabled = _ctrlNumUpper.Enabled = _ctrlButRefill.Enabled = true;
      //MainUnitProcessor.Start(CUI);
      //th = new _Threads(CUI);
      MainDrawMethod();
    }

    private void _ctrlButRefill_Click(object sender, EventArgs e)
    {
      DrawingClass.RefillCashBox();
      MainDrawMethod();
    }
    public static void MainDrawMethod()
    {
        LogicsCanvas.Clear(Color.White);
        DrawingClass.GetImage();
        PictureBoxCanvas.DrawImage(ImageCanvas, 0, 0);
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      //DrawingClass.MovingCustomer(200);
      //CUI = new ChangeUI(MainDrawMethod);
      //MainUnitProcessor.Start(CUI);
      MyThreading();
    }

    private void _ctrlNumLower_ValueChanged(object sender, EventArgs e)
    {
      _ctrlNumUpper.Minimum = _ctrlNumLower.Value;
      MainUnitProcessor.MinValueMult = (int)_ctrlNumLower.Value / 10;
    }
    private void _ctrlNumUpper_ValueChanged(object sender, EventArgs e)
    {
      MainUnitProcessor.MaxValueMult = (int)_ctrlNumUpper.Value / 10;
    }

    private void _ctrlButThrPause_Click(object sender, EventArgs e)
    {

    }

    private void _ctrlButThrPlay_Click(object sender, EventArgs e)
    {
      //myThread.Resume();
      //myThread1.Resume();
    }

    private void _ctrlButAbortThreads_Click(object sender, EventArgs e)
    {
      foreach (Thread tr in MyThreads)
      {
        tr.Abort();
      }
      MyThreads.Clear();
    }
  }
}
