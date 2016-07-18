using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataBaseTest
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      DBResizer(ctrlDGVClasses);
      DBResizer(ctrlDGVMarks);
      DBResizer(ctrlDGVNames);
      DBResizer(ctrlDGVSubjects);
      DBResizer(ctrlDGVThemes);
    }

    private void DBResizer(DataGridView dgv)
    {
      for (int i = 0; i < dgv.ColumnCount; i++)
        dgv.Columns[i].Width = 30;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      // TODO: данная строка кода позволяет загрузить данные в таблицу "mexDBDataSet.TableThemes". При необходимости она может быть перемещена или удалена.
      this.tableThemesTableAdapter.Fill(this.mexDBDataSet.TableThemes);
      // TODO: данная строка кода позволяет загрузить данные в таблицу "mexDBDataSet.TableMarks". При необходимости она может быть перемещена или удалена.
      this.tableMarksTableAdapter.Fill(this.mexDBDataSet.TableMarks);
      // TODO: данная строка кода позволяет загрузить данные в таблицу "mexDBDataSet.TableStudents". При необходимости она может быть перемещена или удалена.
      this.tableStudentsTableAdapter.Fill(this.mexDBDataSet.TableStudents);
      // TODO: данная строка кода позволяет загрузить данные в таблицу "mexDBDataSet.TableSubjects". При необходимости она может быть перемещена или удалена.
      this.tableSubjectsTableAdapter.Fill(this.mexDBDataSet.TableSubjects);
      // TODO: данная строка кода позволяет загрузить данные в таблицу "mexDBDataSet.TableClasses". При необходимости она может быть перемещена или удалена.
      this.tableClassesTableAdapter.Fill(this.mexDBDataSet.TableClasses);

    }
  }
}
