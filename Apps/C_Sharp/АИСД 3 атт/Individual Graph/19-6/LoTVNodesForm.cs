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
  public partial class LoTVNodes : Form
  {
    public LoTVNodes()
    {
      InitializeComponent();
      MarkdownDGV();
    }

    private void MarkdownDGV()
    {
      _ctrlDGV.RowCount = LoTVGraph.NodeNamesArr.Length;
      _ctrlDGV.ColumnCount = 1;
      for (int i = 0; i < LoTVGraph.NodeNamesArr.Length; i++)
        _ctrlDGV.Rows[i].Cells[0].Value = LoTVGraph.NodeNamesArr[i];
    }

    private void _ctrlBaton_Click(object sender, EventArgs e)
    {
      int N = Lib.graph.ReturnNumber(_ctrlDGV.Rows[_ctrlDGV.CurrentCellAddress.Y].Cells[0].Value.ToString());
      LoTVGraph.SelectNode = Lib.graph.Nodes[N];
      LoTVRenameSelected form_Rename = new LoTVRenameSelected();
      form_Rename.Show();
      if (form_Rename.DialogResult == DialogResult.OK)
      {
        _ctrlDGV.ColumnCount = 0;
        MarkdownDGV();
      }
    }

    private void _ctrlBatonDelete_Click(object sender, EventArgs e)
    {
      LoTVGraph.SelectNode = Lib.graph.Nodes[_ctrlDGV.CurrentCellAddress.Y];
      Lib.graph.DeleteNode();
      MarkdownDGV();
    }
  }
}
