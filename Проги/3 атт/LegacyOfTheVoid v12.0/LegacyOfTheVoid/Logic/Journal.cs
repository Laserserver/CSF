using System.Collections.Generic;
using System;

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

    public static Journal Parse(string input)
    {
      string[] New = input.Split(';');

      List<Group> Groups = GetGroupList(New[0]);
      List<ClassSubject> Subjects = GetSubjectsPlan(New[1]);
      List<ClassMarks> ClassMarks = new List<ClassMarks>();

      string[] Rows = New[2].Replace("\r", "").Split('\n');
      
      int Pos = 2;
      string[,] ClassMarksMatrix;
      string[] MiddleMarks;
      int SubjectCount;

      for (int i = 0; i < int.Parse(Rows[0]); i++)
      {
        List<SubjectMarks> LessonType = new List<SubjectMarks>();
        SubjectCount = int.Parse(Rows[Pos - 1]);
        for (int k = 0; k < SubjectCount; k++)
        {        
          MiddleMarks = new string[int.Parse(Rows[Pos])];
          int Temp = 0;
          for (int l = 0; l < int.Parse(Rows[Pos]); l++)
          {
            MiddleMarks[l] = Rows[Pos + 1 + l];
            Temp++;
          }
          Pos += Temp + 1; //10

          ClassMarksMatrix = new string[int.Parse(Rows[Pos]), int.Parse(Rows[Pos + 1])];

          Temp = Pos;
          for (int l = 0; l < int.Parse(Rows[Temp]); l++)
          {
            int TempH = 0;
            for (int h = 0; h < int.Parse(Rows[Pos + 1]); h++, TempH++)
              ClassMarksMatrix[l, h] = Rows[Pos + 2 + h];
            Pos += TempH + 1;
          }
          Pos++;
          LessonType.Add(new SubjectMarks(ClassMarksMatrix, MiddleMarks));
        }
        ClassMarks.Add(new ClassMarks(LessonType));
        Pos++;
      }
      return new Journal(Subjects, Groups, ClassMarks);
    }

    public static List<ClassSubject> GetSubjectsPlan(string Input)
    {
      List<ClassSubject> ClassSubjectsList = new List<ClassSubject>(); //Изначальный лист
      string[] Rows = Input.Replace("\r", "").Split('\n');
      int ClassNum = int.Parse(Rows[0]);
      int SubjectCount;
      int Pos = 2;

      for (int i = 0; i < ClassNum; i++)
      {
        List<Subject> Subject = new List<Subject>();
        SubjectCount = int.Parse(Rows[Pos]);
        for (int j = 0; j < SubjectCount; j++)
        {
          string SubjectName = Rows[Pos + 1];
          int ThemeCount = int.Parse(Rows[Pos + 2]);
          List<Lesson> Lessons = new List<Lesson>();
          int Temp = 0;

          for (int k = 0; k < ThemeCount; k++)
          {
            Lessons.Add(new Lesson((Rows[Pos + 3 + k * 4]), Rows[Pos + 4 + k * 4], int.Parse(Rows[Pos + 5 + k * 4]), Convert.ToBoolean(Rows[Pos + 6 + k * 4])));
            Temp = k;
          }
          Pos += 6 + Temp * 4;
          Subject.Add(new Subject(SubjectName, Lessons));
        }
        Pos += 2;
        ClassSubjectsList.Add(new ClassSubject(Subject));
      }
      return ClassSubjectsList;
    }

    public static List<Group> GetGroupList(string Input)
    {
      string[] Rows = Input.Replace("\r", "").Split('\n');  //Расщепление на массив строк
      int GroupCount = int.Parse(Rows[0]);    //1 строка, кол-во классов
      int Pos = 2;                            //Вторая позиция - третья в документе - кол-во дебилов в первом классе
      List<Group> Groups = new List<Group>(); //Лист экземпляров групп

      for (int i = 0; i < GroupCount; i++)
      {
        int GroupStudCount = int.Parse(Rows[Pos]);
        string[] Names = new string[GroupStudCount];
        int Temp = 0;
        for (int k = 0; k < GroupStudCount; k++)
        {
          Names[k] = Rows[k + Pos + 1];
          Temp = k;   //Присваивание значения счетчика временной переменной
        }
        Groups.Add(new Group(Rows[Pos - 1], Names));
        Pos += Temp + 3;
      }
      return Groups;
    }

    public string Save()
    {
      string Studs = null;
      Studs = Convert.ToString(Groups.Count) + "\n";
      for (int i = 0; i < Groups.Count; i++)
      {
        Studs += Groups[i].GroupName + "\n";
        Studs += Groups[i].StudNames.Length + "\n";
        for (int k = 0; k < Groups[i].StudNames.Length; k++)
          Studs += Groups[i].StudNames[k] + "\n";
      }

      string Less = Convert.ToString(ClassSubjects.Count) + "\n";
      for (int i = 0; i < ClassSubjects.Count; i++)
      {
        Less += "== \n" + ClassSubjects[i].Subjects.Count + "\n";
        for (int k = 0; k < ClassSubjects[i].Subjects.Count; k++)
        {
          Less += ClassSubjects[i].Subjects[k].LessonName + "\n" + ClassSubjects[i].Subjects[k].Lessons.Count + "\n";
          for (int l = 0; l < ClassSubjects[i].Subjects[k].Lessons.Count; l++)          
              Less += ClassSubjects[i].Subjects[k].Lessons[l].Date + "\n" +
                ClassSubjects[i].Subjects[k].Lessons[l].Theme + "\n" +
                ClassSubjects[i].Subjects[k].Lessons[l].Type + "\n" +
                ClassSubjects[i].Subjects[k].Lessons[l].State + "\n";                      
        }
      }

      string Out = Convert.ToString(ClassMarks.Count) + "\n";
      for (int i = 0; i < ClassMarks.Count; i++)
      {
        Out += ClassMarks[i].SubjectMarks.Count + "\n";
        for (int k = 0; k < ClassMarks[i].SubjectMarks.Count; k++)
        {
          Out += ClassMarks[i].SubjectMarks[k].MiddleMarks.Length + "\n";
          for (int j = 0; j < ClassMarks[i].SubjectMarks[k].MiddleMarks.Length; j++)
            Out += ClassMarks[i].SubjectMarks[k].MiddleMarks[j] + "\n";
          Out += ClassMarks[i].SubjectMarks[k].MarksMatrix.GetLength(0) + "\n";
          for (int j = 0; j < ClassMarks[i].SubjectMarks[k].MarksMatrix.GetLength(0); j++)
          {
            Out += ClassMarks[i].SubjectMarks[k].MarksMatrix.GetLength(1) + "\n";
            for (int l = 0; l < ClassMarks[i].SubjectMarks[k].MarksMatrix.GetLength(1); l++)
              Out += ClassMarks[i].SubjectMarks[k].MarksMatrix[j, l] + "\n";
          }
        }
      }
      return Studs + ';' + Less + ';' + Out;
    }
  }
}