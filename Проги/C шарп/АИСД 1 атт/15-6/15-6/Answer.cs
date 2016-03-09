using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15_6
{
  class Answer
  {
    public static int Go(ListLogicClass InputList)
    {
      bool High = true;
      bool Down = false;
      double MinEl = int.MaxValue;
      double MaxEl = int.MinValue;
      ListNodeClass Head = InputList.ListHead;

      if (Head != null)
      {
        do
        {
          MaxEl = Head.NodeValue;
          MinEl = Head.NodeValue;
          Head = Head.NodeNext;
          if (Head != null)
          {
            if (MinEl < Head.NodeValue && High)
              High = true;
            else
              High = false;

            if (!High)
            {
              if (MaxEl > Head.NodeValue)
                Down = true;
              else
              {
                Down = false;
                break;
              }
            }
          }
        }
        while (Head != null);
      }

      switch (High)
      {
        case true:
          return 1;

        case false:
          if (Down)
            return 2;
          else
            return 3;
      }
      return 3;
    }
  }
}
