using System.Collections.Generic;

namespace ProjectRed
{
  class LessonMarks //Экемпляр урока с листом оценок
  {
    public string LessonName;
    public string[] Names;
    public List<string> Dates;
    public string[,] MarksMatrix;

    public LessonMarks(string LessonName, string[] Names, List<string> Dates, string[,] MarksMatrix)
    {
      this.MarksMatrix = MarksMatrix;
      this.Dates = Dates;
      this.Names = Names;
      this.LessonName = LessonName;
    }
  }
}