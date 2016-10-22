using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsYaisp1
{
  class Program
  {
    static void Main(string[] args)
    {
    }
  }
  public class Class2
  {
    public string this[string index]
    {
      get { return index; }
    }
  }
  public class Class3
  {
    int c, d;
    public Class3(int c, int d)
    {
      this.c = c;
      this.d = d;
    }
    public Class3() : base()
    {
     
    }
    
  }
  
  static class Mixin
  {
    public static void ActionN(this IActrive active, int Num)
    {
      for (int i = 0; i < Num; i++)
      {
        if (active.Active)
          active.Action();
      }
    }

  }
  public interface IActrive
  {
    void Action();
    bool Active { get; }
  }
}
