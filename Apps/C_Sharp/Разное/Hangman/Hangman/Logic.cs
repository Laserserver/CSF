using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
  public class Letter
  {
    public char l_Let;
    public bool l_Vis;
  }

  public static class Logic
  {
    static string[] Words;
    static Letter[] Letters;

    public static void Parser(string Input)
    {
      Words = Input.Split(new string[] { "\r\n" }, StringSplitOptions.None);
    }

    public static void ReturnRand()
    {
      int Cnt = Words.Length;
      Random rnd = new Random();
      string Chosen = Words[rnd.Next(0, Cnt)];
      Cnt = Chosen.Length;
      Letters = new Letter[Cnt];
      for (int i = 0; i < Cnt; i++)
      {
        Letters[i] = new Letter();
        Letters[i].l_Let = Char.ToLower(Chosen[i]);
        Letters[i].l_Vis = false;
      }
      Letters[0].l_Vis = Letters[Cnt - 1].l_Vis = true;
    }

    public static bool Check(char Letter)
    {
      int L = Letters.Length;
      bool flag = false;
      for (int i = 0; i < L; i++)
        if (Letters[i].l_Let == Letter)
          Letters[i].l_Vis = flag = true;
      return flag;
    }

    public static string OutWord(bool IsFull)
    {
      string Out = null;
      int L = Letters.Length;
      if (IsFull)
        for (int i = 0; i < L; i++)
          Out += Letters[i].l_Let + "  ";
      else
        for (int i = 0; i < L; i++)
        {
          Out += Letters[i].l_Vis ? Letters[i].l_Let : '_';
          Out += "  ";
        }
      return Out;
    }
  }
}
