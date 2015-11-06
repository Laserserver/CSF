using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
  class Program
  {
    static void Main(string[] args)
    {
      Point p1 = new Point(3, 7, '*');
      p1.SetSymbol();
      Point p2 = new Point(7, 6, '&');
      p2.SetSymbol();
      Console.ReadLine();
    }
  }
}
