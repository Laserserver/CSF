using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace ProjectRed
{
  public partial class LegacyOfTheVoid : Form
  {
    List<string> Studs = new List<string>();
    public LegacyOfTheVoid()
    {
      InitializeComponent();
      Draw();
    }

    private void Draw()
    {
      try
      {
        gridJournal.RowCount = 10;
        gridJournal.ColumnCount = 10;
        for (int i = 1; i < gridJournal.ColumnCount; i++)
          gridJournal.Columns[i].Width = 30;
        for (int i = 1; i < gridJournal.RowCount; i++)
          gridJournal.Rows[0].Cells[i].Value = Studs[i];
      }
      catch
      {
        MessageBox.Show("Нет файла данных.", "Предупреждение");
      }
    }

    private void batonAddLesson_Click(object sender, EventArgs e)
    {

    }

    private void batonLoadStudents_Click(object sender, EventArgs e)
    {
      Heart.InitDebils();
    }

    private void batonLessonPlan_Click(object sender, EventArgs e)
    {

    }

    private void batonSaveInfo_Click(object sender, EventArgs e)
    {

    }

    private void SaveData()
    {
      for (int i = 0; i < gridJournal.RowCount; i++)
        ;
    }

    private void LoadData()
    {

    }
  }
}
