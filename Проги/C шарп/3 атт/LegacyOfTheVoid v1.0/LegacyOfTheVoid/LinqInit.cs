using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace ProjectRed
{
  class LinqInit
  {
    string Name;
    string Disc;
    public LinqInit(string Name, string Disc)
    {
      this.Name = Name;
      this.Disc = Disc;
    }

    public XElement LinqExec()
    {
      XElement student = new XElement("student");
      XAttribute studentName = new XAttribute("name", Name);
      XElement studentDiscipline = new XElement("discipline", Disc);
      XElement studentMarks = new XElement("marks", "1 2 3 4 5 6 1 3 4 4 5");

      student.Add(studentName);
      student.Add(studentDiscipline);
      student.Add(studentMarks);

      return student;
    }

  }
}

