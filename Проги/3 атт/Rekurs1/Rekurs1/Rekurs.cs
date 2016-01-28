using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rekurs1
{
  class Rekurs
  {
    string Input = null;
    int i = 0;
    public static int DoIt(string Text, int k)
    {
      if (k != Text.Length)
      {
        if (Text[k] == ',')
          return 1 + DoIt(Text, ++k);
        else
          return DoIt(Text, ++k);
      }
      else
        return 0;
    }
  }
}