using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace _19_6
{
  public partial class LoTVGraph
  {
    //=====================================================================  Графические операции

    public void ChangeName(string NewName)
    {
      if (SelectNode.node_Edge != null)
      {
        string temp = SelectNode.node_Name;
        int L = SelectNode.node_Edge.Length;
        for (int i = 0; i < L; i++)
        {
          int Num = ReturnNumber(SelectNode.node_Edge[i].edge_NameNode);
          int LN = Nodes[Num].node_Edge.Length;
          for (int j = 0; j < LN; j++)
            if (Nodes[Num].node_Edge[j].edge_NameNode == SelectNode.node_Name)
              Nodes[Num].node_Edge[j].edge_NameNode = NewName;
        }
      }
      SelectNode.node_Name = NewName;
      ResetNamesArr();
      Draw(false, false);
    }
    public bool DoesNamePresent(string DatName)
    {
      bool Ans = false;
      for (int i = 0; i < NodeNamesArr.Length; i++)
        if (NodeNamesArr[i] == DatName)
        {
          Ans = true;
          break;
        }
      return Ans;
    }
    public void SetGroupInRegion(int Xold, int Yold, int Xnew, int Ynew, out string Error)
    {
      double x1 = XX(Xold), x2 = XX(Xnew), y1 = YY(Yold), y2 = YY(Ynew);
      Error = "";
      int Length = Nodes.Length;
      TNode[] Group = new TNode[0];
      int L = 0;
      int[] IDs = new int[0];
      int K = 0;
      bool Ok = true;
      for (int i = 0; i < Length; i++)
        if (Nodes[i].node_Level == CurrentLevel && Nodes[i].node_x > x1 && Nodes[i].node_x < x2 && Nodes[i].node_y > y1 && Nodes[i].node_y < y2)
        {
          Array.Resize(ref IDs, ++K);
          IDs[K - 1] = i;
          if (Nodes[i].node_IsDescendant == true)
            Ok = false;
        }
      int Num = 0;
      Length = IDs.Length;
      if (K != 0 && Ok)
      {
        if (Ok)
        {
          if (CurrentLevel == 3)
            AddDistrictNode(II(x1 + (x2 - x1) / 2), JJ(y2 - (y2 - y1) / 2));
          else
              if (CurrentLevel == 2)
            AddCityNode(II(x1 + (x2 - x1) / 2), JJ(y2 - (y2 - y1) / 2));
          Num = Nodes.Length - 1;
          for (int i = 0; i < Length; i++)
          {
            Array.Resize(ref Group, ++L);
            Nodes[IDs[i]].node_IsDescendant = true;
            Nodes[IDs[i]].node_Ancestor = Nodes[Num].node_Name;
            Group[L - 1] = Nodes[IDs[i]];
          }
        }

        else
        {
          for (int i = 0; i < Length; i++)
            if (Nodes[IDs[i]].node_IsDescendant == true)
              Error += Nodes[IDs[i]].node_Name + " ";
        }
        if (Ok)
          Nodes[Num].node_UnderNodes = Group;
        else
        {
          if (K != 0)
          {
            SelectNode = Nodes[Num];
            DeleteNode();
          }
        }
      }
    }
    public TNode FindNode(int MonX, int MonY) // найти узел
    { //Передаем экранные координаты, превращаются в изначальные
      double PaperX = XX(MonX);
      double PaperY = YY(MonY);
      int I = 0;
      int N = Nodes.Length;
      bool Ok = false;
      if (CurrentLevel != 3)
      {
        for (int i = 0; i < N; i++)
          if (Nodes[i].node_Level < 3 && Nodes[i].node_Points != null && Nodes[i].node_Level == CurrentLevel && !Ok)
          {
            Ok = IsPointInPolygon(Nodes[i].node_Points, PaperX, PaperY);
            if (Ok)
              I = i;
          }
        return Ok ? Nodes[I] : null;
      }
      else
      {
        int i = -1;
        double Epsilon = 1;
        while ((i < N - 1) && !Ok)
        {
          i++;
          Ok = Nodes[i].node_Level == CurrentLevel && (Nodes[i].node_x - Epsilon <= PaperX) && (PaperX <= Nodes[i].node_x + Epsilon) &&
               (Nodes[i].node_y - Epsilon <= PaperY) && (PaperY <= Nodes[i].node_y + Epsilon);
        }
        return Ok ? Nodes[i] : null;
      }
    }
    public bool FindEdge(int MouseX, int MouseY, out int I, out int K)
    {
      K = 0; I = 0;
      double X1 = XX(MouseX);
      double Y1 = YY(MouseY);
      int N = Nodes.Length;
      for (int i = 0; i < N ; i++)
        if (Nodes[i].node_Edge != null)
        {
          int H = Nodes[i].node_Edge.Length;
          for (int k = 0; k < H; k++)
          {
            int J = Nodes[i].node_Edge[k].edge_Points.Count;
            for (int l = 1; l < J; l++)
            {
              double X0 = Nodes[i].node_Edge[k].edge_Points[l].edge_x;
              double Y0 = Nodes[i].node_Edge[k].edge_Points[l].edge_y;
              double DSqr = (Y1 - Y0) * (Y1 - Y0) + (X1 - X0) * (X1 - X0);
              if (DSqr <= 1 && DSqr >= -1)
              {
                //Nodes[i].node_Edge[k].edge_Select = true;
                I = i;
                K = k;
                return true;// = Nodes[i].node_Edge[k];
              }
            }
          }
        }
      return false;
    }
    public void ChangeBitmap(int VW, int VH)   //Чет непонятное, вроде для ресайза
    {
      bitmap = new Bitmap(VW, VH);
      Draw(false, false);
    }
    public void Draw(bool Add, bool Delete) // нарисовать
    {
      using (Graphics g = Graphics.FromImage(bitmap))
      {
        MyFont = new Font("Courier New", 10, FontStyle.Bold);
        Color cl = Color.FromArgb(255, 255, 255);
        g.Clear(cl);
        Pen MyPen = Pens.Black;
        SolidBrush MyBrush = (SolidBrush)Brushes.White;
        int N = Nodes.Length;

        //Line

        switch (CurrentLevel)
        {
          case 1:
            DrawMassCities(false);
            DrawMassDistricts(true);
            break;
          case 2:
            DrawMassCities(true);
            DrawMassDistricts(false);
            DrawMassCrossings(true);
            break;
          case 3:
            DrawMassDistricts(true);
            DrawMassCrossings(false);
            break;
        }
        for (int i = 0; i < N; i++)
        {
          // Edge
          if (Nodes[i].node_Edge != null)
          {
            int Len = Nodes[i].node_Edge.Length;
            switch (CurrentLevel)
            {
              case 1:
                for (int j = 0; j < Len; j++)
                {
                  if (Nodes[i].node_Edge[j].edge_Rows >= 4)
                    DrawEdge(Nodes[i].node_Edge[j]);                  
                }
                break;
              case 2:
                for (int j = 0; j < Len; j++)
                  if (Nodes[i].node_Edge[j].edge_Rows >= 2)
                  {
                    DrawEdge(Nodes[i].node_Edge[j]);
                    if (Nodes[i].node_Edge[j].edge_Marked_Name)
                      DrawName(Nodes[i].node_Edge[j], Brushes.Blue);
                  }
                break;
              case 3:
                for (int j = 0; j < Len; j++)
                {
                  DrawEdge(Nodes[i].node_Edge[j]);
                  if (Nodes[i].node_Edge[j].edge_Marked_Name)
                    DrawName(Nodes[i].node_Edge[j], Brushes.Black);
                }
                break;
            }
          }
        }

        if (Add && !Delete)
        {
          int Gh = CurrentLine.edge_Points.Count;
          for (int i = 1; i < Gh; i++)
            g.DrawLine(Pens.Silver, new Point(II(CurrentLine.edge_Points[i - 1].edge_x), JJ(CurrentLine.edge_Points[i - 1].edge_y)),
                new Point(II(CurrentLine.edge_Points[i].edge_x), JJ(CurrentLine.edge_Points[i].edge_y)));
        }
        else
            if (Delete && !Add)
          g.DrawLine(Pens.Red, new Point(II(x1), JJ(y1)), new Point(II(x2), JJ(y2)));
        else
                if (Delete && Add)
          g.DrawPolygon(Pens.Aqua, StructToPoints(CurrentLine.edge_Points).ToArray());
      }
    }

    public void GetLineCoords(int MouseX, int MouseY)
    {
      x1 = SelectNodeBeg.node_x;
      y1 = SelectNodeBeg.node_y;
      x2 = XX(MouseX);
      y2 = YY(MouseY);

      CurrentLine.edge_Points.Add(new _edge_Points(x2, y2));
    }
    public void SetSelectNodeCoords(int MouseX, int MouseY, int OldCoordsX, int OldCoordsY)    //Тутай передвижение узла
    {
      double dx = XX(MouseX) - XX(OldCoordsX);
      double dy = YY(MouseY) - YY(OldCoordsY);
      if (SelectNode.node_Level != 3)
        MovePolyObject(SelectNode, dx, dy);
      else
      {
        SelectNode.node_x += dx;
        SelectNode.node_y += dy;
        if (SelectNode.node_Edge != null)
        {
          int L = SelectNode.node_Edge.Length;
          for (int i = 0; i < L; i++)
          {
            int Num = ReturnNumber(SelectNode.node_Edge[i].edge_NameNode);
            int Gh = Nodes[Num].node_Edge.Length;
            int Cn;
            _edge_Points NewPoint;
            for (int k = 0; k < Gh; k++)
              if (Nodes[Num].node_Edge[k].edge_NameNode == SelectNode.node_Name)
              {
                Cn = Nodes[Num].node_Edge[k].edge_Points.Count;
                NewPoint = new _edge_Points(Nodes[Num].node_Edge[k].edge_Points[0].edge_x, Nodes[Num].node_Edge[k].edge_Points[0].edge_y);
                NewPoint.edge_x += dx;
                NewPoint.edge_y += dy;
                Nodes[Num].node_Edge[k].edge_Points[0] = NewPoint;
                break;
              }
            Cn = SelectNode.node_Edge[i].edge_Points.Count;
            NewPoint = new _edge_Points(SelectNode.node_Edge[i].edge_Points[Cn - 1].edge_x, SelectNode.node_Edge[i].edge_Points[Cn - 1].edge_y);
            NewPoint.edge_x += dx;
            NewPoint.edge_y += dy;
            SelectNode.node_Edge[i].edge_Points[Cn - 1] = NewPoint;
          }
        }
      }
    }

    void MovePolyObject(TNode Node, double dx, double dy)
    {
      if (Node.node_Level != 3)
      {
        if (Node.node_UnderNodes != null)
        {
          int L = Node.node_UnderNodes.Length;
          for (int i = 0; i < L; i++)
            MovePolyObject(Node.node_UnderNodes[i], dx, dy);
        }
        Node.node_Points = MoveLine(Node.node_Points, dx, dy);

      }
      else
      {
        Node.node_x += dx;
        Node.node_y += dy;
        if (Node.node_Edge != null)
        {
          int N = Node.node_Edge.Length;
          for (int k = 0; k < N; k++)
            Node.node_Edge[k].edge_Points = MoveLine(Node.node_Edge[k].edge_Points, dx, dy);
        }
      }
    }
    List<_edge_Points> MoveLine(List<_edge_Points> Input, double dx, double dy)
    {
      List<_edge_Points> Points = new List<_edge_Points>();
      int N = Input.Count;
      for (int i = 0; i < N; i++)
        Points.Add(new _edge_Points(Input[i].edge_x + dx, Input[i].edge_y + dy));
      return Points;
    }
    public void SetPolyline(int MouseX, int MouseY, bool Start)  //Ломаную задует кто с моста
    {
      double _x = XX(MouseX), _y = YY(MouseY);

      if (Start)
      {
        x1 = _x;
        y1 = _y;
      }
      else
      {
        x2 = _x;
        y2 = _y;
      }
      CurrentLine.edge_Points.Add(new _edge_Points(_x, _y));
    }

    //======================================================================  Утилиты

    public void Clear() // очистить граф 
    {
      int N = Nodes.Length;
      for (int i = 0; i < N; i++)
        Array.Resize(ref Nodes[i].node_Edge, 0);
      Array.Resize(ref Nodes, 0);
    }
    void ResetNamesArr()
    {
      string[] NewArr = new string[Nodes.Length];
      for (int i = 0; i < Nodes.Length; i++)
        NewArr[i] = Nodes[i].node_Name;
      NodeNamesArr = NewArr;
    }
    void ResetNodesArray()
    {
      int Ln = Nodes.Length;
      int N = 0;
      TNode[] NewArr = new TNode[N];
      int Num = 0;
      for (int j = 0; j < Ln; j++)
        if (Nodes[j] != null)
        {
          Array.Resize(ref NewArr, ++N);
          NewArr[Num++] = Nodes[j];
        }
      Nodes = NewArr.Length != 0 ? NewArr : new TNode[0];
    }
    int II(double x)          //Перевод бумажного Х в экранный
    {
      return I1 + (int)((x - x1p) * (I2 - I1) / (x2p - x1p));
    }
    int JJ(double y)          //Перевод бумажного Y в экранный
    {
      return J1 + (int)((y - y1p) * (J1 - J2) / (y1p - y2p));
    }
    public double XX(int I)          //Перевод Х коры в кору бумаги
    {
      return x1p + (I - I1) * (x2p - x1p) / (I2 - I1);
    }
    public double YY(int J)          //Перевод Ыгрыка в кору бумаги
    {
      return y1p + (J - J1) * (y2p - y1p) / (J2 - J1);
    }
    public void Reset()    //Возврат координат
    {
      x1p = x1old;
      x2p = x2old;
      y1p = y1old;
      y2p = y2old;
      Scale = 1.00;
      CurrentLevel = 1;
    }
    public void Redo(int MouseX, int MouseY, int OldCoordsX, int OldCoordsY)    //Движение изображения
    {
      double dx = XX(MouseX) - XX(OldCoordsX);
      double dy = YY(MouseY) - YY(OldCoordsY);

      x1p -= dx;
      y1p -= dy;
      x2p -= dx;
      y2p -= dy;
    }
    public int ReturnNumber(string Name)   //Выдача индекса узла по имени
    {
      int v, l = Nodes.Length;
      for (v = 0; v < l; v++)
        if (Nodes[v] != null && Nodes[v].node_Name == Name)
          break;
      return v;
    }
  }
}