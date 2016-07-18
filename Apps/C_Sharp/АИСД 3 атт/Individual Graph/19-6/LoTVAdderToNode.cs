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
  public partial class LoTVAdderToNode : Form
  {
    int J, N;
    public LoTVAdderToNode()
    {
      InitializeComponent();
      J = Lib.graph.ReturnNumber(LoTVGraph.SelectNode.node_Name);
      MarkdownAncestors();
    }

    private void _ctrlBaton_Click(object sender, EventArgs e)
    {
      LoTVGraph.SelectNode = Lib.graph.Nodes[J];
      Lib.graph.AddDescendant(Lib.graph.Nodes[N].node_Name);
      MessageBox.Show("Узел " + Lib.graph.Nodes[J].node_Name + " был добавлен потомком к узлу " + Lib.graph.Nodes[N].node_Name);
      LoTVGraph.SelectNode = null;
      Close();
    }

    void MarkdownAncestors()
    {
      int N = Lib.graph.Nodes.Length;
      _ctrlDGVAncs.ColumnCount = 1;
      int L = 0;
      for (int i = 0; i < N; i++)
        if (Lib.graph.Nodes[i].node_Level == Lib.graph.Nodes[J].node_Level - 1)
        {
          _ctrlDGVAncs.RowCount = ++L;
          _ctrlDGVAncs.Rows[L - 1].Cells[0].Value = Lib.graph.Nodes[i].node_Name;
        }
    }

    void MarkdownDescendants()
    {
      int G = Lib.graph.Nodes[N].node_UnderNodes.Length;
      _ctrlDGVDescs.ColumnCount = 1;
      _ctrlDGVDescs.RowCount = G;
      for (int i = 0; i < G; i++)
        _ctrlDGVDescs.Rows[i].Cells[0].Value = Lib.graph.Nodes[N].node_UnderNodes[i].node_Name;
    }

    private void _ctrlDGVAncs_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      N = Lib.graph.ReturnNumber(_ctrlDGVAncs.Rows[_ctrlDGVAncs.CurrentCellAddress.Y].Cells[0].Value.ToString());
      MarkdownDescendants();
    }
  }
}