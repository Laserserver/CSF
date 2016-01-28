using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Drawing;
using System.IO;

namespace ProjectRed
{
  public partial class LegacyOfTheVoid : Form
  {
    FolderBrowserDialog fbd = new FolderBrowserDialog();
    OpenFileDialog ofd = new OpenFileDialog();
    List<Group> GroupsList;
    List<ClassLesson> LessonsList;
    List<MarksForClass> WholeMarks = new List<MarksForClass>();  //Лист оценок
    int tempLesson = 0;  //переменная для отсроченного обновления в эвенте gridLessonNames
    int tempClass = 0; //Переменная для отсроч эвента gridClasses
    bool tempFlag = true;
    string Groups;  //Глобальный уровень, т.к. используется неоднократно (дважды)
    string Lessons;

    enum NumIDs
    {
      Лекция,       //0
      Практика,     //1
      Семинар,      //2
      Аттестация,   //3
      Экзамен,      //4
      Зачет         //5
    }   //==================================================================Енум ИД типов занятий

    public LegacyOfTheVoid() //==========================================================Форма
    {
      InitializeComponent();
    }

    //--------------------------------------------------------------------------------Кнопки

    private void loadJournal_Click(object sender, EventArgs e) //========================Загрузка журнала из выбранного файла 0%
    {
      if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        try
        {
          GetJournalToProgram();
          DrawClassListOnGrid();
          chbStudList.Checked = true;
          chbLessonList.Checked = true;
        }
        catch
        {
          MessageBox.Show("Невозможно открыть выбранный файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void saveJournal_Click(object sender, EventArgs e) //========================Сохранение журнала в файл 0%
    {
      SaveFileDialog sfd = new SaveFileDialog();
      if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)      
        File.WriteAllText(sfd.FileName, SaveJournal.JournalSaver(Groups, Lessons));      
    }

    private void menuLoadStudList_Click(object sender, EventArgs e) //===================Загрузка файла дебилов 100% 
    {
      if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        try
        {
          GetStudsFileToProgram();
          DrawClassListOnGrid();
          chbStudList.Checked = true;
        }
        catch
        {
          MessageBox.Show("Невозможно открыть выбранный файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void menuLoadLessonList_Click(object sender, EventArgs e) //=================Загрузка файла плана 100% 
    {
      if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        try
        {
          GetLesssFileToProgram();
          chbLessonList.Checked = true;
        }
        catch
        {
          MessageBox.Show("Невозможно открыть выбранный файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    //--------------------------------------------------------------------------------Получатели файлов в распоряжение программы

    private void GetStudsFileToProgram() //==============================================Получение файла дебилов 100%
    {
      StreamReader Txt = new StreamReader(ofd.FileName);
      Groups = Txt.ReadToEnd();
      GroupsList = ParseStudents.GetGroupList(Groups);
      Txt.Close();
      if (chbLessonList.Checked == true)
        MatrixPreLoader();
    }

    private void GetLesssFileToProgram() //==============================================Получение учебного плана 100%
    {
      StreamReader Txt = new StreamReader(ofd.FileName);
      Lessons = Txt.ReadToEnd();
      LessonsList = ParseLessons.GetLessonsList(Lessons);
      Txt.Close();
      if (chbStudList.Checked == true)
        MatrixPreLoader();
    }

    private void GetJournalToProgram()   //==============================================Получение и парсинг файла журнала 0%
    {
      StreamReader Txt = new StreamReader(ofd.FileName);
      string LessTXT;
      string StudTXT;
      string DataTXT;
      ParseJournal.SplitJournal(Txt.ReadToEnd(), out StudTXT, out LessTXT, out DataTXT);
      LessonsList = ParseLessons.GetLessonsList(LessTXT);
      GroupsList = ParseStudents.GetGroupList(StudTXT);
      //JournalData = 
      Txt.Close();
    }

    //--------------------------------------------------------------------------------Спецфункции таблиц оценок

    private void MatrixPreLoader()  //===================================================Предзапись матриц оценок 100%
    {
      for (int i = 0; i < GroupsList.Count; i++)
      {
        List<LessonMarks> GroupMarks = new List<LessonMarks>();
        for (int j = 0; j < LessonsList[i].Lessons.Count; j++)
        {
          string[,] Matrix = new string[GroupsList[i].StudNames.Length, LessonsList[i].Lessons[j].Dates.Count];
          GroupMarks.Add(new LessonMarks(LessonsList[i].Lessons[j].LessonName, GroupsList[i].StudNames, LessonsList[i].Lessons[j].Dates, Matrix));
        }
        WholeMarks.Add(new MarksForClass(GroupsList[i].GroupName, GroupMarks));
      }
    }

    private void MatrixUpdater(int ClassID, int LessonID) //=============================Обновление матрицы класса ClassID для урока LessonID в листе WholeMarks 100%
    {
      for (int i = 0; i < gridStudentMarks.RowCount; i++)
        for (int j = 0; j < gridStudentMarks.ColumnCount; j++)
          WholeMarks[ClassID].Marks[LessonID].MarksMatrix[i, j] = Convert.ToString(gridStudentMarks.Rows[i].Cells[j].Value);
    }

    private void ReturnMatrixToGrid(int ClassID, int LessonID) //========================Возврат матрицы на форму 100%
    {
      for (int i = 0; i < gridStudentMarks.RowCount; i++)
        for (int j = 0; j < gridStudentMarks.ColumnCount; j++)
          gridStudentMarks.Rows[i].Cells[j].Value = WholeMarks[ClassID].Marks[LessonID].MarksMatrix[i, j];
    }

    //--------------------------------------------------------------------------------Рисовалки

    private void DrawClassListOnGrid() //================================================Разрисовка списка классов 100%
    {
      gridClasses.RowCount = GroupsList.Count;
      for (int i = 0; i < GroupsList.Count; i++)
        gridClasses.Rows[i].Cells[0].Value = GroupsList[i].GroupName;
    }

    private void DrawNamesListOnGrid(int ClassNum) //====================================Разрисовка списка имен 100%
    {
      gridStudentNames.RowCount = GroupsList[ClassNum].StudNames.Length;
      for (int i = 0; i < GroupsList[ClassNum].StudNames.Length; i++)
        gridStudentNames.Rows[i].Cells[0].Value = GroupsList[ClassNum].StudNames[i];
      gridStudentNames.Columns[0].HeaderText = "Дата";
    }

    private void DrawLessonsOfSelectedClassOnGrid(int Num) //============================Разрисовка учебного плана для выбранного класса 100%
    {
      gridLessonNames.RowCount = LessonsList[Num].Lessons.Count;
      for (int i = 0; i < LessonsList[Num].Lessons.Count; i++)
        gridLessonNames.Rows[i].Cells[0].Value = LessonsList[Num].Lessons[i].LessonName;
    }

    private void DrawLessonsThemesAndDates(int LessonNum, int ClassNum) //===============Разрисовка тем, дат и типов занятий 100%
    {
      gridLessonTexts.RowCount = LessonsList[ClassNum].Lessons[LessonNum].Themes.Count;
      gridLessonTexts.ColumnCount = 3;
      for (int i = 0; i < LessonsList[ClassNum].Lessons[LessonNum].Themes.Count; i++)
      {
        gridLessonTexts.Rows[i].Cells[0].Value = LessonsList[ClassNum].Lessons[LessonNum].Dates[i];
        gridLessonTexts.Rows[i].Cells[1].Value = LessonsList[ClassNum].Lessons[LessonNum].Themes[i];
        gridLessonTexts.Rows[i].Cells[2].Value = (NumIDs)LessonsList[ClassNum].Lessons[LessonNum].Types[i];
      }

      gridLessonTexts.Columns[0].Width = 35;
      gridLessonTexts.Columns[1].Width = 135;
      gridLessonTexts.Columns[2].Width = 97;
    }

    private void DrawMarksGrid(int LessonNum, int ClassNum, bool IsNeedToReturnMatrix) //Разрисовка таблицы оценок 100%
    {
      gridStudentMarks.RowCount = gridStudentNames.RowCount;
      gridStudentMarks.ColumnCount = LessonsList[ClassNum].Lessons[LessonNum].Dates.Count;
      for (int i = 0; i < gridStudentMarks.ColumnCount; i++)
        gridStudentMarks.Columns[i].Width = 40;
      for (int i = 0; i < LessonsList[ClassNum].Lessons[LessonNum].Themes.Count; i++)
        gridStudentMarks.Columns[i].HeaderText = LessonsList[ClassNum].Lessons[LessonNum].Dates[i];

      if (IsNeedToReturnMatrix)
        ReturnMatrixToGrid(ClassNum, LessonNum);
    }

    //--------------------------------------------------------------------------------Обработчики событий 

    private void gridClasses_CellClick(object sender, DataGridViewCellEventArgs e) //====Обработчик события нажатия клетки в gridClasses 100%
    {
      if (chbLessonList.Checked == true)
      {
        if (gridLessonNames.RowCount == 0)
        {
          tempClass = e.RowIndex;
          DrawNamesListOnGrid(e.RowIndex);
          DrawLessonsOfSelectedClassOnGrid(e.RowIndex);
        }
        else
        {
          MatrixUpdater(tempClass, tempLesson);
          tempClass = e.RowIndex;
          DrawNamesListOnGrid(e.RowIndex);
          DrawLessonsOfSelectedClassOnGrid(e.RowIndex);
          gridStudentMarks.Columns.Clear();
          gridLessonTexts.Columns.Clear();
        }
      }
      else
        MessageBox.Show("Не загружен учебный план.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private void gridLessonNames_CellClick(object sender, DataGridViewCellEventArgs e) //Обработчик события нажатия ячейки в таблице предметов 100%
    {
      DrawLessonsThemesAndDates(e.RowIndex, gridClasses.CurrentCellAddress.Y);
      if (tempFlag)
      {
        tempFlag = false;
        DrawMarksGrid(e.RowIndex, gridClasses.CurrentCellAddress.Y, false);
        tempLesson = e.RowIndex;
      }
      else
      {
        MatrixUpdater(gridClasses.CurrentCellAddress.Y, tempLesson);
        tempLesson = e.RowIndex;
        gridStudentMarks.Columns.Clear();
        DrawMarksGrid(tempLesson, gridClasses.CurrentCellAddress.Y, true);
      }
    }

    //--------------------------------------------------------------------------------Весь мусор тут

    private void menuHelp_Click(object sender, EventArgs e) //===========================Помощь 100%
    {
      MessageBox.Show("Чтобы начать работу с программой, откройте меню Файл и добавьте списки учеников и учебные планы.", "Помощь");
    }

    private void menuClose_Click(object sender, EventArgs e) //==========================Закрыть форму 100%
    {
      this.Close();
    }

    private void helpAbout_Click(object sender, EventArgs e) //==========================О программе 100%
    {
      MessageBox.Show("Разработчик данного школьного журнала - студент 1 курса ФКН, ВГУ Леонтьев Максим (aka Mexahoid).", "О программе");
    }

  }
}
