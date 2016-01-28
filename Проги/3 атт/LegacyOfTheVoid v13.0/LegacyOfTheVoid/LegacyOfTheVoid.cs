using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ProjectRed
{
  public partial class LegacyOfTheVoid : Form
  {
    FolderBrowserDialog fbd = new FolderBrowserDialog();
    OpenFileDialog ofd = new OpenFileDialog();
    Journal Jour = new Journal(null, null, null);
    bool AllowMiddle; //Разрешатель расчета средних значений

    enum NumIDs //=======================================================================ИД типов занятий
    {
      Лекция,       //0
      Практика,     //1
      Семинар,      //2
      Аттестация,   //3
      Экзамен,      //4
      Зачет         //5
    }

    public LegacyOfTheVoid() //==========================================================Форма
    {
      InitializeComponent();
      ofd.DefaultExt = "*.txt";
      ofd.Filter = "TXT files|*.txt";
    }

    //--------------------------------------------------------------------------------Кнопки

    private void loadJournal_Click(object sender, EventArgs e) //========================Загрузка журнала из выбранного файла 
    {
      if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        try
        {
          AllowMiddle = false;
          ResetData();
          GetJournalToProgram();
          DrawClassListOnGrid();
          AllowMiddle = true;
          chbStudList.Checked = true;
          chbLessonList.Checked = true;
        }
        catch
        {
          MessageBox.Show("Невозможно открыть выбранный файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ResetData() //==========================================================Сброс таблиц и листов 
    {
      Jour = new Journal(null, null, null);
      gridClasses.ColumnCount = 0;
      gridSubjectNames.ColumnCount = 0;
      gridThisSubjectLessons.ColumnCount = 0;
      gridMiddleMarks.ColumnCount = 0;
      gridStudentMarks.ColumnCount = 0;
      gridStudentNames.ColumnCount = 0;
    }

    private void saveJournal_Click(object sender, EventArgs e) //========================Сохранение журнала в файл 
    {
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.DefaultExt = "*.txt";
      sfd.Filter = "TXT files|*.txt";
      if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)           
        File.WriteAllText(sfd.FileName, Jour.Save());      
    }

    private void menuLoadStudList_Click(object sender, EventArgs e) //===================Загрузка файла студентов 
    {
      if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        try
        {
          GetStudsFileToProgram();
          DrawClassListOnGrid();
          chbStudList.Checked = true;
          AllowMiddle = true;
        }
        catch
        {
          MessageBox.Show("Файл студентов отформатирован неверно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void menuLoadLessonList_Click(object sender, EventArgs e) //=================Загрузка файла плана  
    {
      if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        try
        {
          GetLesssFileToProgram();
          chbLessonList.Checked = true;
        }
        catch
        {
          MessageBox.Show("Файл уроков отформатирован неверно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    //--------------------------------------------------------------------------------Получатели файлов в распоряжение программы

    private void GetStudsFileToProgram() //==============================================Получение файла студентов 
    {
      StreamReader Txt = new StreamReader(ofd.FileName);
      Jour.GetGroups(Txt.ReadToEnd());
      Txt.Close();
      if (chbLessonList.Checked == true)
        MatrixPreLoader();
    }

    private void GetLesssFileToProgram() //==============================================Получение учебного плана 
    {
      StreamReader Txt = new StreamReader(ofd.FileName);
      Jour.GetSubjects(Txt.ReadToEnd());
      Txt.Close();
      if (chbStudList.Checked == true)
        MatrixPreLoader();
    }

    private void GetJournalToProgram()   //==============================================Получение и парсинг файла журнала 
    {
      StreamReader Txt = new StreamReader(ofd.FileName);
      Jour.Parse(Txt.ReadToEnd());

      chbLessonList.Checked = true;
      chbStudList.Checked = true;
      Txt.Close();
    }

    //--------------------------------------------------------------------------------Спецфункции таблиц оценок

    private void MatrixPreLoader()  //===================================================Предсоздание матриц оценок 
    {
      Jour.ClassMarks = new List<ClassMarks>();  //Всеобщий лист оценок

      for (int i = 0; i < Jour.Groups.Count; i++)
      {
        List<SubjectMarks> GroupMarks = new List<SubjectMarks>();  //Лист оценок конкретных групп
        for (int j = 0; j < Jour.ClassSubjects[i].Subjects.Count; j++)
        {
          string[,] Matrix = new string[Jour.Groups[i].StudNames.Length, Jour.ClassSubjects[i].Subjects[j].Lessons.Count];
          string[] MiddleMarks = new string[Jour.Groups[i].StudNames.Length];
          GroupMarks.Add(new SubjectMarks(Matrix, MiddleMarks));
        }
        Jour.ClassMarks.Add(new ClassMarks(GroupMarks));
      }
    }

    private void GetDataFromGrids(int ClassID, int SubjectID, int RowNumber, int ColNumber) //=============Сбор оценок в объект
    {
      //====Средний балл
      List<string> MarksRow = new List<string>();
      for (int i = 0; i < gridStudentMarks.ColumnCount; i++)
        if (gridStudentMarks.Rows[RowNumber].Cells[i].Value != null)
          MarksRow.Add(Convert.ToString(gridStudentMarks.Rows[RowNumber].Cells[i].Value));
      if (MarksRow.Count != 0)
        if (Convert.ToString(MiddleLogics.Middle(MarksRow)) != "NaN")
          gridMiddleMarks.Rows[RowNumber].Cells[0].Value = MiddleLogics.Middle(MarksRow);
        else
          gridMiddleMarks.Rows[RowNumber].Cells[0].Value = "";
      //====Чекбоксы
      for (int i = 0; i < gridStudentMarks.RowCount; i++)
      {
        if (Convert.ToString(gridStudentMarks.Rows[i].Cells[ColNumber].Value) != "")
        {
          Jour.ClassSubjects[ClassID].Subjects[SubjectID].Lessons[ColNumber].State = true;
          gridThisSubjectLessons.Rows[ColNumber].Cells[3].Value = true;
          break;
        }
        else
        {
          Jour.ClassSubjects[ClassID].Subjects[SubjectID].Lessons[ColNumber].State = false;
          gridThisSubjectLessons.Rows[ColNumber].Cells[3].Value = false;
        }
      }
      //====Вообще все оценки
      for (int i = 0; i < gridStudentMarks.RowCount; i++)
        for (int j = 0; j < gridStudentMarks.ColumnCount; j++)
        {
          Jour.ClassMarks[ClassID].SubjectMarks[SubjectID].MarksMatrix[i, j] = Convert.ToString(gridStudentMarks.Rows[i].Cells[j].Value);
          Jour.ClassMarks[ClassID].SubjectMarks[SubjectID].MiddleMarks[i] = Convert.ToString(gridMiddleMarks.Rows[i].Cells[0].Value);
        }
    }
      
    private void LoadDataToGrids(int ClassID, int SubjectID)  //===========================================Вывод оценок из объекта
    {
      //====Вывод оценок
      for (int i = 0; i < gridStudentMarks.RowCount; i++)
        for (int j = 0; j < gridStudentMarks.ColumnCount; j++)
        {
          gridStudentMarks.Rows[i].Cells[j].Value = Jour.ClassMarks[ClassID].SubjectMarks[SubjectID].MarksMatrix[i, j];
          gridMiddleMarks.Rows[i].Cells[0].Value = Jour.ClassMarks[ClassID].SubjectMarks[SubjectID].MiddleMarks[i];
        }
      //====Вывод чекбоксов
      for (int i = 0; i < Jour.ClassSubjects[ClassID].Subjects[SubjectID].Lessons.Count; i++)
        gridThisSubjectLessons.Rows[i].Cells[3].Value = Jour.ClassSubjects[ClassID].Subjects[SubjectID].Lessons[i].State;
    }

    //--------------------------------------------------------------------------------Рисовалки

    private void DrawClassListOnGrid() //================================================Разрисовка списка классов 
    {
      gridClasses.RowCount = Jour.Groups.Count;
      for (int i = 0; i < Jour.Groups.Count; i++)
        gridClasses.Rows[i].Cells[0].Value = Jour.Groups[i].GroupName;
    }

    private void DrawNamesAndSubjectsGrid(int ClassNum) //====================================Разрисовка списка имен и предметов этого класса 
    {
      gridStudentNames.RowCount = Jour.Groups[ClassNum].StudNames.Length;
      for (int i = 0; i < Jour.Groups[ClassNum].StudNames.Length; i++)
        gridStudentNames.Rows[i].Cells[0].Value = Jour.Groups[ClassNum].StudNames[i];
      gridStudentNames.Columns[0].HeaderText = "Дата";
      gridStudentNames.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
      //=======Имена сверху, предметы снизу
      gridSubjectNames.RowCount = Jour.ClassSubjects[ClassNum].Subjects.Count;
      for (int i = 0; i < Jour.ClassSubjects[ClassNum].Subjects.Count; i++)
        gridSubjectNames.Rows[i].Cells[0].Value = Jour.ClassSubjects[ClassNum].Subjects[i].LessonName;
      gridSubjectNames.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    }

    private void DrawClassSubjThemeDateAndMarksGrid(int ClassNum, int LessonNum) //Разрисовка тем, дат, статусов занятий + средних оценок и общих оценок 
    {
      gridStudentMarks.RowCount = gridStudentNames.RowCount;
      gridStudentMarks.ColumnCount = Jour.ClassSubjects[ClassNum].Subjects[LessonNum].Lessons.Count;

      gridMiddleMarks.RowCount = gridStudentNames.RowCount;

      for (int i = 0; i < gridStudentMarks.ColumnCount; i++)
        gridStudentMarks.Columns[i].Width = 40;
      for (int i = 0; i < Jour.ClassSubjects[ClassNum].Subjects[LessonNum].Lessons.Count; i++)
        gridStudentMarks.Columns[i].HeaderText = Jour.ClassSubjects[ClassNum].Subjects[LessonNum].Lessons[i].Date;

      gridMiddleMarks.Columns[0].Width = 67;
      gridMiddleMarks.Columns[0].HeaderText = "Среднее";
      gridMiddleMarks.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
      foreach (DataGridViewColumn column in gridStudentMarks.Columns)
        column.SortMode = DataGridViewColumnSortMode.NotSortable;

      //=====

      gridThisSubjectLessons.RowCount = Jour.ClassSubjects[ClassNum].Subjects[LessonNum].Lessons.Count;
      gridThisSubjectLessons.ColumnCount = 3;
      gridThisSubjectLessons.Columns.Insert(3, new DataGridViewCheckBoxColumn(false));

      for (int i = 0; i < Jour.ClassSubjects[ClassNum].Subjects[LessonNum].Lessons.Count; i++)
      {
        gridThisSubjectLessons.Rows[i].Cells[0].Value = Jour.ClassSubjects[ClassNum].Subjects[LessonNum].Lessons[i].Date;
        gridThisSubjectLessons.Rows[i].Cells[1].Value = Jour.ClassSubjects[ClassNum].Subjects[LessonNum].Lessons[i].Theme;
        gridThisSubjectLessons.Rows[i].Cells[2].Value = (NumIDs)Jour.ClassSubjects[ClassNum].Subjects[LessonNum].Lessons[i].Type;
        gridThisSubjectLessons.Rows[i].Cells[3].Value = false;
      }

      gridThisSubjectLessons.Columns[0].Width = 35;
      gridThisSubjectLessons.Columns[1].Width = 120;
      gridThisSubjectLessons.Columns[2].Width = 65;
      gridThisSubjectLessons.Columns[3].Width = 47;

      gridThisSubjectLessons.Columns[0].HeaderText = "Дата";
      gridThisSubjectLessons.Columns[1].HeaderText = "Тема";
      gridThisSubjectLessons.Columns[2].HeaderText = "Тип";
      gridThisSubjectLessons.Columns[3].HeaderText = "Статус";

      for (int i = 0; i < 3; i++)
        gridThisSubjectLessons.Columns[i].ReadOnly = true;
      foreach (DataGridViewColumn column in gridThisSubjectLessons.Columns)
        column.SortMode = DataGridViewColumnSortMode.NotSortable;
    }

    //--------------------------------------------------------------------------------Обработчики событий 

    private void gridClasses_CellClick(object sender, DataGridViewCellEventArgs e) //====Обработчик события нажатия клетки в gridClasses 
    {
      if (chbLessonList.Checked == true)
      {       
          gridStudentMarks.Columns.Clear();
          gridThisSubjectLessons.Columns.Clear();
          gridMiddleMarks.Columns.Clear();
          DrawNamesAndSubjectsGrid(e.RowIndex);       
      }
      else
        MessageBox.Show("Не загружен учебный план.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private void gridLessonNames_CellClick(object sender, DataGridViewCellEventArgs e) //Обработчик события нажатия ячейки в таблице предметов 
    {
      gridStudentMarks.Columns.Clear();
      gridMiddleMarks.Columns.Clear();
      gridThisSubjectLessons.Columns.Clear();
      DrawClassSubjThemeDateAndMarksGrid(gridClasses.CurrentCellAddress.Y, gridSubjectNames.CurrentCellAddress.Y);      
      LoadDataToGrids(gridClasses.CurrentCellAddress.Y, e.RowIndex);
    }

    private void gridStudentMarks_CellEndEdit(object sender, DataGridViewCellEventArgs e)//Обработчик события переключения на другую ячейку в табле оценок 
    {
      if (AllowMiddle)      
        GetDataFromGrids(gridClasses.CurrentCellAddress.Y, gridSubjectNames.CurrentCellAddress.Y, e.RowIndex, e.ColumnIndex);      
    }

    //--------------------------------------------------------------------------------Весь мусор тут

    private void menuHelp_Click(object sender, EventArgs e) //===========================Помощь 
    {
      MessageBox.Show("Чтобы начать работу с программой, откройте меню Файл и добавьте списки учеников и учебные планы.", "Помощь");
    }

    private void menuClose_Click(object sender, EventArgs e) //==========================Закрыть форму 
    {
      this.Close();
    }

    private void helpAbout_Click(object sender, EventArgs e) //==========================Моя излишняя гордыня :3 
    {
      MessageBox.Show("Разработчик данного школьного журнала - студент 1 курса ФКН, ВГУ Леонтьев Максим (aka Mexahoid).", "О программе");
    }
  }
}