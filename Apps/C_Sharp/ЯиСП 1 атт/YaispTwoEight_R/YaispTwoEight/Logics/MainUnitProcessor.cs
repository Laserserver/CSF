using System;

namespace YaispTwoEight
{
  public static class MainUnitProcessor
  {
    public static CashBox MainMachine;
    public static int MinValueMult = 1, MaxValueMult = 1; //Хранятся в виде .1 мультипликаторов
    public static Collections.CustomerQueue Queue;
    public static Collections.Customer CurrentCustomer;
    public static Collections.Customer Outlaw;   //Это для имитации ухода
    private static Random Rnd = new Random();
    public static int[,] CashArray;
    private static int _CountTimeCashBox = 0;
    private static int _CountTimeQueue = 0;
    public static int[] GlobalNominals;

    public static bool GetActiveState()
    {
      return MainMachine.GetActiveState();
    }
    public static bool ParseNominals(string Input)
    {
      try
      {
        Input = Input.Trim();
        string[] Arr = Input.Split(',');
        int L = Arr.Length;
        int[] Nominals = new int[L];
        for (int i = 0; i < L; i++)
          Nominals[i] = int.Parse(Arr[i]);
        Array.Sort(Nominals);//, (x, y) => -x.CompareTo(y));
        GlobalNominals = Nominals;
        return true;
      }
      catch
      {
        return false;
      }
    }
    public static int GetMoneyCount()
    {
      return MainMachine.GetMoneyCount();
    }
    public static void GetCashArray()
    {
      CashArray = MainMachine.GetMoneyArray();
    }
    public static void RefillCashBox()
    {
      MainMachine.FillMoney(GlobalNominals);
    }
    public static void PlaceCashBox()
    {
      MainMachine = new CashBox();
      DrawingClass.DrawCashBox();
    }
    public static void GetRandomShirtAndPants(out int Pants, out int Shirt)
    {
      int tens = Rnd.Next(1, 4);
      int fifth = Rnd.Next(1, 3);
      Shirt = (fifth == 1 ? 1 : 5) * (tens == 1 ? 10 : tens == 2 ? 100 : 1000);
      fifth = Rnd.Next(1, 3);
      tens = Rnd.Next(1, 4);
      Pants = (fifth == 1 ? 1 : 5) * (tens == 1 ? 10 : tens == 2 ? 100 : 1000);

    }
    public static int GetRandomMoneyCount(int Max)
    {
      return Rnd.Next(MinValueMult, Max / 10) * 10;
    }
    public static int GetRandomMoneyCount()
    {
      return Rnd.Next(MinValueMult, MaxValueMult) * 10;
    }
    public static int GetRandomInteger()
    {
      return Rnd.Next(0, 100);
    }
    ////////////////////////////////////////////
    public static void StartQueueing()
    {
      Queue = new Collections.CustomerQueue();
      Queue.AddToQueue();
    }
    public static void ResetQueueTimer()
    {
      _CountTimeQueue = Rnd.Next(Rnd.Next(1, 10) * 100);
    }
    public static void TimerQueue()
    {
      _CountTimeQueue--;
      if (Queue.ReturnCount() < 5)
        if (_CountTimeQueue == 0)
        {                       //Когда каунтер подходит к 0 - добавляем нового человека...
          Queue.AddToQueue();
          ResetQueueTimer();    //...и восстанавливаем счетчик
        }
    }
    ///////////////////////////////////////////
    public static void ResetCashBoxTimer()
    {
      _CountTimeCashBox = 200;
    }
    public static void ActivateMachine()
    {
      CurrentCustomer = Queue.ReturnHead(true);  //Мы берем ссылку на человека в начале
      CurrentCustomer.StartThinking();
      MainMachine.Activate();
    }
    public static void TimerCashBox()
    {
      if (MainMachine.GetActiveState())
      {
        _CountTimeCashBox--;          //Уходит время из таймера
        if (_CountTimeCashBox < 1)   //Когда равно 0
          _ServeCustomer();
      }
    }
    private static void _ServeCustomer()
    {
      if (CurrentCustomer.GetTriesCount() > 0 && !CurrentCustomer.WasServed())
      {
        CurrentCustomer.TakeResponse(MainMachine.OrderMoney(CurrentCustomer.GetMoneyDesire()));
        if (!CurrentCustomer.WasServed())
          ResetCashBoxTimer();
      }
      if (CurrentCustomer.GetTriesCount() < 1 || CurrentCustomer.WasServed())
      {
        CurrentCustomer.MoveToExit();
        Outlaw = Queue.ReturnHead(false);          //Выгоняем человека из начала очереди
        ResetQueueTimer();
        ResetCashBoxTimer();
        MainMachine.Deactivate();
      }
    }
    ///////////////////////////////////
    public static void TimerOutlaw()
    {
      if (Outlaw != null)
        if (Outlaw.GetPosition() < 790)
          Outlaw.MoveCustomer();
        else
          Outlaw = null;
    }
    ////////////////////////////
    public static void TimerMoveQueue()
    {
      Queue.MoveQueue();
    }
  }
}
