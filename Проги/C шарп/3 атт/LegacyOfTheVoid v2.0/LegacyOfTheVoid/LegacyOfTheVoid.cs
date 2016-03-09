using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace ProjectRed
{
  public partial class LegacyOfTheVoid : Form
  {
    XDocument StudList;
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
        StudList = XDocument.Load("Students.xml");
      }
      catch
      {
        MessageBox.Show("Нет файла данных.", "Предупреждение");
      }
      finally
      {
        DrawTableEx();
      }
    }

    private void DrawTableEx()
    {
      gridJournal.RowCount = 10;
      gridJournal.ColumnCount = 10;
      for (int i = 1; i < gridJournal.ColumnCount; i++)
        gridJournal.Columns[i].Width = 30;
    }

    private void batonAddLesson_Click(object sender, EventArgs e)
    {

    }

    private void batonLoadStudents_Click(object sender, EventArgs e)
    {

    }

    private void batonLessonPlan_Click(object sender, EventArgs e)
    {
      
    }

    private void SaveData()
    {      
      

    }

    private void LoadData()
    {
      var studs = from Stud1 in StudList.Descendants("Stud1")
                  select new
                  {
                    Name = Stud1.Element("name").Value,
                    Matan = Stud1.Element("Matan").Value,
                    TFKP = Stud1.Element("TFKP").Value,
                    Proga = Stud1.Element("Proga").Value,
                    History = Stud1.Element("History").Value,
                    Difur = Stud1.Element("Difur").Value,
                    marksMatan = Stud1.Element("marksMatan").Value,
                    marksTFKP = Stud1.Element("marksTFKP").Value,
                    marksProga = Stud1.Element("marksProga").Value,
                    marksHistory = Stud1.Element("marksHistory").Value,
                    marksDifur = Stud1.Element("marksDifur").Value,
                  };
      foreach (var stud in studs)
      {
        gridJournal.Rows[1].Cells[0].Value = stud.Name;
        gridJournal.Rows[2].Cells[0].Value = stud.Matan;
      }
      
    }

    private void batonSaveData_Click(object sender, EventArgs e)
    {
      SaveData();
    }

    private void batonLoadData_Click(object sender, EventArgs e)
    {
      LoadData();
    }
  }
}
