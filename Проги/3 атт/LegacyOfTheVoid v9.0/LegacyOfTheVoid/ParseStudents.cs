using System.Collections.Generic;

namespace ProjectRed
{
  class ParseStudents
  {
    public static List<Group> GetGroupList(string InputText)  //Парсер названий классов и их контента ЕПТА
    {
      string[] Rows = InputText.Split('\n');  //Расщепление на массив строк
      int GroupCount = int.Parse(Rows[0]);    //1 строка, кол-во классов
      int Pos = 2;                            //Вторая позиция - третья в документе - кол-во дебилов в первом классе
      List<Group> Groups = new List<Group>(); //Лист экземпляров групп

      for (int i = 0; i < GroupCount; i++)
      {
        int GroupStudCount = int.Parse(Rows[Pos]);  //Кол-во дебилов
        string[] Names = new string[GroupStudCount];
        int Temp = 0;
        for (int k = 0; k < GroupStudCount; k++)
        {
          Names[k] = Rows[k + Pos + 1].Remove(Rows[Pos + 1 + k].Length - 1);
          Temp = k;   //Присваивание значения счетчика временной переменной
        }
        Groups.Add(new Group(Rows[Pos - 1].Remove(Rows[Pos - 1].Length - 1), Names));
        Pos += Temp + 3;   //Что-то из черной магии
      }
      return Groups;
    }
  }
}