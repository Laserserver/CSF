using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegExer
{
  public static class Logics
  {
    public static List<string> Logins;
    public static List<string> Passes;
    public static List<string> Urls;
    public static string Text;
    public static void Parser(string Input)
    {
      Regex Url = new Regex(@"(URL-адрес\s+: .+\n)");
      Regex Log = new Regex(@"(Пользователь\s+: .+\n)");
      Regex Pas = new Regex(@"(Пароль\s+: .+\n)");
      Match LogMatch = Log.Match(Input);
      Match PasMatch = Pas.Match(Input);
      Match UrlMatch = Url.Match(Input);
      
      while (UrlMatch.Success)
      {
        Urls.Add(UrlMatch.Groups[1].Value);
        UrlMatch = UrlMatch.NextMatch();
      }
      while (LogMatch.Success)
      {
        Logins.Add(LogMatch.Groups[1].Value);
        LogMatch = LogMatch.NextMatch();
      }
      while (PasMatch.Success)
      {
        Passes.Add(PasMatch.Groups[1].Value);
        PasMatch = PasMatch.NextMatch();
      }
      SetOutText();
    }

    public static void SetOutText()
    {
      int OCunt = Logins.Count;
      for (int i = 0; i < OCunt; i++)
        Text += Urls[i] + Logins[i] + Passes[i] + '\n';
    }
  }
}
