namespace ConsoleApplication1
{
  class Class1
  {
    public static bool Lol(string str1, string str2)
    {
      string s1 = str1, s2 = str2;
      if (str1.Length == str2.Length)
      {
        char[] ch1 = str1.ToCharArray();
        char[] ch2 = str2.ToCharArray();
        bool Flag = true;
        int i = 0;
        while (i < str1.Length && Flag)
        {
          for (int j = 0; j < str1.Length; j++)
          {
            if (ch1[i] == ch2[j])
            {
              Flag = true;
              break;
            }
            else
            {
              Flag = false;
            }
          }
          i++;
        }
        return Flag;
      }
      else 
        return false;
    }
  }
}
