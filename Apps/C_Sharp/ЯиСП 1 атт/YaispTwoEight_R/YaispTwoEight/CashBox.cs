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
    private Point[] Points;
    private Collections.MoneyList MoneyBox;
    private int AllMoneyCount;
    private bool Active;
    private int[] MoneyStacksCount;

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
      g.DrawString("Всего денег на сумму: " + AllMoneyCount.ToString() + " p.", new Font("Arial", 20, FontStyle.Bold), Brushes.DarkBlue, 50, 50);
      MoneyBox.DrawMoney(g);
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
    public bool OrderMoneySum(int Value)
    {
      MoneyStacksCount = MoneyBox.ReturnMoneyStackCount();
      int[] DesireStacks = GetValueToNoteConversion(Value);
      bool IsAvailable = true;
      for (int i = 0; i < 6; i++)
      {
        if (MoneyStacksCount[i] < DesireStacks[i])
        {
          IsAvailable = false;
          if (i != 5)  //Если i четное - то в следующем номинале добавляем 5, иначе 2
          {
            DesireStacks[i + 1] += (i % 2 == 0 || i == 0) ?
                (5 * (-MoneyStacksCount[i] + DesireStacks[i])) :
                (2 * (-MoneyStacksCount[i] + DesireStacks[i]));
            DesireStacks[i] = MoneyStacksCount[i];
          }
          else
            break;
        }
        else
          IsAvailable = true;
      }
      if (IsAvailable)
      {
        Collections.MoneyStack CurrentStack;
        for (int i = 0; i < 6; i++)
        {
          CurrentStack = MoneyBox.ReturnByIndex(i);
          CurrentStack.TakeMoneyFromStack(DesireStacks[i]);
        }
        return true;
      }
      return false;
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
