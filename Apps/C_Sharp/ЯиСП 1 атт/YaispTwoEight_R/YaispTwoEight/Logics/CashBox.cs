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
    public enum ResponseCode { Good, TryToAbs, NotEnoughMoney, No };
    private Collections.MoneyList MoneyBox;
    private bool Active;
    private int[] MoneyStacksCount;

    public CashBox()
    {
      MoneyBox = new Collections.MoneyList();
      Active = false;
    }
    public void FillMoney(int[] Nom)
    {
      MoneyBox = new Collections.MoneyList();
      MoneyBox.FillMoney(Nom);
    }
    public int GetMoneyCount()
    {
      return MoneyBox.ReturnAllCashCount();
    }
    public int[,] GetMoneyArray()
    {
      return MoneyBox.GetMoneyArray();
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
    public ResponseCode OrderMoney(int Value)
    { 
      MoneyStacksCount = MoneyBox.ReturnMoneyStackCount();
      int[] DesireStacks;
      //Начальное условие, можно ли набрать* всеми доступными купюрами
      if (!GetValueToNoteConversion(Value, out DesireStacks))   
        return ResponseCode.TryToAbs;
      //Если вообще не хватит денег на запрос
      if (MainUnitProcessor.GetMoneyCount() < Value)
        return ResponseCode.NotEnoughMoney;
      //Иначе продолжаем выполнять
      int L = MainUnitProcessor.GlobalNominals.Length;
      bool IsAvailable = true;
      int Buffer = 0;
      //Цикл просмотра допустимости набора присутствующими купюрами
      for (int i = 0; i < L; i++)
        if (MoneyStacksCount[i] < DesireStacks[i])
        {
          IsAvailable = false;
          if (i != L - 1)
          {
            //Разбиваем верхний номинал на N кол-во нижних и вычитаем
            DesireStacks[i + 1] += (DesireStacks[i] - MoneyStacksCount[i]) *
             MainUnitProcessor.GlobalNominals[L - i - 1] / MainUnitProcessor.GlobalNominals[L - 2 - i];
            //L - i - 1 - Desire верхний номинал
            Buffer += (DesireStacks[i] - MoneyStacksCount[i]) * 
              MainUnitProcessor.GlobalNominals[L - i - 1] % MainUnitProcessor.GlobalNominals[L - 2 - i];
            if (Buffer != 0)
            {
              int Temp = Buffer % MainUnitProcessor.GlobalNominals[L - i - 2];
              if (Temp == 0)
              {
                DesireStacks[i + 1] += Buffer / MainUnitProcessor.GlobalNominals[L - i - 2];
                Buffer = 0;
              }
            }
            DesireStacks[i] = MoneyStacksCount[i];
          }
          else
            break;
        }
        else
          IsAvailable = true;
      //Если можно набрать - вытащить сумму из пачек
      if (IsAvailable)
      {
        Collections.MoneyStack CurrentStack;
        for (int i = 0; i < L; i++)
        {
          CurrentStack = MoneyBox.ReturnByIndex(i);
          CurrentStack.TakeMoneyFromStack(DesireStacks[i]);
        }
        return ResponseCode.Good;
      }
      else
        return ResponseCode.TryToAbs;
    }
    private bool GetValueToNoteConversion(int Value, out int[] Counts)
    {
      int L = MainUnitProcessor.GlobalNominals.Length;
      Counts = new int[L];
      for (int i = L - 1; i >= 0 && Value != 0; i--)
      {
        Counts[L - 1 - i] = Value / MainUnitProcessor.GlobalNominals[i];
        Value %= MainUnitProcessor.GlobalNominals[i];
      }
      return Value == 0;
    }
  }
}
