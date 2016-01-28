using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Drawing;

namespace ProjectRed
{
  public partial class LegacyOfTheVoid : Form
  {
    XDocument DebilsList;
    XDocument LessonsList;
    XDocument Journal;
    FolderBrowserDialog fbd = new FolderBrowserDialog();
    OpenFileDialog ofd = new OpenFileDialog();
    string[] ClassIDs;
    string[] CurrentLessIds;
    List<string> Dates = new List<string>();
    List<string> Texts = new List<string>();

    List<Group> Groups = new List<Group>();
    List<string[]> NameList;
    List<char> LetterList;
    List<string> ClassList;

    List<ClassLesson> ClassesNLessons;

    public LegacyOfTheVoid()
    {
      InitializeComponent();
      //Draw(); //Попытка ввода файла Journal
    }

    private void Draw()
    {
      try
      {
        Journal = XDocument.Load("Journal.xml"); //Глобальное присваивание файла журнала
        //Тратата какая-то функция
      }
      catch
      {
        DialogResult res = MessageBox.Show("Нет файла данных. Выбрать файл из другого места?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
        if (res == System.Windows.Forms.DialogResult.OK && ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
          try
          {
            Journal = XDocument.Load(ofd.FileName);
            //Блаблабла вызовы функций
          }
          catch
          {
            MessageBox.Show("Неподходящий файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
      }
    } //Попытка вывода файла журнала

    private void menuLoadStudList_Click(object sender, EventArgs e) //Загрузка файла дебилов и классов из нажатия меню, после - загрузка списка классов в форму (100%) 
    {
      if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) //Проверка на xml'ность файла дебилов
        try
        {
          DebilsList = XDocument.Load(ofd.FileName); //Глобальное присваивание документа дебилов
          GetClass(); //Получаем ClassList, отправляя DebilsList в ParseStudents
          GroupParser();
        }
        catch
        {
          MessageBox.Show("Невозможно открыть выбранный файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void menuLoadLessonList_Click(object sender, EventArgs e) //Загрузка файла плана (100%) 
    {
      if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)  //Соответственная проверка на xml'ность файла учебного плана      
        try
        {
          LessonsList = XDocument.Load(ofd.FileName); //Глобальное присваивание документа плана
          LessonToForm(); //Вызов функции отображения плана
        }
        catch
        {
          MessageBox.Show("Невозможно открыть выбранный файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void menuLoadJournal_Click(object sender, EventArgs e) //Идиотство, но так названа кнопка сохранения журнала (0%) 
    {

    }

    private void LessonToForm() //Функция вывода учебного плана (пусто) 
    {
      if (ParseLessons.ClassParse(LessonsList, out ClassIDs)) //Получаем список классов
      {
        ClassTextsDatesParser();
        chbLessonList.Checked = true;
      }
      else
        MessageBox.Show("Неправильно отформатирован учебный план", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void GroupParser()
    {
      for (int i = 0; i < ClassList.Count; i++)
        Groups.Add(new Group(ClassList[i], LetterList[i], NameList[i]));
    }

    private void ClassTextsDatesParser()
    {
      List<Lesson> Lessons = new List<Lesson>();
      for (int i = 0; i < ClassIDs.Length; i++)
      {
        string LessName;
        List<string> Texts = new List<string>();
        List<string> Dates;
        Dates = ParseLessons.LessonTextsParse(LessonsList, ClassIDs[i], out Texts, out LessName);
        Lessons.Add(new Lesson(LessName, Texts, Dates));
        ClassesNLessons.Add(new ClassLesson(ClassIDs[i], Lessons));
      }
    }

    //========================Рисовальщики

    private void DrawLessonTypeTable(int LessonGridRowId)  //Разрисовка таблиЦы списка предметов
    {
      CurrentLessIds = ParseLessons.LessonParse(LessonsList, ClassIDs[LessonGridRowId]);
      gridLessonNames.RowCount = CurrentLessIds.Length;
      for (int i = 0; i < CurrentLessIds.Length; i++)
        gridLessonNames.Rows[i].Cells[0].Value = CurrentLessIds[i];
    }

    private void DrawTexts(int LessonGridRowId, int ClassGridRowId) //Разрисовка таблицы текстов плана
    {
      Dates = ParseLessons.DelParse(LessonsList, ClassIDs[ClassGridRowId], CurrentLessIds[LessonGridRowId], "date");
      Texts = ParseLessons.DelParse(LessonsList, ClassIDs[ClassGridRowId], CurrentLessIds[LessonGridRowId], "text");
      gridLessonTexts.ColumnCount = 2;
      gridLessonTexts.RowCount = Dates.Count;
      for (int i = 0; i < Dates.Count; i++)
      {
        gridLessonTexts.Rows[i].Cells[0].Value = Dates[i];
        gridLessonTexts.Rows[i].Cells[1].Value = Texts[i];
      }
      gridLessonTexts.Columns[0].Width = 35;
    }

    private void DrawStudentDatesMarks(int Num) //Разрисовка таблицы оценок и ее хедеров-дат
    {
      gridStudentMarks.ColumnCount = Dates.Count;
      gridStudentMarks.RowCount = Groups[Num].Studs.Length;
      gridStudentNames.Columns[0].HeaderText = "Дата";
      for (int i = 0; i < Dates.Count; i++)
        gridStudentMarks.Columns[i].HeaderText = Dates[i];
      for (int i = 0; i < Dates.Count; i++)
        gridStudentMarks.Columns[i].Width = 35;
    }

    private void StudentLister(XDocument StudentsList, int Num) //Вывод списка имен дебилов (100%) 
    {
      gridStudentNames.RowCount = Groups[Num].Studs.Length;
      for (int i = 0; i < Groups[Num].Studs.Length; i++)
        gridStudentNames.Rows[i].Cells[0].Value = Groups[Num].Studs[i];
      foreach (DataGridViewColumn column in gridStudentMarks.Columns)
        column.SortMode = DataGridViewColumnSortMode.NotSortable;
      gridStudentNames.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    }

    private void GetClass() //Вывод списка доступных классов (100%) 
    {
      if (ParseStudents.GetClassNamesLettersList(DebilsList, out ClassList, out LetterList, out NameList))
      {
        gridClasses.RowCount = ClassList.Count;
        for (int i = 0; i < ClassList.Count; i++)
          gridClasses.Rows[i].Cells[0].Value = ClassList[i] + ' ' + LetterList[i];
        chbStudList.Checked = true; //Включение чекбокса-индексатора
      }
      else
        MessageBox.Show("Неправильно отформатирован файл списка студентов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    //========================Обработчики событий 

    private void gridClasses_CellClick(object sender, DataGridViewCellEventArgs e) //Обработчик события нажатия клетки в gridClasses (100%) 
    {
      if (chbLessonList.Checked == true)
      {
        gridStudentMarks.RowCount = 0;
        gridLessonTexts.RowCount = 0;
        DrawLessonTypeTable(e.RowIndex);   //Надо переделать под отправление индекса класса
        StudentLister(DebilsList, e.RowIndex);      //StudentLister(DebilsList, gridClasses.CurrentCellAddress.Y); можно и так
      }
      else
        MessageBox.Show("Не загружен учебный план.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private void gridLessonNames_CellClick(object sender, DataGridViewCellEventArgs e) //Обработчик события нажатия ячейки в таблице предметов (%)
    {
      gridStudentMarks.RowCount = 0;
      DrawTexts(e.RowIndex, gridClasses.CurrentCellAddress.Y);
      DrawStudentDatesMarks(gridClasses.CurrentCellAddress.Y);
    }

    //======================Весь мусор тут

    private void menuHelp_Click(object sender, EventArgs e) //Помощь (100%) 
    {
      MessageBox.Show("Чтобы начать работу с программой, откройте меню Файл и добавьте списки учеников и учебные планы.", "Помощь");
    }

    private void menuClose_Click(object sender, EventArgs e) //Закрыть форму (100%) 
    {
      this.Close();
    }

    private void helpAbout_Click(object sender, EventArgs e) //О программе (100%) 
    {
      MessageBox.Show("Разработчик данного школьного журнала - студент 1 курса ФКН, ВГУ Леонтьев Максим (aka Mexahoid).", "О программе");
    }

  }
}
