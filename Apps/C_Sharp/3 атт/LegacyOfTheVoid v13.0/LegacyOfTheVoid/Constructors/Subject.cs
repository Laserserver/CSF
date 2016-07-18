using System.Collections.Generic;

namespace ProjectRed
{
  class Subject
  {
    public string LessonName;
    public List<Lesson> Lessons;

    public Subject(string LessonName, List<Lesson> Lessons)
    {
      this.LessonName = LessonName;
      this.Lessons = Lessons;
    }
  }
}