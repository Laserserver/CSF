using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Render
{
  public static class MainUnitProcessor
  {
    
    public static ModelClass Model = new ModelClass();

    public static void ParseModel(string Input)
    {
      Model.Parse(Input);
      Model.SendData();
    }
  }
}
