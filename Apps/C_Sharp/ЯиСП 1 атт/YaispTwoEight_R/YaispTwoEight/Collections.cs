using System.Drawing;

namespace YaispTwoEight
{
  public static class Collections
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
      private int X;
      private int Y;
      private int Type;

      public MoneyStack(int X, int Y, int Type)
      {
        this.X = X;
        this.Y = Y;
        this.Type = Type;
      }
      public void FillMoneyStack(int Nominal)
      {
        int Rnd = MainUnitProcessor.Rnd.Next(0, 100);
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
      public void TakeMoneyFromStack(int Count)
      {
        for (int i = 0; i < Count; i++)
          _PopNote();
      }

      public int ReturnStackCash()
      {
        return Type * structure_Count;
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
        int[] MoneyStacksCount = new int[6];
        NodeClass n = structure_Head;
        int i = 0;
        while (n != null)
        {
          MoneyStacksCount[i] = ((MoneyStack)n.GetData()).ReturnStackCount();
          n = n.node_NextNode;
          i++;
        }
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
      public void DrawCustomer(Graphics g)
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
        if (Moving == 3)
          g.DrawEllipse(Pens.Black, X + 25, Y - 20, 4, 4);
        else
          g.DrawEllipse(Pens.Black, X + 10, Y - 20, 4, 4);
        g.FillEllipse(Brushes.Black, X + 5, Y - 85, 10, 10);
        g.FillEllipse(Brushes.Black, X + 25, Y - 85, 10, 10);
        g.DrawString(Desire.ToString() + " p.", new Font("Arial", 10), Brushes.Black, X + 5, Y - 50);
        g.DrawEllipse(Pens.Black, Rect);

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
      public void TakeMoneyFromMachine(bool DidIGotMoney)
      {
        GotMoney = DidIGotMoney;
        if (DidIGotMoney)
          State = 2;
        else
          State = 3;
      }
      public void BurnTry()
      {
        Tries--;
      }
      public void RethinkDesire()
      {
        Desire = MainUnitProcessor.GetRandomMoneyCount();
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
      public bool GotServeState()
      {
        return GotMoney;
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
      public void ReDrawQueue(Graphics G)
      {
        NodeClass TempNode = structure_Head;
        for (int i = 0; i < structure_Count; i++)
        {
          if (TempNode != null)
          {
            ((Customer)TempNode.GetData()).DrawCustomer(G);
            TempNode = TempNode.node_NextNode;
          }
        }
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