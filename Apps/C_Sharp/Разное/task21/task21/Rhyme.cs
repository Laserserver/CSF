using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task21
{
  class Rhyme
  {
    static MyList mylist;

    public static void InMyList(int N)
    {
      mylist = new MyList();
      for (int i = 1; i <= N; i++)
      {
        mylist.InList(i);
      }
    }

    public static int LastNumber(int k)
    {
      int i = k - 1;
      if (mylist == null)
        return 0;
      while (mylist.count != 1)
      {
        mylist.Delete(i);
        for (int j = 1; j <= k - 1; j++)
        {
          if (i >= mylist.count)
            i = 0;
          i++;
        }
      }
      int number = mylist.ReturnHead();
      return number;
    }

    public static int Test(int k)
    {
      Node tempnode = mylist.tail;
      while (mylist.count != 1)
      {
        for (int i = 1; i < k; i++)
          tempnode = tempnode.next;
        if (tempnode.next == mylist.tail)
        {
          tempnode.next = tempnode.next.next;
          mylist.tail = tempnode;
        }
        else
        if (tempnode.next == mylist.head)
        {
          tempnode.next = tempnode.next.next;
          mylist.head = tempnode;
        }
        else
         if (tempnode == mylist.tail)
        {
          mylist.tail.next = mylist.tail.next.next;
          tempnode = mylist.tail;
        }
        else
          if (tempnode == mylist.head)
        {
          mylist.head.next = mylist.head.next.next;
          tempnode = mylist.head;
        }
        else
          tempnode.next = tempnode.next.next;
        mylist.count--;
      }

      return mylist.head.inf;
    }
  }
}
