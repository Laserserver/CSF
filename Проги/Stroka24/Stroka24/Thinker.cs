using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stroka24
{
  class Thinker
  {
    public static bool Finder(string Phrase, string LetterFromBox, out string Answer)
    {
      Answer = null;
      string Str = null;
      char Temp, Letter;
      int  k = 0;
      if (LetterFromBox.Length == 1)
      {
        Letter = LetterFromBox[0];
          Temp = Phrase[0];
          if (Letter == Temp)
          {
            while (Temp != 32 && k < Phrase.Length)
            {
              Str += Temp;
              k++;
              Temp = Phrase[k];
            }
            if (Str.Length % 2 == 0)
            {
              Answer += Str + ' ';
              Str = null;
            }
            else
              Str = null;
          }
          for (int i = k; i < Phrase.Length; i++)
          {
            Temp = Phrase[i];
            if (Letter == Temp && Phrase[i - 1] == 32)
            {
              k = i;
              while (Temp != 32 && k < Phrase.Length)
              {
                Str += Temp;
                k++;
                if (k == Phrase.Length)
                  break;
                Temp = Phrase[k];                
              }
              if (Str.Length % 2 == 0)
              {
                Answer += Str + ' ';
                Str = null;
              }
              else
                Str = null;
              i = k;
            }
          }
          if (Answer == null)
            Answer = "Слов, подходящих условию, нет.";
        return true;        
      }      
        else
      {
        if (LetterFromBox.Length > 1)
          Answer = "Вы ввели несколько символов для поиска.";
        else
        Answer = "Вы не ввели символ для поиска.";
        return false;       
      }
    }
  }
}