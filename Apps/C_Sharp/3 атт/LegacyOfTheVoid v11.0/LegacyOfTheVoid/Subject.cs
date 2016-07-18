using System.Collections.Generic;

namespace ProjectRed
{
  class Subject
  {
    public string LessonName;
    public List<int> Types;
    public List<string> Dates;
    public List<string> Themes;

    public Subject(string LessonName, List<string> Dates, List<string> Themes, List<int> Types)
    {
      this.Types = Types;
      this.LessonName = LessonName;
      this.Dates = Dates;
      this.Themes = Themes;
    }
  }
}