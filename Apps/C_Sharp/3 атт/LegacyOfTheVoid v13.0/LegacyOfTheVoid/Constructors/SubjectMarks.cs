using System.Collections.Generic;

namespace ProjectRed
{
  class SubjectMarks //Экемпляр урока с листом оценок
  {
    public string[,] MarksMatrix;
    public string[] MiddleMarks;

    public SubjectMarks(string[,] MarksMatrix, string[] MiddleMarks)
    {
      this.MarksMatrix = MarksMatrix;
      this.MiddleMarks = MiddleMarks;
    }
  }
}