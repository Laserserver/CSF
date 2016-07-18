using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spisky4
{

  class MyNode     // Узел для списка, стека, очереди
  {
    public string inf;
    public MyNode next;
    public MyNode(string inf, MyNode next)            // Конструктор
    {
      this.inf = inf;
      this.next = next;
    }
  }
  class MyList
  {
    public MyNode head;                      // число элементов

    public MyList()                         // Конструктор
    {
      head = null;
    }

    public void Add(string inf)                // Add
    {
      MyNode p = new MyNode(inf, head);
      head = p;
    }

    public void Clear()
    {
      MyNode p = head;
      head = null;
      while (p != null)
      {
        MyNode q = p;
        p = p.next;
        q.next = null;
        //q.Dispose();
      }
    }

    public string[] Printer()                   // Вывод списка
    {
      string[] st = new string[0];
      int L = 0;
      MyNode p = head;
      if (p != null)
        do
        {
          Array.Resize(ref st, ++L);
          st[L - 1] = p.inf.ToString();
          p = p.next;
        }
        while (p != null);
      return st;
    }

    public MyList SortDel()                   // DeleteBt
    {
      MyList list2 = new MyList();
      MyNode p = head;
      if (p != null)
      {
        list2.Add(p.inf);
        do
        {
          if (p.next != null)
          {
            if (list2.head.inf != p.next.inf)
              list2.Add(p.next.inf);
            p = p.next;
          }
        }
        while (p.next != null);
      }
      return list2;
    }
  }
}
