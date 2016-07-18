using System;
using System.Collections.Generic;
using System.Drawing;

namespace _19_6
{
  public struct TEdge
  {
    public string edge_NameNode;      //На какой узел указатель
    public string edge_NameEdge;
    public bool edge_Visible;
    public int edge_Level;
    public List<_edge_Points> edge_Points;
    public int edge_Rows;
    public bool edge_Select;
    public bool edge_Marked_Name;
  }

  public struct _edge_Points
  {
    public double edge_x;
    public double edge_y;

    public _edge_Points(double x, double y)
    {
      edge_x = x;
      edge_y = y;
    }
  }

  public class TNode
  {
    public string node_Name;          // 4 + 4 * Name.Length
    public double node_x, node_y;     // 8 + 8
    public bool node_IsDescendant;    // 1
    public bool node_Visible;         // 1
    public int node_Level;            // 4
    public string node_Ancestor;      // 4 + 4 * Ancestor.Length  
    public TEdge[] node_Edge;         // 4 + Count * ((9 + 4 * Nodelength) * 4) - ребра
    public TNode[] node_UnderNodes;   // 
    public List<_edge_Points> node_Points;
  }

  public struct Lib
  {
    public static LoTVGraph graph;     // граф
    public static int[] arr = new int[100];
  }

  public partial class LoTVGraph
  {
    public static TEdge CurrentLine;
    const int hx = 20;
    public Bitmap bitmap;
    public TNode[] Nodes = new TNode[0];// узлы
    public static string[] NodeNamesArr = new string[0];
    public static TNode SelectNode;
    public static TNode SelectNodeBeg;
    public static TEdge SelectEdge;
    public int CurrentLevel = 1;
    public double x1;
    public double x2;
    public double y1;
    public double y2;
    public int _I;
    public int _K;
    public static double Scale = 1.00;
    public const double
     x1old = -588,
     y1old = -306,
     x2old = 588,
     y2old = 306; //Константные координаты для получения конечного масштаба   
    public static double
      x1p = -588,
      y1p = -306,
      x2p = 588,
      y2p = 306; //Будем считать, что это изначальное полотно                  
    public static int
      I1 = 0,
      J1 = 0,
      I2 = 0,   //Ширина
      J2 = 0;  //Экранные координаты изначально не заданы // Высота            
    Font MyFont;

    //======================================================================  Структура графа

    public LoTVGraph(int VW, int VH)
    {
      bitmap = new Bitmap(VW, VH);
    }

    //======================================================================  Сохранялка

    public string Saver()
    {
      string Out = "";
      int Leng = Nodes.Length;
      Out += Leng.ToString() + '\n';
      if (Leng != 0)
        for (int i = 0; i < Leng; i++)
        {
          Out += Nodes[i].node_Name + '\n';
          Out += Nodes[i].node_x.ToString() + '\n';
          Out += Nodes[i].node_y.ToString() + '\n';
          Out += "False\n";  //Город - не потомок
          Out += "True\n";  //Здесь поле видимости, для города всегда тру
          Out += Nodes[i].node_Level.ToString() + '\n';
          Out += Nodes[i].node_Ancestor + '\n';  //Пустая строка

          int EL = Nodes[i].node_Edge != null ? Nodes[i].node_Edge.Length : 0;
          Out += EL.ToString() + '\n';
          for (int k = 0; k < EL; k++)
          {
            Out += Nodes[i].node_Edge[k].edge_NameNode + '\n';
            Out += Nodes[i].node_Edge[k].edge_Visible.ToString() + '\n';
            Out += Nodes[i].node_Edge[k].edge_Level.ToString() + '\n';
          }

          if (Nodes[i].node_UnderNodes != null)
          {
            int UL = Nodes[i].node_UnderNodes.Length;
            Out += UL.ToString() + '\n';
            for (int g = 0; g < UL; g++)
              Out += SetDistrictDescendants(ref i);
          }
        }
      return Out;
    }
    string SetDistrictDescendants(ref int i)
    {
      string Out = "";
      Out += Nodes[++i].node_Name + '\n';
      Out += Nodes[i].node_x.ToString() + '\n';
      Out += Nodes[i].node_y.ToString() + '\n';
      Out += Nodes[i].node_IsDescendant.ToString() + '\n';
      Out += "False\n";
      Out += Nodes[i].node_Level.ToString() + '\n';
      Out += Nodes[i].node_Ancestor + '\n';

      int EL = Nodes[i].node_Edge != null ? Nodes[i].node_Edge.Length : 0;
      Out += EL.ToString() + '\n';
      for (int k = 0; k < EL; k++)
      {
        Out += Nodes[i].node_Edge[k].edge_NameNode + '\n';
        Out += Nodes[i].node_Edge[k].edge_Visible.ToString() + '\n';
        Out += Nodes[i].node_Edge[k].edge_Level.ToString() + '\n';
      }
      if (Nodes[i].node_UnderNodes != null)
      {
        int UL = Nodes[i].node_UnderNodes.Length;
        Out += UL.ToString() + '\n';
        for (int h = 0; h < UL; h++)
          Out += SetCrossingDescendants(ref i);
      }
      else
        Out += 0 + '\n';
      return Out;
    }
    string SetCrossingDescendants(ref int i)
    {
      string Out = "";
      Out += Nodes[++i].node_Name + '\n';
      Out += Nodes[i].node_x.ToString() + '\n';
      Out += Nodes[i].node_y.ToString() + '\n';
      Out += Nodes[i].node_IsDescendant.ToString() + '\n';
      Out += "False\n";
      Out += Nodes[i].node_Level.ToString() + '\n';
      Out += Nodes[i].node_Ancestor + '\n';

      int EL = Nodes[i].node_Edge != null ? Nodes[i].node_Edge.Length : 0;
      Out += EL.ToString() + '\n';
      for (int k = 0; k < EL; k++)
      {
        Out += Nodes[i].node_Edge[k].edge_NameNode + '\n';
        Out += Nodes[i].node_Edge[k].edge_Visible.ToString() + '\n';
        Out += Nodes[i].node_Edge[k].edge_Level.ToString() + '\n';
      }
      return Out;
    }

    //======================================================================  Парсер

    public void Loader(string Input)
    {
      string[] Mass = Input.Split('\n');
      int Pos = 0;
      int NodesCount = int.Parse(Mass[Pos++]);
      Nodes = new TNode[NodesCount];
      for (int i = 0; i < NodesCount; i++)
      {
        Nodes[i] = new TNode();
        Nodes[i].node_Name = Mass[Pos++];
        Nodes[i].node_x = double.Parse(Mass[Pos++]);
        Nodes[i].node_y = double.Parse(Mass[Pos++]);
        Nodes[i].node_IsDescendant = bool.Parse(Mass[Pos++]);
        Nodes[i].node_Visible = bool.Parse(Mass[Pos++]);
        Nodes[i].node_Level = int.Parse(Mass[Pos++]);
        Pos++;
        int EL = int.Parse(Mass[Pos++]);
        Nodes[i].node_Edge = new TEdge[EL];
        for (int k = 0; k < EL; k++)
        {
          Nodes[i].node_Edge[k].edge_NameNode = Mass[Pos++];
          Nodes[i].node_Edge[k].edge_Visible = bool.Parse(Mass[Pos++]);
          Nodes[i].node_Edge[k].edge_Level = int.Parse(Mass[Pos++]);
        }
        int UL = int.Parse(Mass[Pos++]);
        Nodes[i].node_UnderNodes = new TNode[UL];
        int Temp = i;
        for (int f = 0; f < UL; f++)
          Nodes[i].node_UnderNodes[f] = Nodes[++Temp] = GetDistrictDescendants(ref Pos, Mass, ref Temp);
        i = Temp;
      }
    }
    TNode GetDistrictDescendants(ref int Pos, string[] Mass, ref int IPos)
    {
      TNode District = new TNode();
      District.node_Name = Mass[Pos++];
      District.node_x = double.Parse(Mass[Pos++]);
      District.node_y = double.Parse(Mass[Pos++]);
      District.node_IsDescendant = bool.Parse(Mass[Pos++]);
      District.node_Visible = bool.Parse(Mass[Pos++]);
      District.node_Level = int.Parse(Mass[Pos++]);
      District.node_Ancestor = Mass[Pos++];

      int EL = int.Parse(Mass[Pos++]);
      District.node_Edge = new TEdge[EL];
      for (int i = 0; i < EL; i++)
      {
        District.node_Edge[i].edge_NameNode = Mass[Pos++];
        District.node_Edge[i].edge_Visible = bool.Parse(Mass[Pos++]);
        District.node_Edge[i].edge_Level = int.Parse(Mass[Pos++]);
      }
      int UL = int.Parse(Mass[Pos++]);
      District.node_UnderNodes = new TNode[UL];
      for (int i = 0; i < UL; i++)
        District.node_UnderNodes[i] = Nodes[++IPos] = GetCrossingDescendants(ref Pos, Mass);
      return District;
    }
    TNode GetCrossingDescendants(ref int Pos, string[] Mass)
    {
      TNode Crossing = new TNode();
      Crossing.node_Name = Mass[Pos++];
      Crossing.node_x = double.Parse(Mass[Pos++]);
      Crossing.node_y = double.Parse(Mass[Pos++]);
      Crossing.node_IsDescendant = bool.Parse(Mass[Pos++]);
      Crossing.node_Visible = bool.Parse(Mass[Pos++]);
      Crossing.node_Level = int.Parse(Mass[Pos++]);
      Crossing.node_Ancestor = Mass[Pos++];

      int EL = int.Parse(Mass[Pos++]);
      Crossing.node_Edge = new TEdge[EL];
      for (int i = 0; i < EL; i++)
      {
        Crossing.node_Edge[i].edge_NameNode = Mass[Pos++];
        Crossing.node_Edge[i].edge_Visible = bool.Parse(Mass[Pos++]);
        Crossing.node_Edge[i].edge_Level = int.Parse(Mass[Pos++]);
      }
      return Crossing;
    }

    //======================================================================  Примитивные операции с узлами и ребрами

    public void AddEdge(int Level, int Count, out string Error)
    {
      Error = "";
      SetEdge(SelectNode, SelectNodeBeg, Level, Count);
      CurrentLine = new TEdge();
    }               //Добавить ребро
    void SetEdge(TNode First, TNode Second, int Level, int Count)  //Расширение: Двустороннее ребро
    {
      Random rnd = new Random();
      string ID = rnd.Next(0, 1000000).ToString() + rnd.Next(-10000000, -1).ToString();
      int n = ReturnNumber(First.node_Name);
      int L = 0;
      if (Second.node_Edge != null)
        L = Second.node_Edge.Length;
      Array.Resize(ref Second.node_Edge, ++L);
      Second.node_Edge[L - 1].edge_NameNode = Nodes[n].node_Name;
      Second.node_Edge[L - 1].edge_Level = Level;
      List<_edge_Points> Points = new List<_edge_Points>();
      n = CurrentLine.edge_Points.Count;
      for (int i = 0; i < n; i++)
        Points.Add(CurrentLine.edge_Points[n - i - 1]);
      Second.node_Edge[L - 1].edge_Points = Points;
      Second.node_Edge[L - 1].edge_Rows = Count;
      Second.node_Edge[L - 1].edge_NameEdge = ID;
      Second.node_Edge[L - 1].edge_Marked_Name = false;

      n = ReturnNumber(Second.node_Name);
      L = 0;
      if (First.node_Edge != null)
        L = First.node_Edge.Length;
      Array.Resize(ref SelectNode.node_Edge, ++L);
      First.node_Edge[L - 1].edge_NameNode = Nodes[n].node_Name;
      First.node_Edge[L - 1].edge_Level = Level;
      First.node_Edge[L - 1].edge_Points = CurrentLine.edge_Points;
      First.node_Edge[L - 1].edge_Rows = Count;
      First.node_Edge[L - 1].edge_NameEdge = ID;
      First.node_Edge[L - 1].edge_Marked_Name = true;
    }
    public void AddCityNode(int MouseX, int MouseY)//Город
    {
      int N = Nodes.Length, l = 0;
      Array.Resize(ref Nodes, ++N);
      Array.Resize(ref NodeNamesArr, N);
      Nodes[N - 1] = new TNode();
      string Name = null;
      for (int k = 0; k < N; k++)
      {
        bool Ok = true;
        Name = "City " + Convert.ToString(l);
        for (int i = 0; i < N; i++)
          if (Nodes[i].node_Name == Name)
          {
            Ok = false;
            break;
          }
        if (Ok)
          break;
        else
          l++;
      }
      //Анцестор пустой
      Nodes[N - 1].node_Name = Name;
      Nodes[N - 1].node_x = XX(MouseX);
      Nodes[N - 1].node_y = YY(MouseY);
      Nodes[N - 1].node_Visible = true;
      Nodes[N - 1].node_Level = 1;
      NodeNamesArr[N - 1] = Name;
      Nodes[N - 1].node_IsDescendant = false;
      Nodes[N - 1].node_Points = CurrentLine.edge_Points;
      int T = 0;
      TNode[] Undernodes = new TNode[T];
      for (int i = 0; i < N; i++)
      {
        if (Nodes[i].node_Level == 2 && !Nodes[i].node_IsDescendant && IsPointInPolygon(CurrentLine.edge_Points, Nodes[i].node_x, Nodes[i].node_y))
        {
          Array.Resize(ref Undernodes, ++T);
          Undernodes[T - 1] = Nodes[i];
          Nodes[i].node_Ancestor = Nodes[N - 1].node_Name;
          Nodes[i].node_IsDescendant = true;
        }
      }
      if (T != 0)
        Nodes[N - 1].node_UnderNodes = Undernodes;
    }
    public void AddDistrictNode(int MouseX, int MouseY)
    {
      int N = Nodes.Length, l = 0;
      Array.Resize(ref Nodes, ++N);
      Array.Resize(ref NodeNamesArr, N);
      Nodes[N - 1] = new TNode();
      string Name = null;
      for (int k = 0; k < N; k++)
      {
        bool Ok = true;
        Name = "Distr " + Convert.ToString(l);
        for (int i = 0; i < N; i++)
          if (Nodes[i].node_Name == Name)
          {
            Ok = false;
            break;
          }
        if (Ok)
          break;
        else
          l++;
      }
      
      Nodes[N - 1].node_Name = Name;
      Nodes[N - 1].node_x = XX(MouseX);
      Nodes[N - 1].node_y = YY(MouseY);
      Nodes[N - 1].node_Level = 2;
      NodeNamesArr[N - 1] = Name;
      Nodes[N - 1].node_Points = CurrentLine.edge_Points;
      int T = 0;
      TNode[] Undernodes = new TNode[T];
      for (int i = 0; i < N; i++)
      {
        if (Nodes[i].node_Level == 3 && !Nodes[i].node_IsDescendant && IsPointInPolygon(CurrentLine.edge_Points, Nodes[i].node_x, Nodes[i].node_y))
        {
          Array.Resize(ref Undernodes, ++T);
          Undernodes[T - 1] = Nodes[i];
          Nodes[i].node_Ancestor = Nodes[N - 1].node_Name;
          Nodes[i].node_IsDescendant = true;
        }
      }
      if (T != 0)
        Nodes[N - 1].node_UnderNodes = Undernodes;
    }  //Район
    public void AddCrossing(int MouseX, int MouseY)
    {
      int N = Nodes.Length, l = 0;
      Array.Resize(ref Nodes, ++N);
      Array.Resize(ref NodeNamesArr, N);
      Nodes[N - 1] = new TNode();
      string Name = null;
      for (int k = 0; k < N; k++)
      {
        bool Ok = true;
        Name = "Cross " + Convert.ToString(l);
        for (int i = 0; i < N; i++)
          if (Nodes[i].node_Name == Name)
          {
            Ok = false;
            break;
          }
        if (Ok)
          break;
        else
          l++;
      }
      Nodes[N - 1].node_Name = Name;
      Nodes[N - 1].node_x = XX(MouseX);
      Nodes[N - 1].node_y = YY(MouseY);
      Nodes[N - 1].node_Level = 3;
      NodeNamesArr[N - 1] = Name;
    }      //Перекресток
    public void AddDescendant(string Ancestor)
    {
      int N = ReturnNumber(Ancestor);
      TNode[] NewDescs = new TNode[0];
      SelectNode.node_IsDescendant = true;
      SelectNode.node_Ancestor = Ancestor;
      if (Nodes[N].node_UnderNodes != null)
      {
        int L = Nodes[N].node_UnderNodes.Length;
        Array.Resize(ref NewDescs, L + 1);
        for (int i = 0; i < Nodes[N].node_UnderNodes.Length; i++)
          NewDescs[i] = Nodes[N].node_UnderNodes[i];
        NewDescs[L] = SelectNode;
        Nodes[N].node_UnderNodes = NewDescs;
      }
      else
      {
        Array.Resize(ref NewDescs, 1);
        NewDescs[0] = SelectNode;
        Nodes[N].node_UnderNodes = NewDescs;
      }
    }  //Добавить SelectNode потомком для Ancestor
    public void DeleteNode()
    {
      int n = ReturnNumber(SelectNode.node_Name);
      if (SelectNode.node_UnderNodes != null)
        DeleteDescendants(SelectNode);
      if (SelectNode.node_Edge != null)
        DeleteAllEdges(SelectNode);
      if (SelectNode.node_IsDescendant)
      {
        bool Deleted = false;
        int K = Nodes.Length;
        for (int h = 0; h < K && !Deleted; h++)
          if (Nodes[h] != null && Nodes[h].node_Level == SelectNode.node_Level - 1)
          {
            int G = Nodes[h].node_UnderNodes.Length;
            for (int i = 0; i < G; i++)
              if (Nodes[h].node_UnderNodes[i].node_Name == SelectNode.node_Name)
              {
                Nodes[h].node_UnderNodes[i] = null;
                TNode[] NewArr;
                if (G - 1 != 0)
                {
                  NewArr = new TNode[G - 1];
                  if (G - 1 != 0)
                  {
                    for (int y = 0, k = 0; y < G; y++)
                      if (Nodes[h].node_UnderNodes[y] != null)
                        NewArr[k++] = Nodes[h].node_UnderNodes[y];
                    Nodes[h].node_UnderNodes = NewArr;
                    Deleted = true;
                    break;
                  }
                }
                else
                  Nodes[h] = null;
                Deleted = true;
                break;
              }
            h += G;
          }
      }
      Nodes[n] = null;
      SelectNode = null;
      ResetNodesArray();
      ResetNamesArr();
    }
    void DeleteDescendants(TNode Node)
    { //Проверка не нужна, т.к. в основном методе
      int Leng = Node.node_UnderNodes.Length;
      for (int i = 0; i < Leng; i++)
      {
        if (Node.node_UnderNodes[i].node_UnderNodes != null)
        {
          DeleteDescendants(Node.node_UnderNodes[i]);
          Node.node_UnderNodes[i].node_UnderNodes = null;
          DeleteAllEdges(Node.node_UnderNodes[i]);
          Nodes[ReturnNumber(Node.node_UnderNodes[i].node_Name)] = Node.node_UnderNodes[i] = null;
        }
        else
        {
          DeleteAllEdges(Node.node_UnderNodes[i]);
          Nodes[ReturnNumber(Node.node_UnderNodes[i].node_Name)] = Node.node_UnderNodes[i] = null;
        }
      }
    }
    public void DelEdge(int NumNode, int NumEdge)  // удалить ребро
    {
      int L = Nodes[NumNode].node_Edge.Length;
      for (int i = NumEdge; i < L - 2; i++)
        Nodes[NumNode].node_Edge[i] = Nodes[NumNode].node_Edge[i + 1];
      Array.Resize(ref Nodes[NumNode].node_Edge, L - 1);
    }
    public void DeleteEdge() //Удалить двойную связь
    {
      if (SelectNode.node_Name != SelectNodeBeg.node_Name && SelectNode.node_Edge != null)
      {
        SelectNode.node_Edge = EdgeArrDeleted(SelectNode, SelectNodeBeg.node_Name);
        SelectNodeBeg.node_Edge = EdgeArrDeleted(SelectNodeBeg, SelectNode.node_Name);
      }
    }
    public void DeleteAllEdges(TNode Node)
    {
      if (Node.node_Edge != null)
      {
        int NNum = ReturnNumber(Node.node_Name);
        int NL = Node.node_Edge.Length;
        for (int i = 0; i < NL; i++)
        {
          int Num = ReturnNumber(Node.node_Edge[i].edge_NameNode);
          Nodes[Num].node_Edge = EdgeArrDeleted(Nodes[Num], Node.node_Name);
        }
      }
    }
    int NullCount(TEdge[] Input, out int Pos)
    {
      int Count = 0;
      Pos = 0;
      for (int i = 0; i < Input.Length; i++)
        if (Input[i].edge_NameNode == null)
        {
          Pos = i;
          Count++;
        }
      return Count;
    }
    public TEdge[] EdgeArrDeleted(TNode Node, string NeedToDelete)  //Черная магия с удалением связей
    {
      TEdge[] Out = null;
      if (Node.node_Edge != null && Node.node_Edge.Length != 1)
      {
        Out = new TEdge[Node.node_Edge.Length - 1];
        int Length = Node.node_Edge.Length, Position = 0;
        for (int i = 0; i < Length; i++)
          if (Node.node_Edge[i].edge_NameNode != NeedToDelete)
            Out[Position++] = Node.node_Edge[i];
        int Pos = 0;
        while (NullCount(Out, out Pos) != 0)
          Out[Position++] = Node.node_Edge[Pos];
      }
      return Out;
    }
    double VectorLength(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
    }
    void FindMaxVectorCoords(List<_edge_Points> Input, out int X1Y1Element, out int X2Y2Element)
    {
      X1Y1Element = X2Y2Element = 0;
      int Count = Input.Count;
      double MaxLength = double.MinValue;
      for (int i = 1; i < Count; i++)
      {
        double Vector = VectorLength(Input[i - 1].edge_x, Input[i - 1].edge_y, Input[i].edge_x, Input[i].edge_y);
        if (Vector > MaxLength)
        {
          MaxLength = Vector;
          X1Y1Element = i - 1;
          X2Y2Element = i;
        }
      }
    }

    //=====================================================================  Утилиты рисования

    void DrawMassCities(bool IsJustLine)
    {
      int Length = Nodes.Length;
      for (int i = 0; i < Length; i++)
      {
        if (Nodes[i].node_Level == 1)
          DrawCity(Nodes[i], IsJustLine);
      }
    }
    void DrawMassDistricts(bool IsJustLine)
    {
      int Length = Nodes.Length;
      for (int i = 0; i < Length; i++)
      {
        if (Nodes[i].node_Level == 2)
          DrawDistrict(Nodes[i], IsJustLine);
      }
    }
    void DrawMassCrossings(bool IsJustPoint)
    {
      int Length = Nodes.Length;
      for (int i = 0; i < Length; i++)
      {
        if (Nodes[i].node_Level == 3)
          DrawCrossing(Nodes[i], IsJustPoint);
      }
    }
    void DrawCity(TNode City, bool IsJustLine)
    {
      using (Graphics g = Graphics.FromImage(bitmap))
      {
        MyFont = new Font("Courier New", (float)(20 * I2 / (x2p - x1p)), FontStyle.Bold);
        string s = Convert.ToString(City.node_Name);
        if (!IsJustLine)
        {
          Brush MyBr = SelectNode == City ? Brushes.Yellow : Brushes.LightBlue;
          Pen MyP = SelectNode == City ? Pens.Red : Pens.DarkOrange;
          int K = II(180 + x1p - 0);

          double CentX, CentY;
          FindCenter(City.node_Points, out CentX, out CentY);
          g.DrawPolygon(MyP, StructToPoints(City.node_Points).ToArray());
          g.FillPolygon(MyBr, StructToPoints(City.node_Points).ToArray());
          SizeF tempsize = g.MeasureString(s, MyFont);
          g.DrawString(s, MyFont, Brushes.Black,
              II(CentX - 0) - tempsize.Width / 2,
              JJ(CentY - 0) - tempsize.Height / 2);
        }
        else
          g.DrawPolygon(Pens.Gray, StructToPoints(City.node_Points).ToArray());
      }
    }
    void DrawDistrict(TNode District, bool IsJustLine)
    {
      using (Graphics g = Graphics.FromImage(bitmap))
      {
        MyFont = new Font("Courier New", (float)(6 * I2 / (x2p - x1p)), FontStyle.Bold);
        string s = Convert.ToString(District.node_Name);
        if (!IsJustLine)
        {
          Brush MyBr = SelectNode == District ? Brushes.Yellow : Brushes.GhostWhite;
          Pen MyP = SelectNode == District ? Pens.Red : Pens.Silver;
          int K = II(80 + x1p - 0);

          double CentX, CentY;
          FindCenter(District.node_Points, out CentX, out CentY);
          g.DrawPolygon(MyP, StructToPoints(District.node_Points).ToArray());
          g.FillPolygon(MyBr, StructToPoints(District.node_Points).ToArray());
          SizeF tempsize = g.MeasureString(s, MyFont);
          g.DrawString(s, MyFont, CurrentLevel == 2 ? Brushes.Gray : Brushes.Black,
              II(CentX - 0) - tempsize.Width / 2,
              JJ(CentY - 0) - tempsize.Height / 2);
        }
        else
          g.DrawPolygon(Pens.Gray, StructToPoints(District.node_Points).ToArray());
      }
    }
    void DrawCrossing(TNode Crossing, bool IsJustPoint)
    {
      using (Graphics g = Graphics.FromImage(bitmap))
      {
        MyFont = new Font("Courier New", (float)(0.3 * I2 / (x2p - x1p)), FontStyle.Bold);
        string s = Convert.ToString(Crossing.node_Name);

        Brush MyBr = SelectNode == Crossing ? Brushes.Yellow : Brushes.LightGreen;
        Pen MyP = SelectNode == Crossing ? Pens.Red : Pens.DarkGreen;
        int K = II(2 + x1p - 0);
        if (!IsJustPoint)
        {
          g.FillRectangle(MyBr, II(Crossing.node_x - 0) - K / 2, JJ(Crossing.node_y - 0) - K / 2, K, K);
          g.DrawRectangle(MyP, II(Crossing.node_x - 0) - K / 2, JJ(Crossing.node_y - 0) - K / 2, K, K);
          SizeF tempsize = g.MeasureString(s, MyFont);
          g.DrawString(s, MyFont, Brushes.Black,
              II(Crossing.node_x - 0) - tempsize.Width / 2,
              JJ(Crossing.node_y - 0) - tempsize.Height / 2);
        }
        else
        {
          g.FillEllipse(Brushes.LightGray, II(Crossing.node_x - 0) - K / 2, JJ(Crossing.node_y - 0) - K / 2, K, K);
          g.DrawEllipse(Pens.Silver, II(Crossing.node_x - 0) - K / 2, JJ(Crossing.node_y - 0) - K / 2, K, K);
        }
      }
    }

    void DrawAdditionalEdges(Color RoadColor, double x0, double y0, double x1, double y1, int Num)
    {
      if (Num != 0)
        using (Graphics g = Graphics.FromImage(bitmap))
        {
          Pen MyPen = new Pen(RoadColor);
          double D = 0, x2 = 0, y2 = 0, x3 = 0, y3 = 0;
          D = (0.04 * (y1 - y0) * (y1 - y0)) / ((y1 - y0) * (y1 - y0) + (x1 - x0) * (x1 - x0));
          x2 = x0 - Math.Sqrt(D);
          y2 = Math.Sqrt(0.04 - (x2 - x0) * (x2 - x0)) + y0;
          x3 = x1 + x2 - x0;
          y3 = y1 - y0 + y2;

          g.DrawLine(MyPen, new Point(II(x2), JJ(y2)), new Point(II(x3), JJ(y3)));
          DrawAdditionalEdges(RoadColor, x2, y2, x3, y3, Num - 1);
        }
    }
    void DrawEdge(TEdge Road)
    {
      using (Graphics g = Graphics.FromImage(bitmap))
      {
        Color MyColor = Road.edge_NameEdge == SelectEdge.edge_NameEdge ? Color.Red : Road.edge_Level == 0 ? Color.Silver : Road.edge_Level == 1 ? Color.Black : Color.Orange;
        Pen MyPen = new Pen(MyColor);

        int Length = Road.edge_Points.Count;
        for (int i = 1; i < Length; i++)
        {
          g.DrawLine(MyPen, new Point(II(Road.edge_Points[i - 1].edge_x), JJ(Road.edge_Points[i - 1].edge_y)),
                   new Point(II(Road.edge_Points[i].edge_x), JJ(Road.edge_Points[i].edge_y)));
          DrawAdditionalEdges(MyColor, Road.edge_Points[i - 1].edge_x, Road.edge_Points[i - 1].edge_y,
              Road.edge_Points[i].edge_x, Road.edge_Points[i].edge_y, Road.edge_Rows - 1);
        }
      }
    }
    void DrawName(TEdge Road, Brush brush)
    {
      int First, Second;
      MyFont = new Font("Courier New", (float)(I2 / (x2p - x1p)), FontStyle.Bold);
      FindMaxVectorCoords(Road.edge_Points, out First, out Second);
      double x1 = Road.edge_Points[First].edge_x,
        x2 = Road.edge_Points[Second].edge_x,
        y1 = Road.edge_Points[First].edge_y, 
        y2 = Road.edge_Points[Second].edge_y;
      double Angle = Math.Atan((y2 - y1) / (x2 - x1))/ 3.14 * 180;
      int X = II(x1);
      int Y = JJ(y1);
      using (Graphics g = Graphics.FromImage(bitmap))
      {
        g.TranslateTransform(X, Y);
        g.RotateTransform((int)Angle);
        g.DrawString(Road.edge_NameEdge, MyFont, brush, 0, 0);
        g.RotateTransform((int)-Angle);
        g.TranslateTransform(-X, -Y);
      }
    }
    void FindCenter(List<_edge_Points> Points, out double CentX, out double CentY)
    {
      CentX = CentY = 0;
      int Count = Points.Count;
      double MaxY = double.MinValue, MaxX = double.MinValue, MinY = double.MaxValue, MinX = double.MaxValue;
      for (int i = 0; i < Count; i++)
      {
        if (Points[i].edge_x > MaxX)
          MaxX = Points[i].edge_x;
        if (Points[i].edge_x < MinX)
          MinX = Points[i].edge_x;
        if (Points[i].edge_y > MaxY)
          MaxY = Points[i].edge_y;
        if (Points[i].edge_y < MinY)
          MinY = Points[i].edge_y;
      }
      CentY = (MaxY - MinY) * 0.5 + MinY;
      CentX = (MaxX - MinX) * 0.5 + MinX;
    }
    public bool IsPointInPolygon(List<_edge_Points> polygon, double X, double Y)    //Мегаметод (не мой)
    {
      bool isInside = false;
      for (int i = 0, j = polygon.Count - 1; i < polygon.Count; j = i++)
        if (((polygon[i].edge_y > Y) != (polygon[j].edge_y > Y)) &&
        (X < (polygon[j].edge_x - polygon[i].edge_x) * (Y - polygon[i].edge_y) / (polygon[j].edge_y - polygon[i].edge_y) + polygon[i].edge_x))
          isInside = !isInside;
      return isInside;
    }
    List<Point> StructToPoints(List<_edge_Points> Old)
    {
      List<Point> New = new List<Point>();
      int L = Old.Count;
      for (int i = 0; i < L; i++)
        New.Add(new Point(II(Old[i].edge_x), JJ(Old[i].edge_y)));
      return New;
    }
    public void FindSecondaryLine(out int i1, out int k1)
    {
      i1 = 0;
      k1 = 0;
      int n = ReturnNumber(Nodes[_I].node_Edge[_K].edge_NameNode);
      int J = Nodes[n].node_Edge.Length;
      for (int i = 0; i < J; i++)
        if (Nodes[n].node_Edge[i].edge_NameNode == Nodes[_I].node_Name)
        {
          i1 = n;
          k1 = i;
          break;
        }
    }
  }
}