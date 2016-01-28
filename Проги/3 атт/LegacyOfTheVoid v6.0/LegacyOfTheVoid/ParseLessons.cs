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
    public static bool ClassParse(XDocument Lessons, out string[] ClassIds)
    {
      ClassIds = new string[0]; //Лист классов
      if (Lessons != null)
        foreach (string Validator in Lessons.Descendants("ValidLess"))
          if (Validator == "545k#cOFj$qM2LbnEY")
          {
            foreach (string ClassNum in Lessons.Descendants("Class")) //Считывание списка классов            
              ClassIds = HelpDeriver(ClassNum);
            return true;
          }
      return false;
    }

    public static List<string> GetLessonNames(XDocument Lessons, string Class)  //Возвращает список названий   
    {
      List<string> Names = new List<string>();
      foreach (string Lesson in Lessons.Element("Lessons").Elements(Class).Elements("name"))
        Names.Add(TextDeriver(Lesson));
      return Names;
    }
    public static string[] LessonParse(XDocument Lessons, string Class)  //Возвращает список предметов 
    {
      string[] New = new string[0];
      foreach (string Lesson in Lessons.Element("Lessons").Elements(Class).Elements("LessIds"))      
        New = HelpDeriver(Lesson);
      return New;
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
