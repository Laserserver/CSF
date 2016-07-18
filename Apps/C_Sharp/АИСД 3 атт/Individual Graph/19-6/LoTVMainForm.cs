using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace _19_6
{
  public partial class LoTVMainForm : Form
  {
    public static double coeff = 1.00;
    double FinScale = 1.00;
    public static byte ToolsType = 0;  //Тутай переключатель выбранного элемента
    public static byte RoadType = 0; //Тип дороги  0 улица, 1 проспект, 2 шоссе
    public static byte RoadCount = 1;
    public static byte SelecterType = 0; //Тип селектора  0 тягать, 1 свойства, 2 выбор предка 3 группировка
    MouseEventArgs e0;
    bool drawing = false;
    Graphics g;

    public LoTVMainForm()
    {
      InitializeComponent();
      saveFileDialog1.Filter = "Graph Files (*.gr)|*.gr|All Files (*.*)|*.*";
      openFileDialog1.Filter = "Graph Files (*.gr)|*.gr|All Files (*.*)|*.*";
      Lib.graph = new LoTVGraph(ClientRectangle.Width, ClientRectangle.Height);
      g = _ctrlPanel.CreateGraphics();
      LoTVGraph.I2 = _ctrlPanel.Width;
      LoTVGraph.J2 = _ctrlPanel.Height;
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Lib.graph.Clear();
      Lib.graph.Reset();
      coeff = 1.00;
      coeffToolStripMenuItem.Text = "Коэфф: 1,00x";
      FinScale = 1.00;
      MyDraw(false, false);
    }

    private void loadToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Lib.graph.Clear();
      Lib.graph.Reset();
      coeff = 1.00;
      coeffToolStripMenuItem.Text = "Коэфф: 1,00x";
      FinScale = 1.00;
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
        using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
          Lib.graph.Loader(sr.ReadToEnd());
      MyDraw(false, false);
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
          sw.Write(Lib.graph.Saver());
    }

    public void MyDraw(bool Add, bool Delete)
    {
      Lib.graph.Draw(Add, Delete);
      g.DrawImage(Lib.graph.bitmap, ClientRectangle);
    }

    private void _ctrlPanel_Paint(object sender, PaintEventArgs e)
    {
      MyDraw(false, false);
    }

    private void _ctrlPanel_MouseUp(object sender, MouseEventArgs e)
    {
      drawing = false;
      switch (ToolsType)
      {
        case 0:
          if (SelecterType == 3)
          {
            if (Lib.graph.CurrentLevel == 3)
              Lib.graph.AddDistrictNode(e.X, e.Y);
            else
              if (Lib.graph.CurrentLevel == 2)
              Lib.graph.AddCityNode(e.X, e.Y);
          }
          break;
        case 2:
          LoTVGraph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
          if (LoTVGraph.SelectNode != null && LoTVGraph.SelectNodeBeg != null)
          {
            if (LoTVGraph.SelectNode.node_Level == LoTVGraph.SelectNodeBeg.node_Level)
            {
              string ErrRoad = "";
              Lib.graph.AddEdge(RoadType, RoadCount, out ErrRoad);
              LoTVGraph.SelectEdge = new TEdge();
              LoTVGraph.SelectEdge.edge_NameEdge = "New";
              if (ErrRoad != "")
                MessageBox.Show(ErrRoad);
              else
                MyDraw(false, false);
            }
          }
          break;
        case 3:
          LoTVGraph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
          if (LoTVGraph.SelectNode != null && LoTVGraph.SelectNodeBeg != null)
          {
            if (LoTVGraph.SelectNode.node_Level == LoTVGraph.SelectNodeBeg.node_Level)
              Lib.graph.DeleteEdge();
            MyDraw(false, false);
          }
          break;
      }
    }

    private void _ctrlPanel_MouseMove(object sender, MouseEventArgs e)
    {
      if (drawing)
      {
        switch (ToolsType)
        {
          case 0:
            switch (SelecterType)
            {
              case 0:
                Lib.graph.SetSelectNodeCoords(e.X, e.Y, e0.X, e0.Y);
                e0 = e;
                MyDraw(false, false);
                break;
              case 1:
              case 2:
                MyDraw(false, false);
                break;
              case 3:
                Lib.graph.SetPolyline(e.X, e.Y, false);
                MyDraw(true, true);
                break;
            }
            break;
          case 2:
          case 3:
            Lib.graph.SetPolyline(e0.X, e0.Y, false);
            MyDraw(ToolsType == 2 ? true : false, ToolsType == 2 ? false : true);
            e0 = e;
            break;
          case 5:
            Lib.graph.Redo(e.X, e.Y, e0.X, e0.Y);
            e0 = e;
            MyDraw(false, false);
            break;
        }
      }
      else
      {
        switch (ToolsType)
        {
          case 0:
            switch (SelecterType)
            {
              case 0:
                LoTVGraph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
                MyDraw(false, false);
                break;
              case 1:
                if (Lib.graph.FindEdge(e.X, e.Y, out Lib.graph._I, out Lib.graph._K))
                  LoTVGraph.SelectEdge = Lib.graph.Nodes[Lib.graph._I].node_Edge[Lib.graph._K];
                else
                {
                  Lib.graph._K = 0;
                  Lib.graph._I = 0;
                  LoTVGraph.SelectEdge = new TEdge();
                  LoTVGraph.SelectEdge.edge_NameEdge = "Not valid";
                }
                MyDraw(false, false);
                break;
              case 2:
                TNode temp = Lib.graph.FindNode(e.X, e.Y);
                if (temp != null && temp.node_Level != 1 && !temp.node_IsDescendant)
                  LoTVGraph.SelectNode = temp;
                else
                  LoTVGraph.SelectNode = null;
                MyDraw(false, false);
                break;
            }
            break;
          case 2:
          case 3:
          case 4:
            LoTVGraph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
            MyDraw(false, false);
            break;
        }
      }
    }

    private void _ctrlPanel_MouseDown(object sender, MouseEventArgs e)
    {
      e0 = e;
      switch (ToolsType)
      {

        case 0:
          LoTVGraph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
          switch (SelecterType)
          {
            case 0:
              drawing = LoTVGraph.SelectNode != null;
              break;
            case 1:
              if (LoTVGraph.SelectEdge.edge_NameEdge != "Not valid")
              {
                LoTVRoadForm road = new LoTVRoadForm();
                road.Show();
              }
              break;
            case 2:
              if (LoTVGraph.SelectNode != null && LoTVGraph.SelectNode.node_Level != 1 && !LoTVGraph.SelectNode.node_IsDescendant)
              {
                LoTVAdderToNode form_Adder = new LoTVAdderToNode();
                form_Adder.Show();
              }
              break;
            case 3:
              if (Lib.graph.CurrentLevel != 1)
              {
                LoTVGraph.CurrentLine = new TEdge();
                LoTVGraph.CurrentLine.edge_Points = new List<_edge_Points>();
                Lib.graph.SetPolyline(e0.X, e0.Y, true);
                drawing = true;
              }
              break;
          }
          break;
        case 1:
          if (Lib.graph.CurrentLevel == 3)
            Lib.graph.AddCrossing(e.X, e.Y);
          MyDraw(false, false);
          break;
        case 2:
        case 3:
          LoTVGraph.CurrentLine = new TEdge();
          LoTVGraph.SelectNodeBeg = Lib.graph.FindNode(e.X, e.Y);
          LoTVGraph.CurrentLine.edge_Points = new List<_edge_Points>();
          drawing = LoTVGraph.SelectNodeBeg != null;
          if (drawing)
            Lib.graph.SetPolyline(e.X, e.Y, true);
          break;
        case 4:
          LoTVGraph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
          if (LoTVGraph.SelectNode != null)
            Lib.graph.DeleteNode();
          MyDraw(false, false);
          break;
        case 5:
          drawing = true;
          break;
      }
    }

    private void nodesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      LoTVNodes formRename = new LoTVNodes();
      formRename.Show();
      if (formRename.DialogResult == DialogResult.Cancel)
        MyDraw(false, false);
    }

    private void LoTVMainForm_Activated(object sender, EventArgs e)
    {
      MyDraw(false, false);
    }

    private void LoTVMainForm_Load(object sender, EventArgs e)
    {
      g = _ctrlPanel.CreateGraphics();
      MouseWheel += new MouseEventHandler(Form1_MouseWheel);
    }

    private void Form1_MouseWheel(object sender, MouseEventArgs e)
    {
      double x = Lib.graph.XX(e.X);
      double y = Lib.graph.YY(e.Y);
      if (e.Delta < 0)
        coeff = 1.03;
      else
        coeff = 0.97;
      if (FinScale < 0.30)
        coeff = 0.97;
      else if (FinScale > 19.00)
        coeff = 1.03;
      LoTVGraph.Scale /= coeff;
      FinScale /= coeff;
      LoTVGraph.x1p = x - (x - LoTVGraph.x1p) * coeff;  //x1 > x
      LoTVGraph.x2p = x + (LoTVGraph.x2p - x) * coeff;
      LoTVGraph.y1p = y - (y - LoTVGraph.y1p) * coeff;
      LoTVGraph.y2p = y + (LoTVGraph.y2p - y) * coeff;
      Lib.graph.CurrentLevel = FinScale < 2.00 ? 1 : FinScale > 2.00 && FinScale < 7.80 ? 2 : 3;
      Text = FinScale < 2.00 ? "Poogle Maps - уровень городов" : FinScale > 2.00 && FinScale < 7.80 ? "Poogle Maps - уровень районов" : "Poogle Maps - уровень перекрестков";
      coeffToolStripMenuItem.Text = "Коэфф: " + decimal.Round((decimal)(FinScale), 2) + 'x';
      MyDraw(false, false);
    }

    private void LoTVMainForm_Resize(object sender, EventArgs e)
    {
      if (Lib.graph != null)
        Lib.graph.ChangeBitmap(_ctrlPanel.Width, _ctrlPanel.Height);
    }

    private void coeffToolStripMenuItem_Click(object sender, EventArgs e)
    {
      coeff = 1.00;
      coeffToolStripMenuItem.Text = "Коэфф: 1.00x";
      FinScale = 1.00;
      Lib.graph.Reset();
      MyDraw(false, false);
    }
  }
}