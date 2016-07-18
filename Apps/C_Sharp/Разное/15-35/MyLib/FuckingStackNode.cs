using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
  public class FuckingStackNode
  {
    public char Symbol;
    public FuckingStackNode nextNode;

    public FuckingStackNode(char Symbol, FuckingStackNode node)
    {
      this.Symbol = Symbol;
      nextNode = node;
    }
  }
}
