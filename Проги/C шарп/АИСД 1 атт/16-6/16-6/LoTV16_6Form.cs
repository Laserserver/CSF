using System;
using System.Windows.Forms;
using System.IO;

namespace _16_6
{
  public partial class LoTV16_6Form : Form
  {
    OpenFileDialog OFD = new OpenFileDialog();
    LoTVTeamListClass Teams;
    int[] Ratings;
    LoTVTeamListClass Sorted;
    public LoTV16_6Form()
    {
      InitializeComponent();
      Markdown(_ctrlDGVIn);
      Markdown(_ctrlDGVOut);
    }

    private void Markdown(DataGridView dgv)
    {
      dgv.RowCount = 16;
      dgv.ColumnCount = 2;
      dgv.Columns[0].Width = 80;
      dgv.Columns[1].Width = 30;
    }

    private void _ctrlLoadBaton_Click(object sender, EventArgs e)
    {
      if (OFD.ShowDialog() == DialogResult.OK)
      {
        StreamReader Txt = new StreamReader(OFD.FileName);
        try
        {
          Teams = Parser.ParseList(Txt.ReadToEnd());
          Txt.Close();
          Drawer(_ctrlDGVIn, Teams);
        }
        catch
        {
          MessageBox.Show("Плохо отформатирован файл списка.");
        }
      }
    }

    private void _ctrlBaton_Click(object sender, EventArgs e)
    {
     Sorted = LoTVListSorter.Sorter(Teams);
     Drawer(_ctrlDGVOut, Sorted);
    }

   private void Drawer(DataGridView dgv, LoTVTeamListClass List)
    {
      string[] TeamsNames = List.LoTVTeamNamesReturn(out Ratings);
      for (int i = 15; i >= 0; i--)
      {
        dgv.Rows[15 - i].Cells[0].Value = TeamsNames[i];
        dgv.Rows[15 - i].Cells[1].Value = Ratings[i];
      }
    }
  }
}
