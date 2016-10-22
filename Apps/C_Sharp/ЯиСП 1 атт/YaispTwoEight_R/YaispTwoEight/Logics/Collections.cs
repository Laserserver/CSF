using System.Drawing;
using System;
using System.Collections.Generic;

namespace YaispTwoEight
{
  public class Collections
  {
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
      public class NodeClass
      {
        private object node_Data;
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
      private int Nominal;
      public Note(int Nominal)
      {
        this.Nominal = Nominal;
      }
    }
    public class MoneyStack : CustomCollection
    {
      private int Nominal;

      public MoneyStack(int Nominal)
      {
        this.Nominal = Nominal;
      }
      public void FillMoneyStack()
      {
        int Rnd = MainUnitProcessor.GetRandomInteger();
        for (int i = 0; i < Rnd; i++)
          Add(new Note(Nominal));
      }
      public void TakeMoneyFromStack(int Count)
      {
        for (int i = 0; i < Count; i++)
          _PopNote();
      }
      public int ReturnNominal()
      {
        return Nominal;
      }
      public int ReturnStackCash()
      {
        return Nominal * structure_Count;
      }
      public int ReturnStackCount()
      {
        return structure_Count;
      }

      private void _PopNote()
      {   //Проверки на пустоту не нужно
        structure_Head = structure_Head.node_NextNode;
        structure_Count--;
      }
    }
    public class MoneyList : CustomCollection
    {
      public int[,] GetMoneyArray()
      {
        NodeClass n = structure_Head;
        MoneyStack Temp;
        int[,] Out = new int[structure_Count, 2];
        int i = 0;
        while (n != null)
        {
          Temp = n.GetData() as MoneyStack;
          Out[i, 0] = Temp.ReturnNominal();
          Out[i, 1] = Temp.ReturnStackCount();
          i++;
          n = n.node_NextNode;
        }
        return Out;
      }
      public void FillMoney(int[] Nominals)
      {
        MoneyStack MoneyStack;
        int L = Nominals.Length;
        for (int i = 0; i < L; i++)
        {
          MoneyStack = new MoneyStack(Nominals[i]);
          MoneyStack.FillMoneyStack();
          Add(MoneyStack);
        }
      }

      public MoneyStack ReturnByIndex(int index)
      {
        int Ind = 0;
        NodeClass n = structure_Head;
        while (Ind != index && n != null)
        {
          n = n.node_NextNode;
          Ind++;
        }
        return (MoneyStack)n.GetData();
      }
      public int[] ReturnMoneyStackCount()
      {
        int[] MoneyStacksCount = new int[MainUnitProcessor.GlobalNominals.Length];
        NodeClass n = structure_Head;
        int i = 0;
        while (n != null)
        {
          MoneyStacksCount[i] = ((MoneyStack)n.GetData()).ReturnStackCount();
          n = n.node_NextNode;
          i++;
        }
        //Array.Sort(MoneyStacksCount, (x, y) => -x.CompareTo(y));
        return MoneyStacksCount;
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
      private int X, Y;
      private int Shirt;
      private int Pants;
      private int Tries;
      private int Moving;
      private int Desire;
      private int State;
      private bool GotMoney;

      public Customer()
      {
        GotMoney = false;
        X = 690;
        Y = 265;
        Tries = 3;
        Moving = 1;
        State = 1;
        MainUnitProcessor.GetRandomShirtAndPants(out Pants, out Shirt);
        Desire = MainUnitProcessor.GetRandomMoneyCount();
      }
      public int[] GetParameters()
      {
        return new int[7] { X, Y, Shirt, Pants, State, Moving, Desire };
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
      public void TakeResponse(CashBox.ResponseCode Code)
      {
        switch (Code)
        {
          case CashBox.ResponseCode.Good:
            State = 2;
            GotMoney = true;
            break;
          case CashBox.ResponseCode.TryToAbs:
            Tries--;
            if (Tries == 2)
            {
              Desire /= 100;
              Desire *= 100;
            }
            else if (Tries == 1)
            {
              Desire /= 1000;
              Desire *= 1000;
            }
            State = 4;
            break;
          case CashBox.ResponseCode.NotEnoughMoney:
            Tries--;
            if (Tries != 0)
            {
              Desire = MainUnitProcessor.GetRandomMoneyCount(Desire);
              State = 4;
            }
            else
              State = 3;
            break;
        }
      }
      public void MoveToExit()
      {
        Moving = 3;
      }

      public int GetPosition()
      {
        return X;
      }
      public int GetMoneyDesire()
      {
        return Desire;
      }
      public int GetTriesCount()
      {
        return Tries;
      }
      public bool WasServed()
      {
        return GotMoney;
      }
      public void StartThinking()
      {
        State = 4;
      }
    }
    public class CustomerQueue : CustomCollection
    {
      private int[] Spaces;
      private NodeClass structure_Tail;

      public CustomerQueue() : base()   //Для того, чтобы расширить конструктор CustomCollection
      {
        structure_Tail = null;
        Spaces = new int[5] { 200, 260, 320, 380, 440 };
      }
      public void AddToQueue()
      {
        NodeClass Cust = new NodeClass(new Customer(), null);
        structure_Count++;
        if (structure_Head == null)
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
      public List<int[]> ReDrawQueue()
      {
        List<int[]> Out = new List<int[]>();
        NodeClass TempNode = structure_Head;
        for (int i = 0; i < structure_Count; i++)
        {
          if (TempNode != null)
          {
            Out.Add(((Customer)TempNode.GetData()).GetParameters());
            TempNode = TempNode.node_NextNode;
          }
        }
        return Out;
      }
      public void MoveQueue()
      {
        NodeClass Temp = structure_Head;
        Customer Cust;
        for (int i = 0; i < structure_Count; i++)
        {
          Cust = (Customer)Temp.GetData();
          if (Cust.GetPosition() > Spaces[i])
            Cust.MoveCustomer();
          if (Cust.GetPosition() == 200 && !MainUnitProcessor.MainMachine.GetActiveState())
            MainUnitProcessor.ActivateMachine();
          Temp = Temp.node_NextNode;
        }
      }

      public Customer ReturnHead(bool Referal)
      {
        if (Referal)
          return (Customer)structure_Head.GetData();
        if (structure_Head != null)
        {
          NodeClass Temp = structure_Head;
          if (structure_Head.node_NextNode != null)
            structure_Head = structure_Head.node_NextNode;
          else
            structure_Head = null;
          structure_Count--;
          return (Customer)Temp.GetData();
        }
        else
          return null;
      }
      public int ReturnCount()
      {
        return structure_Count;
      }
    }
  }
}