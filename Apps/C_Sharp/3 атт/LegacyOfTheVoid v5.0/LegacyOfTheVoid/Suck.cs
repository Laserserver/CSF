using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ProjectRed
{
  class Suck
  {
    string DiscNametag;
    string DiscString;

    public Suck(string DiscNametag, string DiscString)
    {
      this.DiscNametag = DiscNametag;
      this.DiscString = DiscString;
    }
    private void AddMarks() //Добавление оценок студента
    {
      XElement student = new XElement("stud");
      XElement studentDiscipline = new XElement(DiscNametag, DiscString);
      XElement studentMarks = new XElement("marks" + DiscNametag, "1 2 3 4 5 6 1 3 4 4 5");
      student.Add(studentDiscipline);
      student.Add(studentMarks);
    }
  }
}
