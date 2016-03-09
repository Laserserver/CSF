using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;

namespace ProjectRed
{
  class Heart
  {
    public static void InitDebils()
    {
      XDocument Debili = new XDocument();
      XDeclaration Xdec = new XDeclaration("1.0", "utf-8", "yes");
      XComment Com = new XComment("Не изменяйте нижнюю строчку");
      XElement Stud =  new XElement("StudList",
          new XElement("Class", new XAttribute("ID", 1),
            new XElement("Name", "Витек Мартынов"),
            new XElement("Name", "Батруха Иисусов"),
            new XElement("Name", "Шланг Волосатый")));
      //Debili.Add(Xdec);
      Debili.Add(Stud);
      Debili.Save("Test.xml");
    }
  }
}
