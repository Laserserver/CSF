using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stroka24
{
  class Thinker
  {
    public static string[] Finder(string Phrase, char Letter)
    {
      string[] Arr = new string[1];   //  d  djdk jdk dddd dsfadsad
      bool flag = false;              //012345678901234567890123456
      string Str = null;              //0        10        20    26
      int j = 0;
      for (int i = 0; i < Phrase.Length; i++)
      {        
        if (!flag && Phrase[i] == Letter)
        {
          flag = Phrase[i] != ' ';
          while (i < Phrase.Length && Phrase[i] != ' ')
            Str += Phrase[i++];
          if (Str != null && Str.Length % 2 == 0)
          {
            Arr[j] = Str;
            j++;
            Array.Resize(ref Arr, j + 1);
          }
          Str = null;
        }
        if (i < Phrase.Length)
        flag = Phrase[i] != ' ';
      }
      Array.Resize(ref Arr, Arr.Length - 1);
      return Arr;
    }
  }
}