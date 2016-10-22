using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace YaispTwoEight
{
  public static class Collections
  {
    static Random rnd = new Random();

    public class CustomCollection
    {
      protected NodeClass structure_Head;
      protected int structure_Count;

      protected CustomCollection()
      {
        structure_Head = null;
        structure_Count = 0;
      }
      protected void Add(object Data)
      {
        NodeClass Money = new NodeClass(Data, structure_Head);
        structure_Head = Money;
        structure_Count++;
      }
      public bool IsEmpty()
      {
        return structure_Head == null;
      }
      public class NodeClass
      {
        object node_Data;
        public NodeClass node_NextNode;
        public NodeClass(object Data, NodeClass Next)
        {
          node_Data = Data;
          node_NextNode = Next;
        }
        public object GetData()
        {
          return node_Data;
        }
      }
    }

    public class Note
    {
      int Nominal;
      public Note(int Nominal)
      {
        this.Nominal = Nominal;
      }
    }
    public class MoneyStack : CustomCollection
    {
      int X, Y;
      int Type;

      public MoneyStack(int X, int Y, int Type)
      {
        this.X = X;
        this.Y = Y;
        this.Type = Type;
      }
      public NodeClass PopNote()
      {
        NodeClass Out = null;
        if (structure_Count != 0)
        {
          Out = structure_Head;
          structure_Head = structure_Head.node_NextNode;
          structure_Count--;
        }
        return Out;
      }
      public void FillMoneyStack(int Nominal)
      {
        int Rnd = rnd.Next(0, 100);
        for (int i = 0; i < Rnd; i++)
          Add(new Note(Nominal));
      }
      public void DrawStack(Graphics Canvas)
      {
        Canvas.FillRectangle(DrawingClass.GetColor(Type), X, Y, 35, 20);
        Canvas.DrawRectangle(Pens.Black, X, Y, 35, 20);
        Canvas.DrawString(Type.ToString(), new Font(new FontFamily("Arial"), 11, FontStyle.Bold), Brushes.Black, X, Y + 2);
        Canvas.DrawString(structure_Count.ToString(), new Font(new FontFamily("Arial"), 10, FontStyle.Bold), Brushes.Black, X, Y + 21);
      }
      public int ReturnStackCash()
      {
        return Type * structure_Count;
      }
      public int ReturnStackCount()
      {
        return structure_Count;
      }
    }
    public class MoneyList : CustomCollection
    {
      public NodeClass ReturnByIndex(int index)
      {
        int Ind = 0;
        NodeClass n = structure_Head;
        while (Ind != index && n != null)
          n = n.node_NextNode;
        return n;
      }
      public int[] ReturnMoneyStackCount()
      {
        int[] MoneyStacksCount = new int[6];
        NodeClass n = structure_Head;
        int i = 0;
        while (n != null)
        {
          MoneyStacksCount[i] = ((MoneyStack)n.GetData()).ReturnStackCount();
          n = n.node_NextNode;
        }
        return MoneyStacksCount;
      }
      public void DrawMoney(Graphics g)
      {
        NodeClass n = structure_Head;
        MoneyStack Temp;
        while (n != null)
        {
          Temp = n.GetData() as MoneyStack;
          Temp.DrawStack(g);
          n = n.node_NextNode;
        }
      }
      public void FillMoney()
      {
        bool five = true;
        MoneyStack MoneyStack;
        for (int i = 10; i <= 5000; i *= five ? 5 : 2, five = !five)
        {                                                 //До 50 - 300, до 1000 - 350, больше - 400
          MoneyStack = new MoneyStack(five ? 75 : 125, i / 10 < 10 ? 300 : (i / 100 < 10 ? 350 : 400), i);
          MoneyStack.FillMoneyStack(i);
          Add(MoneyStack);
        }
      }
      public int ReturnAllCashCount()
      {
        int Cash = 0;
        NodeClass n = structure_Head;
        while (n != null)
        {
          Cash += (n.GetData() as MoneyStack).ReturnStackCash();
          n = n.node_NextNode;
        }
        return Cash;
      }
    }

    public class Customer
    {
      int X, Y;
      int Shirt, Pants;
      bool Drawable;
      int Moving;
      int Desire;
      int State;
      public Customer()
      {
        X = 690;
        Y = 265;
        Drawable = true;
        Moving = 1;
        State = 1;
        int tens = rnd.Next(1, 4);
        int fifth = rnd.Next(1, 3);
        Shirt = (fifth == 1 ? 1 : 5) * (tens == 1 ? 10 : tens == 2 ? 100 : 1000);
        fifth = rnd.Next(1, 3);
        tens = rnd.Next(1, 4);
        Pants = (fifth == 1 ? 1 : 5) * (tens == 1 ? 10 : tens == 2 ? 100 : 1000);
        Desire = rnd.Next(MainUnitProcessor.MinValueMult, MainUnitProcessor.MaxValueMult) * 10;
      }
      public void DrawCustomer(Graphics g)
      {
        if (Drawable)
        {
          g.FillRectangle(DrawingClass.GetColor(Shirt), X, Y, 40, 100);
          g.DrawRectangle(Pens.Black, X, Y, 40, 100);
          g.DrawRectangle(Pens.Black, X + 10, Y + 15, 20, 80);
          g.FillRectangle(DrawingClass.GetColor(Pants), X + 5, Y + 100, 30, 100);
          g.DrawRectangle(Pens.Black, X + 5, Y + 100, 30, 100);
          g.DrawEllipse(Pens.Black, X + 5, Y - 30, 30, 30);
          Rectangle Rect = new Rectangle(X - 5, Y - 100, 50, 50);
          switch (State)
          {
            case 1:  //Только идет
              g.FillEllipse(Brushes.Yellow, Rect);
              g.FillRectangle(Brushes.Black, X + 10, Y - 65, 20, 3);
              break;
            case 2:  //Получил
              g.FillEllipse(Brushes.LightGreen, Rect);
              g.FillClosedCurve(Brushes.Black, new Point[6] {
                new Point(X + 10, Y - 68),
                new Point(X + 20, Y - 65),
                new Point(X + 30, Y - 68),
                new Point(X + 30, Y - 65),
                new Point(X + 20, Y - 62),
                new Point(X + 10, Y - 65) });
              break;
            case 3:  //Не получил
              g.FillEllipse(Brushes.Red, Rect);
              g.FillClosedCurve(Brushes.Black, new Point[6] {
                new Point(X + 10, Y - 65),
                new Point(X + 20, Y - 68),
                new Point(X + 30, Y - 65),
                new Point(X + 30, Y - 62),
                new Point(X + 20, Y - 65),
                new Point(X + 10, Y - 62) });
              break;
          }
          g.FillEllipse(Brushes.Black, X + 5, Y - 85, 10, 10);
          g.FillEllipse(Brushes.Black, X + 25, Y - 85, 10, 10);
          g.DrawString(Desire.ToString() + " p.", new Font("Arial", 10), Brushes.Black, X + 5, Y - 50);
          g.DrawEllipse(Pens.Black, Rect);
        }
      }
      public void ServeCustomer(int State)
      {
        this.State = State;
      }
      public bool WasServed()
      {
        return State != 1;
      }
      public int ReturnPos()
      {
        return X;
      }
      public void ChangeDisp(bool Success)
      {
        State = Success ? 2 : 3;
      }
      public int ReturnDesire()
      {
        return Desire;
      }
      public void MoveCustomer()
      {
        switch (Moving)
        {
          case 1:
            --X;
            break;
          case 3:
            ++X;
            break;
        }
      }
      public void CustomerGone()
      {
        Drawable = false;
      }
      public void ActivateCashBox()
      {
        int Tries = 3;
        bool Flag = false;
        while (Tries > 0 && !Flag)
        {
          Flag = MainUnitProcessor.OrderSum(Desire);
          if (!Flag)
            RethinkDesire();
        }
        State = Flag ? 2 : 3;
        Moving = 3;
      }
      public void RethinkDesire()
      {
        Desire = rnd.Next(MainUnitProcessor.MinValueMult, MainUnitProcessor.MaxValueMult) * 10;
      }
      public int GetMoving()
      {
        return Moving;
      }
      public void StopMoving()
      {
        Moving = 2;
      }
      public void StartMoving(int Destination)
      {
        Moving = Destination;
      }
      public void DrawMoving()
      {
        MainUnitProcessor.MainMachine.Deactivate();
        while (X < 790)
        {
          //DrawCustomer(g);
          MoveCustomer();
          System.Threading.Thread.Sleep(1);
        }
      }
    }

    public class CustomerQueue : CustomCollection
    {
      int FreeSpaceX;
      NodeClass structure_Tail;
      public CustomerQueue() : base()
      {
        structure_Tail = null;
        FreeSpaceX = 140;
      }
      public void AddToQueue()
      {
        FreeSpaceX += 60;
        NodeClass Cust = new NodeClass(new Customer(), null);
        structure_Count++;
        if (IsEmpty())
        {
          structure_Head = Cust;
          structure_Tail = Cust;
        }
        else
        {
          structure_Tail.node_NextNode = Cust;
          structure_Tail = Cust;
        }
      }
      public void AddToQueue(NodeClass Node)
      {
        structure_Count++;
        if (IsEmpty())
        {
          structure_Head = Node;
          structure_Tail = Node;
        }
        else
        {
          structure_Tail.node_NextNode = Node;
          structure_Tail = Node;
        }
      }
      public NodeClass PushQueue()
      {
        NodeClass Node = structure_Head;
        structure_Count--;
        structure_Head = structure_Head.node_NextNode;
        return Node;
      }
      public void PushQueueOut()
      {
        structure_Count--;
        structure_Head = structure_Head.node_NextNode;
        FreeSpaceX = 200;
      }
      public int ReturnCount()
      {
        return structure_Count;
      }
      public int ReturnFreeSpace()
      {
        return FreeSpaceX;
      }
      public void ReDrawQueue(Graphics G)
      {
        NodeClass TempNode;
        for (int i = 0; i < structure_Count; i++)
        {
          TempNode = PushQueue();
          ((Customer)TempNode.GetData()).DrawCustomer(G);
          AddToQueue(TempNode);
        }
      }
      public void MoveQueue()
      {
        if (!MainUnitProcessor.MainMachine.GetActiveState())
        {
          NodeClass Temp;
          Customer Cust;
          for (int i = 0; i < structure_Count; i++)
          {
            Temp = PushQueue();
            Cust = (Customer)Temp.GetData();
            if (!(Cust.GetMoving() == 2))
            {
              if (Cust.ReturnPos() > FreeSpaceX)
              {
                //MainForm.MainDrawMethod();
                Cust.MoveCustomer();
              }
              else
              {
                Cust.StopMoving();
                if (Cust.ReturnPos() == 200)
                {
                  MainUnitProcessor.MainMachine.Activate();
                  MainUnitProcessor.CurrentCustomer = Cust;
                }
              }
              if (Cust.ReturnPos() == FreeSpaceX)
                MoveSpace();
            }
            AddToQueue(Temp);
          }
        }
      }
      public void MoveFirstOut()
      {
        Customer Cust = (Customer)structure_Head.GetData();
        Cust.StartMoving(3);
        Cust.CustomerGone();
        PushQueueOut();
      }
      public void MoveSpace()
      {
        FreeSpaceX += 60;
      }
    }
  }
}
