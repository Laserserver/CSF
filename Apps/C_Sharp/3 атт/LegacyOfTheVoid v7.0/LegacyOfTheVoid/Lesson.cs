using System.Collections.Generic;

namespace ProjectRed
{
  class Lesson
  {
    public string LessonName;
    public List<string> Dates;
    public List<string> Texts;

    public Lesson(string LessonName, List<string> Dates, List<string> Texts)
    {
      this.LessonName = LessonName;
      this.Dates = Dates;
      this.Texts = Texts;
    }
  }
}
