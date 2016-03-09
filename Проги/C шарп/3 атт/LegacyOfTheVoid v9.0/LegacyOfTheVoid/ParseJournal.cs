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

      List<LessonMarks> LessonType = new List<LessonMarks>();

      int Pos = 2;

      string[] Names;
      string LessonName;
      List<string> Dates = new List<string>();
      bool[] IsWas;
      string[,] MarksMatrix;
      string[] MiddleMarks;
      int LessonCount = int.Parse(Rows[Pos]);
      int ClassCount = int.Parse(Rows[0]);

      for (int i = 0; i < ClassCount; i++)
      {
        ClassName = Rows[Pos - 1];
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
          //56
          Names = new string[int.Parse(Rows[Pos + 1])];
          TempL = 0;
          for (int l = 0; l < int.Parse(Rows[Pos + 1]); l++, TempL++)          
            Names[l] = Rows[Pos + 2 + l];          
          Pos += TempL + 1;
          LessonType.Add(new LessonMarks(LessonName, Names, Dates, MarksMatrix, MiddleMarks, IsWas));
        }
        Marks.Add(new MarksForClass(ClassName, LessonType));
        Pos += 2;
      }
      return Marks;
    }
  }
}
