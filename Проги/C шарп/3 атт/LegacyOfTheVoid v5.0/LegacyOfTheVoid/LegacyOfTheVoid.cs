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
    string[] ClassList;
    string[] Names;
    List<string> LessList = new List<string>();
    List<string> Dates = new List<string>();
    List<string> Texts = new List<string>();

    public LegacyOfTheVoid()
    {
      InitializeComponent();
      Draw(); //Попытка ввода файла Journal
    }  //Собссно сама форма

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
          DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void menuLoadJournal_Click(object sender, EventArgs e) //Идиотство, но так названа кнопка сохранения журнала (0%) 
    {

    }

    private void LessonToForm() //Функция вывода учебного плана (пусто) 
    {
      List<string> ClassList;
      if (ParseLessons.ClassParse(LessonsList, out ClassList)) //Получаем список классов
      {
        ParseLessons.LessonParse(LessonsList, "Класс_1", out LessList);
        ParseLessons.DateEventParse(LessonsList, "Класс_1", "Математика", out Dates, out Texts);
        ParseLessons.thing(LessonsList);
        chbLessonList.Checked = true;
      }
      else
        MessageBox.Show("Неправильно отформатирован учебный план", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }


    //========================Рисовальщики

    private void DrawLessonTypeTable()  //Разрисовка таблиЦы списка предметов
    {
      gridLessonNames.RowCount = LessList.Count;
      for (int i = 0; i < LessList.Count; i++)
        gridLessonNames.Rows[i].Cells[0].Value = LessList[i];
    }

    private void DrawStudentDatesMarks() //Разрисовка таблицы оценок и ее хедеров-дат
    {
      gridStudentMarks.ColumnCount = Dates.Count;
      gridStudentMarks.RowCount = Names.Length;
      gridStudentNames.Columns[0].HeaderText = "Дата";
      for (int i = 0; i < Dates.Count; i++)
        gridStudentMarks.Columns[i].HeaderText = Dates[i];
      for (int i = 0; i < Dates.Count; i++)
        gridStudentMarks.Columns[i].Width = 35;
    }

    private void DrawTexts()
    {
      gridLessonTexts.ColumnCount = 2;
      gridLessonTexts.RowCount = Dates.Count;
      for (int i = 0; i < Dates.Count; i++)
      {
        gridLessonTexts.Rows[i].Cells[0].Value = Dates[i];
        gridLessonTexts.Rows[i].Cells[1].Value = Texts[i];
      }
    }

    private void StudentLister(XDocument StudentsList, int Num) //Вывод списка имен дебилов (100%) 
    {
      ParseStudents.GetStudentList(DebilsList, out Names, Num);
      gridStudentNames.RowCount = Names.Length;
      for (int i = 0; i < Names.Length; i++)
        gridStudentNames.Rows[i].Cells[0].Value = Names[i];
      foreach (DataGridViewColumn column in gridStudentMarks.Columns)
        column.SortMode = DataGridViewColumnSortMode.NotSortable;
      gridStudentNames.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    }

    private void GetClass() //Вывод списка доступных классов (100%) 
    {
      if (ParseStudents.GetClassList(DebilsList, out ClassList))
      {
        gridClasses.RowCount = ClassList.Length;
        for (int i = 0; i < ClassList.Length; i++)
          gridClasses.Rows[i].Cells[0].Value = ClassList[i];
        chbStudList.Checked = true; //Включение чекбокса-индексатора
      }
      else
        MessageBox.Show("Неправильно отформатирован файл списка студентов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    //========================Обработчики событий 

    private void gridClasses_CellClick(object sender, DataGridViewCellEventArgs e) //Обработчик события нажатия клетки в gridClasses (100%) 
    {
      if (chbLessonList.Checked == true && chbStudList.Checked == true)
      {
        DrawLessonTypeTable();   //Надо переделать под отправление индекса класса
        StudentLister(DebilsList, e.RowIndex);      //StudentLister(DebilsList, gridClasses.CurrentCellAddress.Y); можно и так
      }
      else
        MessageBox.Show("Не загружены файлы данных", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private void gridLessonNames_CellClick(object sender, DataGridViewCellEventArgs e) //Обработчик события нажатия ячейки в таблице предметов (%)
    {
      DrawStudentDatesMarks();
      DrawTexts();
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
