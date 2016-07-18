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
  public partial class LoTVMainForm : Form
  {
    public static byte flTools = 0;
    bool drawing = false;
    Graphics g;
    string FileName = "";

    public LoTVMainForm()
    {
      InitializeComponent();
      saveFileDialog1.Filter = "Dat (*.dat)|*.dat|All Files (*.*)|*.*";
      openFileDialog1.Filter = "Dat (*.dat)|*.dat|All Files (*.*)|*.*";
      Lib.graph = new LoTVGraph(ClientRectangle.Width, ClientRectangle.Height);
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Lib.graph.Clear();
      MyDraw(false);
    }

    private void loadToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        Lib.graph.Read(openFileDialog1.FileName);
        FileName = openFileDialog1.FileName;
        Text = "Graph: [" + FileName + "]";
        MyDraw(false);
      }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (FileName != "")
        Lib.graph.Save(FileName);
      else
        saveFileDialog1.FileName = FileName;
      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
        FileName = saveFileDialog1.FileName;
        Lib.graph.Save(FileName);
      }
    }

    public void MyDraw(bool fl)
    {
      Lib.graph.Draw(fl);
      g.DrawImage(Lib.graph.bitmap, ClientRectangle);
    }

    private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Проверить граф на наличие циклов");
    }

    private void _ctrlPanel_Paint(object sender, PaintEventArgs e)
    {
      MyDraw(false);
    }

    private void _ctrlPanel_MouseUp(object sender, MouseEventArgs e)
    {
      drawing = false;
      switch (flTools)
      {
        case 2:
          LoTVGraph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
          if (LoTVGraph.SelectNode != null && LoTVGraph.SelectNodeBeg != null)
          {
            Lib.graph.AddEdge();
            MyDraw(false);
          }
          break;
      }
    }

    private void _ctrlPanel_MouseMove(object sender, MouseEventArgs e)
    {
      if (drawing)
      {
        switch (flTools)
        {
          case 0:
            LoTVGraph.SelectNode.x = e.X;
            LoTVGraph.SelectNode.y = e.Y;
            MyDraw(false);
            break;
          case 2:
            Lib.graph.x2 = e.X;
            Lib.graph.y2 = e.Y;
            MyDraw(true);
            break;
        }
      }
      else
      {
        switch (flTools)
        {
          case 0:
          case 2:
            LoTVGraph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
            MyDraw(false);
            break;
          case 3:
            Lib.graph.DeSelectEdge();
            int NumLine = -1;
            int NumNode = Lib.graph.FindLine(e.X, e.Y, out NumLine);
            if (NumNode != -1)
            {
              Lib.graph.Nodes[NumNode].Edge[NumLine].select = true;
              MyDraw(false);
            }
            break;
        }
      }
    }

    private void _ctrlPanel_MouseDown(object sender, MouseEventArgs e)
    {
      switch (flTools)
      {
        case 0:
          LoTVGraph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
          drawing = LoTVGraph.SelectNode != null;
          break;
        case 1:
          Lib.graph.AddNode(e.X, e.Y);
          MyDraw(false);
          break;
        case 2:
          LoTVGraph.SelectNodeBeg = Lib.graph.FindNode(e.X, e.Y);
          drawing = LoTVGraph.SelectNodeBeg != null;
          Lib.graph.x1 = e.X;
          Lib.graph.y1 = e.Y;
          Lib.graph.x2 = e.X;
          Lib.graph.y2 = e.Y;
          break;
        case 3:
          Lib.graph.DeSelectEdge();
          int NumLine = -1;
          int NumNode = Lib.graph.FindLine(e.X, e.Y, out NumLine);
          if (NumNode != -1)
          {
            Lib.graph.DelEdge(NumNode, NumLine);
            MyDraw(false);
          }
          break;
        case 4:
          LoTVGraph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
          if (LoTVGraph.SelectNode != null)
            Lib.graph.DeleteNode();
          MyDraw(false);
          break;
      }
    }

    private void LoTVMainForm_Load(object sender, EventArgs e)
    {
      g = _ctrlPanel.CreateGraphics();
    }

    private void построитьОстовToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Lib.graph.SetTreeDepth(Lib.graph.Nodes[0].name);
      MyDraw(false);
      string Ans = Lib.graph.ReturnNotNeeded();
      MessageBox.Show(Ans != null ? "Можно удалить: " + Ans : "Граф уже дерево");
    }

    private void LoTVMainForm_Resize(object sender, EventArgs e)
    {
      if (Lib.graph != null)
        Lib.graph.ChangeBitmap(_ctrlPanel.Width, _ctrlPanel.Height);
    }

    private void clearToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Lib.graph.ClearVisit();
      MyDraw(false);
    }
  }
}
