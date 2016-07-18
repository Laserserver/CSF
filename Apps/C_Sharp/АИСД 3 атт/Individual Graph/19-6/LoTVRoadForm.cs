using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _19_6
{
  public partial class LoTVRoadForm : Form
  {
    public LoTVRoadForm()
    {
      InitializeComponent();
      _ctrlLblName.Text = "Текущее имя: " + Lib.graph.Nodes[Lib.graph._I].node_Edge[Lib.graph._K].edge_NameEdge;
      _ctrlNumRows.Value = Lib.graph.Nodes[Lib.graph._I].node_Edge[Lib.graph._K].edge_Rows;
    }

    private void _ctrlButSetData_Click(object sender, EventArgs e)
    {
      int I1 = 0;
      int K1 = 0;
      Lib.graph.FindSecondaryLine(out I1, out K1);
      int NewRows = int.Parse(_ctrlNumRows.Value.ToString());
      Lib.graph.Nodes[Lib.graph._I].node_Edge[Lib.graph._K].edge_Rows = Lib.graph.Nodes[I1].node_Edge[K1].edge_Rows = NewRows;
      switch (Lib.graph.Nodes[Lib.graph._I].node_Edge[Lib.graph._K].edge_Level)
      {
        case 0:
          if (NewRows > 2 && NewRows < 5)
            Lib.graph.Nodes[Lib.graph._I].node_Edge[Lib.graph._K].edge_Level = Lib.graph.Nodes[I1].node_Edge[K1].edge_Level = 1;
          else
          if (NewRows >= 5)
            Lib.graph.Nodes[Lib.graph._I].node_Edge[Lib.graph._K].edge_Level = Lib.graph.Nodes[I1].node_Edge[K1].edge_Level = 2;
          break;
        case 1:  //пр
          if (NewRows > 4)
            Lib.graph.Nodes[Lib.graph._I].node_Edge[Lib.graph._K].edge_Level = Lib.graph.Nodes[I1].node_Edge[K1].edge_Level = 2;
          else
            if (NewRows <= 2)
            Lib.graph.Nodes[Lib.graph._I].node_Edge[Lib.graph._K].edge_Level = Lib.graph.Nodes[I1].node_Edge[K1].edge_Level = 0;
          break;
        case 2:  //ш
          if (NewRows < 5)
            Lib.graph.Nodes[Lib.graph._I].node_Edge[Lib.graph._K].edge_Level = Lib.graph.Nodes[I1].node_Edge[K1].edge_Level = 1;
          else
            if (NewRows <= 2)
            Lib.graph.Nodes[Lib.graph._I].node_Edge[Lib.graph._K].edge_Level = Lib.graph.Nodes[I1].node_Edge[K1].edge_Level = 0;
          break;
      }
      Lib.graph.Nodes[Lib.graph._I].node_Edge[Lib.graph._K].edge_NameEdge = Lib.graph.Nodes[I1].node_Edge[K1].edge_NameEdge = _ctrlTxb.Text;
      MessageBox.Show("Успешно!");
      Close();
    }
  }
}
