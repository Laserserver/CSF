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
    public static Random Rnd = new Random();
    private static int _CountTimeCashBox = 0;
    private static int _CountTimeQueue = 0;

    public static void GetRandomShirtAndPants(out int Pants, out int Shirt)
    {
      int tens = Rnd.Next(1, 4);
      int fifth = Rnd.Next(1, 3);
      Shirt = (fifth == 1 ? 1 : 5) * (tens == 1 ? 10 : tens == 2 ? 100 : 1000);
      fifth = Rnd.Next(1, 3);
      tens = Rnd.Next(1, 4);
      Pants = (fifth == 1 ? 1 : 5) * (tens == 1 ? 10 : tens == 2 ? 100 : 1000);

    }
    public static void RefillCashBox()
    {
      MainMachine.FillMoney();
    }
    public static void PlaceCashBox()
    {
      MainMachine = new CashBox();
      DrawingClass.DrawCashBox();
    }
    public static int GetRandomMoneyCount()
    {
      return Rnd.Next(MinValueMult, MaxValueMult) * 10;
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
      if (CurrentCustomer.GetTriesCount() > 0 && !CurrentCustomer.GotServeState())
      {
        CurrentCustomer.TakeMoneyFromMachine(MainMachine.OrderMoneySum(CurrentCustomer.GetMoneyDesire()));
        if (!CurrentCustomer.GotServeState())
        {
          CurrentCustomer.RethinkDesire();               //Если нет - то передумывает 
          ResetCashBoxTimer();
        CurrentCustomer.BurnTry();                           //И сбрасываем таймер
        }
      }
      if (CurrentCustomer.GetTriesCount() == 0 || CurrentCustomer.GotServeState())
      {
        CurrentCustomer.MoveToExit();
        Outlaw = Queue.ReturnHead(false);          //Выгоняем человека из начала очереди
        ResetQueueTimer();
        ResetCashBoxTimer();
        MainMachine.Deactivate();
      }
    }
    /// ////////////////////////////////
    public static void TimerOutlaw()
    {
      if (Outlaw != null)
        if (Outlaw.GetPosition() < 790)
          Outlaw.MoveCustomer();
        else
          Outlaw = null;
    }
    /// /////////////////////////
    public static void TimerMoveQueue()
    {
      Queue.MoveQueue();
    }
  }
}
