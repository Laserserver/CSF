using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ProjectRed
{
  class Heart
  {
    public static void InitDebils()
    {
      XDocument Debili = new XDocument();
      XElement studentList = new XElement("Students");

      studentList.Add(Sucker("Дрыщ Прыщавых", "ТФКП"));
      studentList.Add(Sucker("Говнарь Патлатов", "Дифуры"));
      studentList.Add(Sucker("Шланг Волосатов", "ТФКП"));
      studentList.Add(Sucker("Камаз Навозов", "История"));
      studentList.Add(Sucker("Батруха Иисусов", "Прога"));
      studentList.Add(Sucker("Витек Мартынов", "Матан"));

      Debili.Add(studentList);
      Debili.Save("Students.xml");
    }
    private static XElement Sucker(string Name, string Disc)
    {
      LinqInit Idiot = new LinqInit(Name, Disc);
      return Idiot.LinqExec();
    }
  }
}
