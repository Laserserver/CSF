using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
  public class FuckingStackLogic
  {
    public static FuckingStackClass Parser(string Input)
    {
      FuckingStackClass newstack = new FuckingStackClass();
      int leng = Input.Length;
      for (int i = 0; i < leng; i++)
        if (!_FindSymbol(Input[i]))
          newstack.FuckingStackAdd(Input[i]);
      return newstack;
    }

    static bool _FindSymbol(char symb)
    {
      bool ok = false;
      char[] collect = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
      for (int i = 0; i < 10; i++)
        if (collect[i] == symb)
        {
          ok = true;
          break;
        }
      return ok;
    }

    public static string ReturnShit(FuckingStackClass stack)
    {
      string text = "";
      while (stack.stackHead != null)
        text += stack.FuckingStackTake();
      return text;
    }
  }
}
