using System.Collections.Generic;

namespace ProjectRed
{
  class MarksForClass  //Экземпляр оценок группы по всем ее предметам
  {
    public string ClassName;
    public List<LessonMarks> Marks;

    public MarksForClass(string ClassName, List<LessonMarks> Marks)
    {
      this.Marks = Marks;
      this.ClassName = ClassName;
    }
  }
}