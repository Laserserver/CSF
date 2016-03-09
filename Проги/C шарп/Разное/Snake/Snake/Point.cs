using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
  class Point
  {
    public int x;
    public int y;
    public char sm;

    public Point()
    {      
    }

    public Point(int x, int y, char sm)
    {
      this.x = x;
      this.y = y;
      this.sm = sm;
    }

    public void SetSymbol()
    {
      Console.SetCursorPosition(x, y);
      Console.Write(sm);
    }
  }
}
