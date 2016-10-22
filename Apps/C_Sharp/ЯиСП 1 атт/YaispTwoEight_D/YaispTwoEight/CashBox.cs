using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace YaispTwoEight
{
  public class CashBox
  {
    Point[] Points;
    Collections.MoneyList MoneyBox;
    Collections.Customer Customer;
    int AllMoneyCount;
    bool Active;

    public CashBox()
    {
      MoneyBox = new Collections.MoneyList();
      Points = new Point[5] {
        new Point(60, 170),
        new Point(125, 170),
        new Point(170, 295),
      new Point(170, 465),
      new Point(60, 465)};
      AllMoneyCount = 0;
      Active = false;
    }
    public void FillMoney()
    {
      MoneyBox = new Collections.MoneyList();
      MoneyBox.FillMoney();
    }
    public void DrawCashBox(Graphics g)
    {
      g.FillPolygon(Brushes.LightGray, Points);
      g.DrawPolygon(Pens.Black, Points);
    }
    public void DrawMoney(Graphics g)
    {
      AllMoneyCount = MoneyBox.ReturnAllCashCount();
      g.DrawString("Всего бабла: " + AllMoneyCount.ToString() + " p.", new Font("Arial", 20, FontStyle.Bold), Brushes.DarkBlue, 50, 50);
      MoneyBox.DrawMoney(g);
    }
    public void ServeCustomer(Collections.Customer Customer)
    {
      this.Customer = Customer;

    }
    public bool OrderMoneySum(int Value)
    {
      int[] MoneyStacksCount = MoneyBox.ReturnMoneyStackCount();

      return false;
    }
    public void Deactivate()
    {
      Active = false;
    }
    public void Activate()
    {
      Active = true;
    }
    public bool GetActiveState()
    {
      return Active;
    }
    private static int[] GetValueToNoteConversion(int Value)
    {
      int[] Counts = new int[6];
      bool five = true;
      for (int i = 5000, j = 0; i >= 10; i /= five ? 5 : 2, five = !five, j++)
      {
        Counts[j] = Value / i;
        Value %= i;
      }
      return Counts;
    }
  }
}
