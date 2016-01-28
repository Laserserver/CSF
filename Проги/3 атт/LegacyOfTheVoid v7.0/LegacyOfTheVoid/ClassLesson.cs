using System.Collections.Generic;

namespace ProjectRed
{
  class ClassLesson
  {
    public string ClassID;
    List<Lesson> Lessons;

    public ClassLesson(string ClassID, List<Lesson> Lessons)
    {
      this.ClassID = ClassID;
      this.Lessons = Lessons;
    }
  }
}
