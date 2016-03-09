using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;

namespace ProjectRed
{
  class LinqInit
  {
    string[] DiscList = { "Matan", "TFKP", "History", "Proga", "Difur" };
    string[] DiscNames = { "Матан", "ТФКП", "История", "Программирование", "Дифуры" };
    string Name;       //Имя студента
    string DiscString; //Название предмета
    string StudNum;    //Номер элемента студента
    string DiscNametag; //Тэг предмета

    public LinqInit(string Name, string DiscString, string StudNum, string DiscNametag)
    {
      this.Name = Name;
      this.DiscString = DiscString;
      this.StudNum = StudNum;
      this.DiscNametag = DiscNametag;
    }
    public void AddElement(XElement Element)
    {
      XDocument StudList = XDocument.Load("Students.xml");
      StudList.Add(Element);
      StudList.Save("Students.xml");
    }
    public XElement LinqExec() //Добавление студента
    {
      XElement student = new XElement(StudNum);
      XAttribute studentName = new XAttribute("name", Name);
      student.Add(studentName);   //Добавление поля имени студента

      return student;  //Возврат всего элемента
    }

    public static void AddLessons(XElement Lessons, string DisTag, string DisName)
    {
        XAttribute LessonName = new XAttribute(DisTag, DisName);
      
    }
  }
}

