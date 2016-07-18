using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary
{
  class BinLogics
  {
    public static byte[] ParseBin(string Input)
    {
      byte[] Out = new byte[Input.Length];
      byte i = 0;
      foreach (char Number in Input)
      {
        Out[i] = byte.Parse(Number.ToString());
        i++;
      }
      return Out;
    }

    public static byte[] Calculate(byte[,] Input)
    {
      byte[] Out = new byte[Input.GetLength(1)];
      for (sbyte i = (sbyte)(Input.GetLength(1) - 1); i >= 0; i--)
      {
        byte Res = (byte)(Input[0, i] + Input[1, i]);
        switch (Res)
        {
          case 0:
          case 1:
            Out[i] = Res;
            break;
          case 2:
            Out[i] = 0;
            Input[0, i - 1]++;
            break;
          case 3:
            Out[i] = 1;
            Input[0, i - 1]++;
            break;
        }
      }
      return Out;
    }

    public static int[,] Convert(byte[] BinUp, byte[] BinDown, byte[] BinResult)
    {
      int[,] Out = new int[3, 2];
      int[] Oct = new int[2];
      Oct = _ConvertHelp(BinUp);
      Out[0, 0] = Oct[0];
      Out[0, 1] = Oct[1];
      Oct = _ConvertHelp(BinDown);
      Out[1, 0] = Oct[0];
      Out[1, 1] = Oct[1];
      Oct = _ConvertHelp(BinResult);
      Out[2, 0] = Oct[0];
      Out[2, 1] = Oct[1];
      return Out;
    }

    private static int[] _ConvertHelp(byte[] InputMass)
    {
      int[] Out = new int[2];
      int TempOct = 0;
      byte[] NewInputOct;

      for (sbyte k = (sbyte)(InputMass.Length - 1); k >= 0; k--)
        Out[0] += (int)Math.Pow(InputMass[k] * 2, InputMass.Length - 1 - k);

      
        if (InputMass.Length % 3 != 0)
        {
          TempOct = InputMass.Length / 3 + 1;
          NewInputOct = new byte[TempOct * 3];
          for (sbyte i = (sbyte)(TempOct * 3 - 1); i > 0; i--)
            NewInputOct[i] = InputMass[i - TempOct * 3 + 1 + InputMass.Length];
        }
        else
        {
          TempOct = InputMass.Length / 3;
          NewInputOct = InputMass;
        }

        for (sbyte i = (sbyte)(TempOct - 1); i > 0; i--)
        {
          int Mult = 1;
          for (sbyte k = 2; k >= 0; k--)
          {
            Out[1] += (int)(Mult * Math.Pow(InputMass[3 * i - k] * 2, 2 - k));
            Mult *= 10;
          }
        }
      
      return Out;
    }
  }
}
