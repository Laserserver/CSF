using System.Collections.Generic;

namespace ProjectRed
{
  class ClassLesson
  {
    public string ClassName;
    public List<Lesson> Lessons;

    public ClassLesson(string ClassName, List<Lesson> Lessons)
    {
      this.ClassName = ClassName;
      this.Lessons = Lessons;
    }
  }
}