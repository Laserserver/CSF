using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ProjectRed
{
  class ParseStudents
  {

    public static bool GetClassNamesLettersList(XDocument Students, out List<string> ClassList, out List<char> Letters, out List<string[]> Names)
    {
      Letters = new List<char>();
      ClassList = new List<string>();
      Names = new List<string[]>();

      if (Students != null)
        foreach (string Validator in Students.Descendants("ValidStuds"))  //Проверка на валидность файла списка студентов        
          if (Validator == "545k#cOFj$qM2LbnEY")
          {
            foreach (string Class in Students.Descendants("name"))
              ClassList.Add(Class);

            foreach (string Letter in Students.Descendants("let"))
              if (Letter != "")
                Letters.Add(Letter[0]);
              else
                Letters.Add(' ');

            foreach (string NameList in Students.Descendants("n"))
              Names.Add(Splitter(NameList));

            return true; //Если не пустой документ, то возвращает труЪ
          }
      return false;
    }

    private static string[] Splitter(string Input)
    {
      string[] words = Input.Split('\n');
      string[] New = new string[words.Length - 2];
      for (int i = 1; i < words.Length - 1; i++)
        New[i - 1] = words[i].TrimStart();
      return New;
    }
  }
}
