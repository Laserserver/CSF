using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
  public class FuckingStackClass
  {
    public FuckingStackNode stackHead;

    public FuckingStackClass()
    {
      stackHead = null;
    }

    public void FuckingStackAdd(char symbol)
    {
      if (stackHead == null)
        stackHead = new FuckingStackNode(symbol, null);
      else
        stackHead = new FuckingStackNode(symbol, stackHead);
    }

    public char FuckingStackTake()
    {
      char Symb = stackHead.Symbol;
      stackHead = stackHead.nextNode;
      return Symb;
    }
  }
}
