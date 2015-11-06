using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Temp
{
    public static class Letter
    {
        public static int NonAlpha(string str, out int i)
        {
            i = 0;
            while (i < str.Length)
            {
                string Letter;
                char s = str[i];
                bool ans = Char.IsLetter(s);
                Letter = Convert.ToString(s);
                i++;
                if (!ans)
                    break;                
            }
            return i;
        }
    }
}
