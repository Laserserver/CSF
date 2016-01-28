using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;

namespace ProjectRed
{
  class ParseLessons
  {
    public static bool ClassParse(XDocument Lessons, out string[] ClassIds) //Считывание ID классов разметочных
    {
      ClassIds = new string[0]; //Лист классов
      if (Lessons != null)
        foreach (string Validator in Lessons.Descendants("ValidLess"))
          if (Validator == "545k#cOFj$qM2LbnEY")
          {
            foreach (string ClassNum in Lessons.Descendants("Class"))         
              ClassIds = HelpDeriver(ClassNum);
            return true;
          }
      return false;
    }

    public static string[] LessonParse(XDocument Lessons, string Class)  //Возвращает список предметов 
    {
      string[] New = new string[0];
      foreach (string Lesson in Lessons.Element("Lessons").Elements(Class).Elements("LessIds"))      
        New = HelpDeriver(Lesson);
      return New;
    }

    public static List<string> LessonTextsParse(XDocument Lessons, string ClassID, out List<string> Texts, out string LessName)
    {
      List<string> Dates = new List<string>();
      Texts = new List<string>();
      LessName = null;

      foreach (string Name in Lessons.Descendants(ClassID).Elements("less").Elements("name"))
        LessName = TextDeriver(Name);

      foreach (string Date in Lessons.Descendants(ClassID).Elements("less").Elements("date"))
        Dates.Add(TextDeriver(Date));

      foreach (string Text in Lessons.Descendants(ClassID).Elements("less").Elements("text"))
        Texts.Add(TextDeriver(Text));

      return Dates;
    }


    public static List<string> DelParse(XDocument Lessons, string Class, string LessonType, string DataType) //Возвращает список текстов класса если DataType = text и дат если date
    {
      List<string> Data = new List<string>();
      foreach (string Text in Lessons.Descendants(Class).Elements(LessonType).Elements(DataType)) //Можно получить Class и lesson
        Data.Add(TextDeriver(Text));  //Мы получаем одну строку, поэтому однострочный дерайвер
      return Data;
    }

    private static string[] HelpDeriver(string Input) //Возвращает массив строк
    {
      string[] TextMess = Input.Split('\n');
      string[] New = new string[TextMess.Length - 2];
      for (int i = 1; i < TextMess.Length - 1; i++)
        New[i - 1] = TextMess[i].TrimStart();
      return New;
    }

    private static string TextDeriver(string Input) //Возвращает среднюю строку текста
    {
      string[] TextMess = Input.Split('\n');
      if (TextMess.Length == 1)
        return TextMess[0].TrimStart();
      else
        return TextMess[1].TrimStart();
    }
  }
}
