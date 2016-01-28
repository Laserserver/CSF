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
    public static bool ClassParse(XDocument Lessons, out List<string> ClassList)
    {
      ClassList = new List<string>(); //Лист классов
      if (Lessons != null)
        foreach (string Validator in Lessons.Descendants("ValidLess"))
          if (Validator == "545k#cOFj$qM2LbnEY")
          {
            foreach (XElement ClassNum in Lessons.Element("Lessons").Elements("Class")) //Считывание списка классов            
              ClassList.Add(ClassNum.Attribute("num").Value);
            return true;
          }
      return false;
    }

    public static void thing(XDocument Lessons)
    {
      List<string> Classes = new List<string>();
      List<string> LessList = new List<string>();
      List<string> Texts = new List<string>();
      foreach (var xclass in Lessons.Elements("Class"))
      {
        Console.WriteLine(xclass.Attribute("num").Value);
        foreach (var xlesson in xclass.Elements("lesson"))
        {
          Console.WriteLine("\t" + xlesson.Attribute("id").Value);
          foreach (var xtext in xlesson.Elements("text"))
          {
            Console.WriteLine("\t\t" + xtext.Attribute("date").Value);
          }
        }
      }
    }

    public static void LessonParse(XDocument Lessons, string Class, out List<string> Less)
    {
      Less = new List<string>();
      foreach (XElement LessonType in Lessons.Element("Lessons").Elements("Class").Elements("lesson")) //Возвращает список предметов
      {
        Less.Add(LessonType.Attribute("id").Value);
      }
    }
    public static void DateEventParse(XDocument Lessons, string Class, string LessonType, out List<string> Dates, out List<string> Texts)
    {
      Dates = new List<string>();
      Texts = new List<string>();
      foreach (XElement Date in Lessons.Element("Lessons").Elements("Class").Elements("lesson").Elements("text")) //Возвращает список дат и текстов предметов
      {
        Dates.Add(Date.Attribute("date").Value);
        Texts.Add(TextDeriver(Date.Value));
      }
    }
    private static string TextDeriver(string Input) //Выделяет среднюю строку текста
    {
      string[] TextMess = Input.Split('\n');
      return TextMess[1].TrimStart();
    }
  }
}
