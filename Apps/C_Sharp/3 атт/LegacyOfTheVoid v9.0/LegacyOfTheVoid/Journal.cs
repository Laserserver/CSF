using System.Collections.Generic;

namespace ProjectRed
{
  class Journal
  {
    public List<ClassLesson> Lessons;
    public List<Group> Groups;
    public List<MarksForClass> StudMarks;

    public Journal(List<ClassLesson> Lessons, List<Group> Groups, List<MarksForClass> StudMarks)
    {
      this.Groups = Groups;
      this.Lessons = Lessons;
      this.StudMarks = StudMarks;
    }
  }
}