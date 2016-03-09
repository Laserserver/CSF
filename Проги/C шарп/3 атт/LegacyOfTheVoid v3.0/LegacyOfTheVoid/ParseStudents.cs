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
    public static bool GetClassList(XDocument Students, out string[] ClassLst)
    {
      List<string> ClassList = new List<string>(); //Лист классов
      ClassLst = new string[0];
      if (Students != null)
        foreach (string Validator in Students.Descendants("ValidStuds"))  //Проверка на валидность файла списка студентов        
          if (Validator == "545k#cOFj$qM2LbnEY")
          {
            foreach (string Class in Students.Descendants("name"))
              ClassList.Add(Class);
            ClassLst = new string[ClassList.Count];
            for (int i = 0; i < ClassList.Count; i++)
              ClassLst[i] = ClassList[i];
            return true; //Если не пустой документ, то возвращает труЪ
          }
      return false;
    }

    public static void GetStudentList(XDocument Students, out string[] NameList, int Num) //Получаем документ и индекс позиции списка данного класса, возвращаем массив имен
    {
      List<string> StudsList = new List<string>(); //Лист студентов
      foreach (string Names in Students.Descendants("n"))
        StudsList.Add(Names);
      NameList = Splitter(StudsList[Num]); //Берем из листа по индексу Num массив имен студентов
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
