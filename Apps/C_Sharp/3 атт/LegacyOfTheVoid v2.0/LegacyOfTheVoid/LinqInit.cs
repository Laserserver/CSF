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
    string[] DiscList = new string[9];
    string Name;
    string Disc;
    string StudNum;
    string DiscName;
    XElement student;

    public LinqInit(string Name, string Disc, string StudNum, string DiscName)
    {
      this.Name = Name;
      this.Disc = Disc;
      this.StudNum = StudNum;
      this.DiscName = DiscName;
    }

    public XElement LinqExec()
    {
      student = new XElement(StudNum);
      XAttribute studentName = new XAttribute("name", Name);
      
      student.Add(studentName);
     
      return student;
    }
    private void AddLesson()
    {
      XElement studentDiscipline = new XElement(DiscName, Disc);
      XElement studentMarks = new XElement("marks" + DiscName, "1 2 3 4 5 6 1 3 4 4 5");
      student.Add(studentDiscipline);
      student.Add(studentMarks);
    }

  }
}

