using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace YaispTwoEight
{
  public delegate void ChangeUI();
  public static class MainUnitProcessor
  {
    public static Graphics Canv;
    public static Thread Moving;
    public static CashBox MainMachine;
    public static int MinValueMult = 1, MaxValueMult = 1; //Хранятся в виде .1 мультипликаторов
    public static Collections.CustomerQueue Queue;
    public static Collections.Customer CurrentCustomer;

    public static void Thread_Queue_Moving()
    {
      Queue = new Collections.CustomerQueue();
      while (true)
      {
        Queue.MoveQueue();
        Thread.Sleep(5);
      }
    }
    public static void Thread_Queue_Adding()
    {
      Random Rnd = new Random();
      while (true)
      {
        if (Queue != null && Queue.ReturnCount() < 5)
          Queue.AddToQueue();
        Thread.Sleep(Rnd.Next(1, 10) * 1000);
      }
    }
    public static void Thread_CashBox()
    {
      while (true)
        if (MainMachine.GetActiveState() && CurrentCustomer != null)
        {
          int Tries = 3;
          bool Flag = false;
          while (Tries > 0 && !Flag)
          {
            Flag = OrderSum(CurrentCustomer.ReturnDesire());
            Thread.Sleep(2000);
            if (!Flag)
              CurrentCustomer.RethinkDesire();
            Tries--;
          }
          MainMachine.Deactivate();
          CurrentCustomer.ChangeDisp(Flag);
          Queue.MoveFirstOut();
        }
    }
    public static void Thread_Customer()
    {
      while (true)
        if (CurrentCustomer != null && CurrentCustomer.WasServed())
        {
          while (CurrentCustomer.ReturnPos() < 790)
          {
            CurrentCustomer.StartMoving(3);
            CurrentCustomer.MoveCustomer();
            Thread.Sleep(10);
          }
        }
    }
    public static void Thread_Drawing()
    {
      while (true)
      {
        MainForm.MainDrawMethod();
        Thread.Sleep(1);
      }
    }

    public static void PlaceCashBox()
    {
      MainMachine = new CashBox();
      DrawingClass.DrawCashBox();
    }
    public static void StartQueueing()
    {
      //////////////////////////////////////
    }
    public static void MoveOutFirst()
    {

      CurrentCustomer.StartMoving(3);

    }
    public static void ServeCustomer()
    {
      while (true)
        if (MainMachine.GetActiveState())
        {
          int Tries = 3;
          bool Flag = false;
          while (Tries > 0 && !Flag)
          {
            Flag = OrderSum(CurrentCustomer.ReturnDesire());
            Thread.Sleep(5000);
            if (!Flag)
              CurrentCustomer.RethinkDesire();
            Tries--;
          }
          CurrentCustomer.ChangeDisp(Flag);
          Queue.MoveFirstOut();
        }
    }
    public static void StartShow()
    {
      /* Random Rnd = new Random();
       Queue = new Collections.CustomerQueue();
       for (int i = 0; i < 3; i++)
       {
         Queue.AddToQueue();
         MainForm.MainDrawMethod();
         while (!Queue.MoveQueue())
         {
           MainForm.MainDrawMethod();
           System.Threading.Thread.Sleep(1);
         }
         Queue.MoveSpace();
         MainMachine.ServeCustomer(CurrentCustomer);
         System.Threading.Thread.Sleep(5000);
         Queue.MoveFirstOut();
         System.Threading.Thread.Sleep(Rnd.Next(1, 10) * 1000);
       }*/
    }
    public static bool OrderSum(int Value)
    {
      return MainMachine.OrderMoneySum(Value);
    }
  }
}
