using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;

namespace ProjectRed
{
  public class Enum
  {
    public static void MakeXml()
    {
      XmlTextWriter TextWrite = new XmlTextWriter("Studs.xml", Encoding.UTF8);
      TextWrite.WriteStartDocument();
      TextWrite.WriteStartElement("head");
      TextWrite.WriteEndElement();
      TextWrite.Close();
      /*}
      public static void New()
      {*/
      XmlDocument StudList = new XmlDocument();
      StudList.Load("Studs.xml");

      XmlNode element = StudList.CreateElement("element");
      StudList.DocumentElement.AppendChild(element);

      XmlAttribute attribute = StudList.CreateAttribute("number");
      attribute.Value = "1";

      element.Attributes.Append(attribute);

      XmlNode stud1 = StudList.CreateElement("1");
      stud1.InnerText = "Первый дебил";
      element.AppendChild(stud1);

      element.Attributes.Append(attribute);

      XmlNode stud2 = StudList.CreateElement("2");
      stud2.InnerText = "Второй дебил";
      element.AppendChild(stud2);

      MakeDebil(StudList, element, "Третий дебил", "3");
      MakeDebil(StudList, element, "Четвертый дебил", "4");

      StudList.Save("Studs.xml");
    }

    private static void MakeDebil(XmlDocument StudList, XmlNode element, string Name, string StudId)
    {
      Person Debil = new Person(StudList, element, Name, StudId);
      Debil.Lol();
    }
    public static void Gusi()
    {

    }
  }
}
