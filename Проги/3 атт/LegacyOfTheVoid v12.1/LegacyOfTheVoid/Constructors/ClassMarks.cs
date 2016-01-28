using System.Collections.Generic;

namespace ProjectRed
{
  class ClassMarks  //Экземпляр оценок группы по всем ее предметам
  {
    public List<SubjectMarks> SubjectMarks;

    public ClassMarks(List<SubjectMarks> SubjectMarks)
    {
      this.SubjectMarks = SubjectMarks;
    }
  }
}