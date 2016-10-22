using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAISP1._8
{
  public static class LoTVLogics
  {
    public static void ColorText(string Text, char color)
    {
      switch (color)
      {
        case 'a':
          Console.ForegroundColor = ConsoleColor.Cyan;
          break;
        case 'e':
          Console.ForegroundColor = ConsoleColor.Red;
          break;
        case 'i':
          Console.ForegroundColor = ConsoleColor.Yellow;
          break;
        case 'h':
          Console.ForegroundColor = ConsoleColor.Green;
          break;
        case 'o':
          Console.ForegroundColor = ConsoleColor.White;
          break;
      }
      Console.WriteLine(Text);
      Console.ResetColor();
    }
  }
}
