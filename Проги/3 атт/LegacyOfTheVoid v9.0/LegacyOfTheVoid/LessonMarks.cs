using System.Collections.Generic;

namespace ProjectRed
{
  class LessonMarks //Экемпляр урока с листом оценок
  {
    public string LessonName;
    public string[] Names;
    public List<string> Dates;
    public bool[] IsWas;
    public string[,] MarksMatrix;
    public string[] MiddleMarks;

    public LessonMarks(string LessonName, string[] Names, List<string> Dates, string[,] MarksMatrix, string[] MiddleMarks, bool[] IsWas)
    {
      this.MarksMatrix = MarksMatrix;
      this.Dates = Dates;
      this.Names = Names;
      this.LessonName = LessonName;
      this.MiddleMarks = MiddleMarks;
      this.IsWas = IsWas;
    }
  }
}