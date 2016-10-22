using System;
using System.Drawing;
using System.Windows.Forms;
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
    public MainForm()
    {
      InitializeComponent();
      DrawingClass.PictureBoxCanvas = _ctrlCanvasPicBx.CreateGraphics();
      DrawingClass.ImageCanvas = new Bitmap(_ctrlCanvasPicBx.ClientRectangle.Width, _ctrlCanvasPicBx.ClientRectangle.Height);
      DrawingClass.LogicsCanvas = Graphics.FromImage(DrawingClass.ImageCanvas);
    }

    private void _ctrlButDrawCashBox_Click(object sender, EventArgs e)
    {
      MainUnitProcessor.PlaceCashBox();
      _ctrlNumLower.Enabled = _ctrlNumUpper.Enabled = _ctrlButRefill.Enabled = true;
      DrawingClass.MainDrawMethod();
    }
    private void _ctrlButRefill_Click(object sender, EventArgs e)
    {
      if (MainUnitProcessor.ParseNominals(_ctrlTxb.Text))
      {
        MainUnitProcessor.RefillCashBox();
        DrawingClass.MainDrawMethod();
        _FillDGV();
      }
      else
        MessageBox.Show("Неподходящие номиналы.");
    }
    private void _ctrlButStartShow_Click(object sender, EventArgs e)
    {
      _ctrlTimer.Interval = 1;
      _ctrlTimer.Enabled = true;
      MainUnitProcessor.StartQueueing();
      MainUnitProcessor.ResetQueueTimer();
      MainUnitProcessor.ResetCashBoxTimer();
    }

    private void _ctrlNumLower_ValueChanged(object sender, EventArgs e)
    {
      _ctrlNumUpper.Minimum = _ctrlNumLower.Value;       //Чтобы нельзя было заказать больше, чем верхний предел
      MainUnitProcessor.MinValueMult = (int)_ctrlNumLower.Value / 10;
    }
    private void _ctrlNumUpper_ValueChanged(object sender, EventArgs e)
    {
      MainUnitProcessor.MaxValueMult = (int)_ctrlNumUpper.Value / 10;
    }
    private void _ctrlButThrPause_Click(object sender, EventArgs e)
    {
      _ctrlTimer.Enabled = false;
    }
    private void _ctrlButThrPlay_Click(object sender, EventArgs e)
    {
      _ctrlTimer.Enabled = true;
    }
    private void _ctrlTimer_Tick(object sender, EventArgs e)
    {
      MainUnitProcessor.TimerQueue();
      MainUnitProcessor.TimerMoveQueue();
      MainUnitProcessor.TimerOutlaw();
      MainUnitProcessor.TimerCashBox();
      _FillDGV();
      DrawingClass.MainDrawMethod();
    }
    private void _FillDGV()
    {
      MainUnitProcessor.GetCashArray();
      int L = MainUnitProcessor.CashArray.GetLength(0);
      _ctrlDGV.RowCount = L;
      _ctrlDGV.ColumnCount = 2;
      for (int i = 0; i < L; i++)
      {
        _ctrlDGV.Rows[i].Cells[0].Value = MainUnitProcessor.CashArray[i, 0].ToString();
        _ctrlDGV.Rows[i].Cells[1].Value = MainUnitProcessor.CashArray[i, 1].ToString();
      }
    }
  }
}
