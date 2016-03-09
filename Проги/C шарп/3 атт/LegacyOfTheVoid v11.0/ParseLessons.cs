using System.Collections.Generic;

namespace ProjectRed
{
  class ParseLessons
  {
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
  }
}