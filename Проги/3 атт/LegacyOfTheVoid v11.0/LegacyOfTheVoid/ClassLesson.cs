using System.Collections.Generic;

namespace ProjectRed
{
  class ClassLesson
  {
    public string ClassName;
    public List<Subject> Subjects;

    public ClassLesson(string ClassName, List<Subject> Subjects)
    {
      this.ClassName = ClassName;
      this.Subjects = Subjects;
    }
  }
}