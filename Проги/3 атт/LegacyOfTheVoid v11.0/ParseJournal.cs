using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectRed
{
  class ParseJournal
  {
    public static void SplitJournal(string Input, out string StudList, out string LessonList, out string JournalData)
    {
      string[] Arr = Input.Split(';');
      StudList = Arr[0];
      LessonList = Arr[1]; //Собссно, удаляет \n из начала строки
      JournalData = Arr[2];
    }

    public static List<MarksForClass> ParseJournalData(string Input)
    {
      List<MarksForClass> Marks = new List<MarksForClass>();
      string[] Rows = Input.Split('\n');
      string ClassName = null;

      List<LessonMarks> LessonType;

      int Pos = 2;

      string LessonName;
      List<string> Dates = new List<string>();
      bool[] IsWas;
      string[,] MarksMatrix;
      string[] MiddleMarks;
      int LessonCount;
      int ClassCount = int.Parse(Rows[0]);

      for (int i = 0; i < ClassCount; i++)
      {
        LessonCount = int.Parse(Rows[Pos]);
        ClassName = Rows[Pos - 1];
        LessonType = new List<LessonMarks>();
        for (int k = 0; k < LessonCount; k++)
        {
          LessonName = Rows[Pos + 1];
          IsWas = new bool[int.Parse(Rows[Pos + 2])];
          int TempL = 0;
          for (int l = 0; l < int.Parse(Rows[Pos + 2]); l++, TempL++)
          {
            Dates.Add(Rows[Pos + 3 + 2*l]);
            IsWas[l] = bool.Parse(Rows[Pos + 4 + 2*l]);
          }
          Pos += 5 + (TempL - 1) * 2;
          MiddleMarks = new string[int.Parse(Rows[Pos])];

          TempL = 0;
          for (int l = 0; l < int.Parse(Rows[Pos]); l++, TempL++)
            MiddleMarks[l] = Rows[Pos + 1 + l];
          Pos += TempL + 1; //21
          ////
          MarksMatrix = new string[int.Parse(Rows[Pos]), int.Parse(Rows[Pos + 1])];

          TempL = Pos;
          for (int l = 0; l < int.Parse(Rows[TempL]); l++)
          {
            int TempH = 0;
            for (int h = 0; h < int.Parse(Rows[Pos + 1]); h++, TempH++)            
              MarksMatrix[l, h] = Rows[Pos + 2 + h];            
            Pos += TempH + 1;
          }          
          LessonType.Add(new LessonMarks(LessonName, Dates, MarksMatrix, MiddleMarks, IsWas));
        }
        Marks.Add(new MarksForClass(ClassName, LessonType));
        Pos += 2;
      }
      return Marks;
    }

    public static List<ClassLesson> GetLessonsList(string Input)
    {
      List<ClassLesson> LessonsList = new List<ClassLesson>(); //Изначальный зерг^W лист
      string[] Rows = Input.Replace("\r", "").Split('\n'); //Расщепление на массив строк
      int ClassNum = int.Parse(Rows[0]); //Получение кол-ва классов
      int LessonCount; //Первая позиция кол-ва предметов первого класса
      int Pos = 2;

      for (int i = 0; i < ClassNum; i++)
      {
        string ClassName = Rows[Pos - 1];
        List<Subject> LessonReal = new List<Subject>();
        LessonCount = int.Parse(Rows[Pos]);
        for (int j = 0; j < LessonCount; j++)
        {
          List<string> Dates = new List<string>();
          List<string> Themes = new List<string>();
          List<int> Types = new List<int>();
          string LessonName = Rows[Pos + 1];
          int ThemeCount = int.Parse(Rows[Pos + 2]);

          int Temp = 0;

          for (int k = 0; k < ThemeCount; k++)
          {
            Themes.Add(Rows[Pos + 3 + k * 3]);
            Dates.Add(Rows[Pos + 4 + k * 3]);
            Types.Add(int.Parse(Rows[Pos + 5 + k * 3]));
            Temp = k;
          }
          Pos += 5 + Temp * 3;
          LessonReal.Add(new Subject(LessonName, Dates, Themes, Types));
        }
        Pos += 2;
        LessonsList.Add(new ClassLesson(ClassName, LessonReal));
      }
      return LessonsList;
    }

    public static List<Group> GetGroupList(string InputText)  //Парсер названий классов и их контента
    {
      string[] Rows = InputText.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);  //Расщепление на массив строк
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
          Names[k] = Rows[k + Pos + 1];
          Temp = k;   //Присваивание значения счетчика временной переменной
        }
        Groups.Add(new Group(Rows[Pos - 1], Names));
        Pos += Temp + 3;
      }
      return Groups;
    }
  }
}
