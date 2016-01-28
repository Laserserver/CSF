using System.Collections.Generic;

namespace ProjectRed
{
  class Journal
  {
    public List<ClassSubject> ClassSubjects;
    public List<Group> Groups;
    public List<ClassMarks> ClassMarks;

    public Journal(List<ClassSubject> ClassSubjects, List<Group> Groups, List<ClassMarks> ClassMarks)
    {
      this.Groups = Groups;
      this.ClassSubjects = ClassSubjects;
      this.ClassMarks = ClassMarks;
    }

    public void GetGroups(string Input)
    {
      Groups = JournalLogics.GetGroupList(Input);
    }

    public void GetSubjects(string Input)
    {
      ClassSubjects = JournalLogics.GetSubjectsPlan(Input);
    }

    public string Save()
    {
      return JournalLogics.Save(Groups, ClassMarks, ClassSubjects);
    }

    public void Parse(string Input)
    {
      JournalLogics.Parse(Input, out Groups, out ClassSubjects, out ClassMarks);
    }
  }
}
