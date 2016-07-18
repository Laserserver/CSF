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
  public partial class LoTVRenameSelected : Form
  {
    int N;
    public LoTVRenameSelected()
    {
      InitializeComponent();
      _ctrlLbl.Text = "Изначальное имя: " + LoTVGraph.SelectNode.node_Name;
      N = Lib.graph.ReturnNumber(LoTVGraph.SelectNode.node_Name);
      OnStartUp();
      MarkdownDescendants();
    }

    private void _ctrlBaton_Click(object sender, EventArgs e)
    {
      if (_ctrlTxb.Text != "")
        if (!Lib.graph.DoesNamePresent(_ctrlTxb.Text))
        {
          LoTVGraph.SelectNode = Lib.graph.Nodes[N];
          Lib.graph.ChangeName(_ctrlTxb.Text);
          MessageBox.Show("Успешно!");
          LoTVGraph.SelectNode = null;
        }
        else
          MessageBox.Show("Такое имя уже присутствует.");
      else
        MessageBox.Show("Нельзя придавать узлу пустое имя");
      Close();
    }

    private void _ctrlBatonClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    void OnStartUp()
    {
      _ctrlLblName.Text = "1. " + Lib.graph.Nodes[N].node_Name;
      _ctrlLbl_x.Text = "2. " + string.Format(Lib.graph.Nodes[N].node_x.ToString(), 6);
      _ctrlLbl_y.Text = "3. " + string.Format(Lib.graph.Nodes[N].node_y.ToString(), 6);
      _ctrlLbl_Asc.Text = "4. " + Lib.graph.Nodes[N].node_Ancestor;
      _ctrlLbl_Level.Text = "5. " + string.Format(Lib.graph.Nodes[N].node_Level.ToString(), 1);
    }

    void MarkdownDescendants()
    {
      if (Lib.graph.Nodes[N].node_UnderNodes != null)
      {
        int G = Lib.graph.Nodes[N].node_UnderNodes.Length;
        _ctrlDgvDescs.ColumnCount = 1;
        _ctrlDgvDescs.RowCount = G;
        for (int i = 0; i < G; i++)
          _ctrlDgvDescs.Rows[i].Cells[0].Value = Lib.graph.Nodes[N].node_UnderNodes[i].node_Name;
      }
    }

    void MarkdownEdges()
    {
      if (Lib.graph.Nodes[N].node_Edge != null)
      {
        int G = Lib.graph.Nodes[N].node_Edge.Length;
        _ctrlDgvEdges.ColumnCount = 2;
        _ctrlDgvEdges.Columns[1].Width = 30;
        _ctrlDgvEdges.RowCount = G;
        for (int i = 0; i < G; i++)
        {
          _ctrlDgvEdges.Rows[i].Cells[0].Value = Lib.graph.Nodes[N].node_Edge[i].edge_NameNode;
          _ctrlDgvEdges.Rows[i].Cells[1].Value = Lib.graph.Nodes[N].node_Edge[i].edge_Level;
        }
      }
    }
  }
}
