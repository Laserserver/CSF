using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15_6
{
  class ListLogicClass
  {
    public ListNodeClass ListHead;

    public ListLogicClass()
    {
      ListHead = null;
    }

    public void AddToList(double Value)
    {
      ListNodeClass NewNode = new ListNodeClass(Value, ListHead);
      ListHead = NewNode;
    }
  }
}
