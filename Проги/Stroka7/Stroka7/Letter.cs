using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stroka7
{
    class Letter
    {
        public static void NonAlpha(string str, out int i, out bool IsNot)
        {
            i = 0;
            IsNot = true;
            while (i < str.Length)
            {
                char s = str[i];
                i++;
                if ((s >= 'a' && s <= 'z') || (s >= 'A' && s <= 'Z') || (s >= 'а' && s <= 'я') || (s >= 'А' && s <= 'Я'))
                {
                    IsNot = false;
                }
                else
                {
                    IsNot = true;
                    break;
                }
            }
        }
    }
}

