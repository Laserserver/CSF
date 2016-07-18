using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace ProjectRed
{
  class Person
  {
    XmlDocument StudList;
    XmlNode element;
    string Name;
    string StudId;

    public Person(XmlDocument StudList, XmlNode element, string Name, string StudId)
    {
      this.StudList = StudList;
      this.element = element;
      this.Name = Name;
      this.StudId = StudId;
    }
    public void Lol()
    {  
      StudList.DocumentElement.AppendChild(element);
      XmlNode stud = StudList.CreateElement(StudId);
      stud.InnerText = Name;
      element.AppendChild(stud);
    }
  }
}
