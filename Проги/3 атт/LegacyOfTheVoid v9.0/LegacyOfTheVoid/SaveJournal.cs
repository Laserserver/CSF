using System.Collections.Generic;

namespace ProjectRed
{
  class SaveJournal
  {
    public static string JournalSaver(string Groups, string Lessons, List<MarksForClass> Marks)
    {
      string Out = Marks.Count.ToString() + "\n";

      for (int i = 0; i < Marks.Count; i++)
      {
        Out += Marks[i].ClassName + "\n";
        Out += Marks[i].Marks.Count + "\n";
        for (int k = 0; k < Marks[i].Marks.Count; k++)
        {
          Out += Marks[i].Marks[k].LessonName + "\n";
          Out += Marks[i].Marks[k].Dates.Count + "\n";
          for (int j = 0; j < Marks[i].Marks[k].Dates.Count; j++)
          {
            Out += Marks[i].Marks[k].Dates[j] + "\n";
            Out += Marks[i].Marks[k].IsWas[j] + "\n";
          }
          //Вывод дат и проведенности занятий
          Out += Marks[i].Marks[k].MiddleMarks.Length + "\n";
          for (int j = 0; j < Marks[i].Marks[k].MiddleMarks.Length; j++)
            Out += Marks[i].Marks[k].MiddleMarks[j] + "\n";
          //Вывод массива средних оценок
          Out += Marks[i].Marks[k].MarksMatrix.GetLength(0) + "\n";
          for (int j = 0; j < Marks[i].Marks[k].MarksMatrix.GetLength(0); j++)
          {
            Out += Marks[i].Marks[k].MarksMatrix.GetLength(1) + "\n";
            for (int l = 0; l < Marks[i].Marks[k].MarksMatrix.GetLength(1); l++)            
              Out += Marks[i].Marks[k].MarksMatrix[j, l] + "\n";            
          }
          //Вывод матрицы оценок
          Out += Marks[i].Marks[k].Names.Length + "\n";
          for (int j = 0; j < Marks[i].Marks[k].Names.Length; j++)
            Out += Marks[i].Marks[k].Names[j] + "\n";
        }
      }
      return Groups + ';' + Lessons + ';' + Out;
    }
  }
}