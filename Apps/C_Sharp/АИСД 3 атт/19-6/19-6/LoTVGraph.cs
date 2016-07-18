using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace _19_6
{
  public struct TEdge
  {
    public string nameNode;      // № узла
    public int x1c, x2c, yc; // геометрия дуги
    public Color color;      // цвет
    public bool select;
  }

  public class TNode
  {
    public string name;  // 4+4*Name.Length
    public TEdge[] Edge; // 4+L2*(5*4) - ребра
    public bool visit;
    public int x, y;     // 4+4
    public int numVisit; // № визита
    public Color color;  // цвет
  }

  public struct Lib
  {
    public static LoTVGraph graph;     // граф
    public static int NumNode;     // № узла
    public static int Num;
    public static int[] arr = new int[100];
    public static List<string> Names;
  }

  public class LoTVGraph
  {
    const int hx = 50, hy = 10;
    public Bitmap bitmap;
    public TNode[] Nodes = new TNode[0];// узлы
    public static TNode SelectNode;
    public static TNode SelectNodeBeg;
    public int x1;
    public int x2;
    public int y1;
    public int y2;
    Font MyFont;
    byte[] byData;
    int ofs = 0;

    public LoTVGraph(int VW, int VH)
    {
      bitmap = new Bitmap(VW, VH);
      MyFont = new Font("Courier New", 10, FontStyle.Bold);
    }

    public void AddEdge()  // добавить ребро
    {
      int n = -1;
      bool ok = false;
      int Ln = Nodes.Length;
      while ((n < Ln - 1) && !ok)
        ok = Nodes[++n] == SelectNode;

      int L = 0;
      if (SelectNodeBeg.Edge != null)
        L = SelectNodeBeg.Edge.Length;
      Array.Resize(ref SelectNodeBeg.Edge, ++L);
      SelectNodeBeg.Edge[L - 1].nameNode = Nodes[n].name;
      SelectNodeBeg.Edge[L - 1].x1c = x1 - SelectNodeBeg.x;
      SelectNodeBeg.Edge[L - 1].x2c = x2 - SelectNode.x;
      SelectNodeBeg.Edge[L - 1].yc = (SelectNode.y + SelectNodeBeg.y) / 2;
      SelectNodeBeg.Edge[L - 1].color = Color.Silver;

      n = -1;
      ok = false;
      while ((n < Ln - 1) && !ok)
        ok = Nodes[++n] == SelectNodeBeg;
      L = 0;
      if (SelectNode.Edge != null)
        L = SelectNode.Edge.Length;

      Array.Resize(ref SelectNode.Edge, ++L);
      SelectNode.Edge[L - 1].nameNode = Nodes[n].name;
      SelectNode.Edge[L - 1].x1c = x2 - SelectNode.x;
      SelectNode.Edge[L - 1].x2c = x1 - SelectNodeBeg.x;
      SelectNode.Edge[L - 1].yc = (SelectNodeBeg.y + SelectNode.y) / 2;
      SelectNode.Edge[L - 1].color = Color.Silver;
    }
    public void AddNode(int x, int y) // добавить узел 
    {
      int N = Nodes.Length, l = 0;
      Array.Resize(ref Nodes, ++N);
      Nodes[N - 1] = new TNode();
      string Name = null;
      for (int k = 0; k < N; k++)
      {
        bool Ok = true;
        Name = "Node " + Convert.ToString(l);
        for (int i = 0; i < N; i++)
          if (Nodes[i].name == Name)
          {
            Ok = false;
            break;
          }
        if (Ok)
          break;
        else
          l++;
      }
      Nodes[N - 1].name = Name;
      Nodes[N - 1].x = x;
      Nodes[N - 1].y = y;
      Nodes[N - 1].color = Color.White;
    }
    public void Clear() // очистить граф 
    {
      int N = Nodes.Length;
      for (int i = 0; i < N; i++)
        Array.Resize<TEdge>(ref Nodes[i].Edge, 0);
      Array.Resize<TNode>(ref Nodes, 0);
    }
    public void DeSelectEdge()
    {
      int N = Nodes.Length;
      for (int i = 0; i < N; i++)
      {
        if (Nodes[i].Edge != null)
        {
          int L = Nodes[i].Edge.Length;
          for (int j = 0; j < L; j++)
            Nodes[i].Edge[j].select = false;
        }
      }
    }

    protected int LengthFile()  // вычислить размер файла
    {
      int n = 4;
      int L1 = Nodes.Length;
      for (int i = 0; i <= L1 - 1; i++)
      {
        n += 16 + 4 * Nodes[i].name.Length;
        int L2 = 0;
        if (Nodes[i].Edge != null)
          L2 = Nodes[i].Edge.Length;
        n += L2 * 16;
        for (int k = 0; k < L2; k++)
          n += Nodes[i].Edge[k].nameNode.Length * 4;
      }
      return n;
    }
    protected void IntInData(int k)
    {
      byte[] byByte;
      byByte = BitConverter.GetBytes(k);
      byByte.CopyTo(byData, ofs);
      ofs += 4;
    }
    protected void StrInData(string s)
    {
      byte[] byByte;
      int L = s.Length;
      IntInData(L);
      char[] charData = s.ToCharArray();
      byByte = new byte[4 * charData.Length];
      Encoder e = Encoding.UTF32.GetEncoder();
      e.GetBytes(charData, 0, charData.Length, byByte, 0, true);
      byByte.CopyTo(byData, ofs);
      ofs += 4 * L;
    }
    protected int DataInInt()
    {
      int result = BitConverter.ToInt32(byData, ofs);
      ofs += 4;
      return result;
    }
    protected string DataInStr()
    {
      byte[] byByte;
      int L = DataInInt(); //BitConverter.ToInt32(byData, ofs); ofs += 4;
      byByte = new byte[4 * L];

      for (int j = 0; j <= 4 * L - 1; j++)
        byByte[j] = byData[j + ofs];
      char[] charData = new char[L];
      Decoder d = Encoding.UTF32.GetDecoder();
      d.GetChars(byByte, 0, byByte.Length, charData, 0);

      string s = "";
      for (int j = 0; j < charData.Length; j++)
        s += charData[j];
      ofs += 4 * L;

      return s;
    }
    public void Save(string FileName)  // записать
    {
      ofs = 0;

      FileStream aFile = new FileStream(FileName, FileMode.Create);
      int N = LengthFile();
      byData = new byte[N];

      int L1 = Nodes.Length;
      IntInData(L1);

      for (int i = 0; i <= L1 - 1; i++)
      {
        IntInData(Nodes[i].x);
        IntInData(Nodes[i].y);
        StrInData(Nodes[i].name);

        int L2 = 0;
        if (Nodes[i].Edge != null)
          L2 = Nodes[i].Edge.Length;
        IntInData(L2);
        for (int j = 0; j <= L2 - 1; j++)
        {
          IntInData(Nodes[i].Edge[j].x1c);
          IntInData(Nodes[i].Edge[j].x2c);
          IntInData(Nodes[i].Edge[j].yc);
          StrInData(Nodes[i].Edge[j].nameNode);
        }
      }
      aFile.Write(byData, 0, N);
      aFile.Close();
    }
    public void Read(string FileName) // прочитать
    {
      ofs = 0;
      FileStream aFile = new FileStream(FileName, FileMode.Open);
      int N = (int)aFile.Length;
      byData = new byte[N];
      aFile.Read(byData, 0, N);

      int L1 = DataInInt();
      Nodes = new TNode[L1];
      for (int i = 0; i <= L1 - 1; i++)
      {
        Nodes[i] = new TNode();
        Nodes[i].x = DataInInt();
        Nodes[i].y = DataInInt();
        Nodes[i].name = DataInStr();

        int L2 = DataInInt();
        Nodes[i].Edge = new TEdge[L2];
        if (L2 != 0)
          for (int j = 0; j <= L2 - 1; j++)
          {
            Nodes[i].Edge[j].x1c = DataInInt();
            Nodes[i].Edge[j].x2c = DataInInt();
            Nodes[i].Edge[j].yc = DataInInt();
            Nodes[i].Edge[j].nameNode = DataInStr();
            Nodes[i].Edge[j].color = Color.Silver;
          }
      }

      aFile.Close();
    }

    public void ClearVisit()
    {
      int N = Nodes.Length;
      Lib.Num = 0;
      for (int i = 0; i <= N - 1; i++)
      {
        Nodes[i].visit = false;
        Nodes[i].numVisit = 0;
        Nodes[i].color = Color.White;
        int L = 0;
        if (Nodes[i].Edge != null)
        {
          L = Nodes[i].Edge.Length;
          for (int j = 0; j <= L - 1; j++)
            Nodes[i].Edge[j].color = Color.Silver;
        }
      }
    }
    int ReturnNumber(string Name)
    {
      int v, l = Nodes.Length;
      for (v = 0; v < l; v++)
        if (Nodes[v].name == Name)
          break;
      return v;
    }
    void VisitTrue(string Name)  // отметить посещенный
    {
      int v;
      for (v = 0; v < Nodes.Length; v++)
        if (Nodes[v].name == Name)
          break;
      Nodes[v].visit = true;
      Lib.Num++;
      Nodes[v].numVisit = Lib.Num;

    }
    void SetEdgeBlack(string MyName, string NotMyName)    // закрасить дугу
    {
      int v = ReturnNumber(MyName);
      if (Nodes[v].Edge != null)
      {
        int Leng = Nodes[v].Edge.Length;
        int i = 0;
        for (i = 0; i < Leng; i++)
          if (Nodes[v].Edge[i].nameNode == NotMyName)
            break;
        Nodes[v].Edge[i].color = Color.Black;
        v = ReturnNumber(NotMyName);
        Leng = Nodes[v].Edge.Length;
        for (i = 0; i < Leng; i++)
          if (Nodes[v].Edge[i].nameNode == MyName)
            break;
        Nodes[v].Edge[i].color = Color.Black;
      }
    }

    void FindDepth(string Name)
    {
      VisitTrue(Name);              // отметить посещенный
      int LL = 0;
      int n = ReturnNumber(Name);
      LL = Nodes[n].Edge.Length;
      int i = -1;
      while (i < LL - 1)
      {
        string NewName = Nodes[n].Edge[++i].nameNode;
        int m = ReturnNumber(NewName);
        if (!Nodes[m].visit)
        {
          SetEdgeBlack(Name, NewName); // закрасить ребро
          FindDepth(NewName);
        }
      }
    }
    public void SetTreeDepth(string Name)
    {
      ClearVisit();
      FindDepth(Name);
    }
    public string ReturnNotNeeded()
    {
      string Out = null;
      int All = Nodes.Length;
      for (int i = 0; i < All; i++)
      {
        if (Nodes[i].Edge != null)
        {
          int Edges = Nodes[i].Edge.Length;
          int Silvcount = 0, Blackcount = 0;
          for (int k = 0; k < Edges; k++)
            if (Nodes[i].Edge[k].color != Color.Black)
              Silvcount++;
            else
              Blackcount++;
          if (Silvcount == 1 && Silvcount == Blackcount)
            Out += Nodes[i].name + " ";
        }
      }
      return Out;
    }
    public void DeleteNode()
    {
      int n = -1;
      bool ok = false;
      int Ln = Nodes.Length;
      while ((n < Ln - 1) && !ok)
        ok = Nodes[++n] == SelectNode;

      if (SelectNode.Edge != null)
      {
        Ln = SelectNode.Edge.Length;
        for (int i = 0; i < Ln; i++)
        {
          int NumNode = ReturnNumber(SelectNode.Edge[i].nameNode);
          int LN = Nodes[NumNode].Edge.Length;
          TEdge[] New = new TEdge[LN - 1];
          for (int k = 0; k < LN; k++)
            if (ReturnNumber(Nodes[NumNode].Edge[k].nameNode) == n)
            {
              Nodes[NumNode].Edge[k] = new TEdge();
              break;
            }
          int count = 0;
          for (int l = 0; l < LN; l++)
            if (Nodes[NumNode].Edge[l].nameNode != null)
            {
              New[count] = Nodes[NumNode].Edge[l];
              count++;
            }
          Nodes[NumNode].Edge = New;
        }
      }
      Nodes[n] = null;
      SelectNode = null;
      Ln = Nodes.Length;
      TNode[] NewArr = new TNode[Ln - 1];
      int Num = 0;
      for (int i = 0; i < Ln; i++)
        if (Nodes[i] != null)
          NewArr[Num++] = Nodes[i];
      Nodes = NewArr;
    }

    public TNode FindNode(int x, int y) // найти узел
    {
      int N = Nodes.Length;
      int i = -1;
      bool Ok = false;
      while ((i < N - 1) && !Ok)
      {
        i++;
        Ok = (Nodes[i].x - hx <= x) && (x <= Nodes[i].x + hx) &&
             (Nodes[i].y - hy <= y) && (y <= Nodes[i].y + hy);
      }
      if (Ok)
        return Nodes[i];
      else
        return null;
    }
    int DistLine(int u, int v, int x1, int y1, int x2, int y2)  // расстояние до линии
    {

      int A = y2 - y1;
      int B = -x2 + x1;
      int C = -x1 * A - y1 * B;
      int D = A * A + B * B;
      if (D != 0)
        return (int)(Math.Abs(A * u + B * v + C) / Math.Sqrt(D));
      else
        return 0;
    }
    public int FindLine(int x, int y, out int NumLine)  // найти ребро
    {
      int L = Nodes.Length;
      bool ok = false; int i = -1; NumLine = -1; int j = -1;
      while ((i < L - 1) && !ok)
      {
        i++;
        if (Nodes[i].Edge != null)
        {
          int L1 = Nodes[i].Edge.Length; j = -1;
          while ((j < L1 - 1) && !ok)
          {
            j++;
            int a1 = Nodes[i].x;
            int b1 = Nodes[i].y;
            int a2 = Nodes[ReturnNumber(Nodes[i].Edge[j].nameNode)].x;
            int b2 = Nodes[ReturnNumber(Nodes[i].Edge[j].nameNode)].y;
            int u1 = Math.Min(a1, a2);
            int u2 = Math.Max(a1, a2);
            int v1 = Math.Min(b1, b2);
            int v2 = Math.Max(b1, b2);
            int Eps = 4;
            ok = (u1 - Eps <= x) && (x <= u2 + Eps) && (v1 - Eps <= y) && (y <= v2 + Eps);
            ok = (DistLine(x, y, a1, b1, a2, b2) <= Eps) && ok;
          }
        }
      }
      if (ok)
      {
        NumLine = j;
        return i;
      }
      else
        return -1;
    }
    public void DelEdge(int NumNode, int NumEdge)  // удалить ребро
    {
      int L = Nodes[NumNode].Edge.Length;
      for (int i = NumEdge; i < L - 2; i++)
        Nodes[NumNode].Edge[i] = Nodes[NumNode].Edge[i + 1];
      Array.Resize<TEdge>(ref Nodes[NumNode].Edge, L - 1);
    }
    public void ChangeBitmap(int VW, int VH)
    {
      bitmap = new Bitmap(VW, VH);
      Draw(false);
    }
    public void Draw(bool fl) // нарисовать
    {
      using (Graphics g = Graphics.FromImage(bitmap))
      {
        Color cl = Color.FromArgb(255, 255, 255);
        g.Clear(cl);
        Pen MyPen = Pens.Black;
        SolidBrush MyBrush = (SolidBrush)Brushes.White;
        string s;
        int N = Nodes.Length;

        //Line
        for (int i = 0; i < N; i++)
        {
          // Edge
          if (Nodes[i].Edge != null)
          {
            int L = Nodes[i].Edge.Length;
            MyBrush.Color = Color.White;
            for (int j = 0; j < L; j++)
            {
              int a1 = Nodes[i].x + Nodes[i].Edge[j].x1c;
              int b1 = Nodes[i].y;
              int a2 = Nodes[ReturnNumber(Nodes[i].Edge[j].nameNode)].x + Nodes[i].Edge[j].x2c;
              int b2 = Nodes[ReturnNumber(Nodes[i].Edge[j].nameNode)].y;


              if (Nodes[i].Edge[j].select)
                MyPen = Pens.Red;
              else
                MyPen = new Pen(Nodes[i].Edge[j].color); // Pens.Black;

              g.DrawLine(MyPen, new Point(a1, b1 + hy), new Point(a1, (b1 + b2) / 2));
              g.DrawLine(MyPen, new Point(a1, (b1 + b2) / 2), new Point(a2, (b1 + b2) / 2));
              g.DrawLine(MyPen, new Point(a2, (b1 + b2) / 2), new Point(a2, b2 - hy));
            }
          }
        }

        // Nodes
        for (int i = 0; i < N; i++)
        {
          if (Nodes[i] == SelectNode)
            MyPen = Pens.Red;
          else
            MyPen = Pens.Silver;
          if (Nodes[i].visit)
            MyBrush.Color = Color.Silver;
          else
              if (Nodes[i] == SelectNode)
            MyBrush.Color = Color.Yellow;
          else
            MyBrush.Color = Color.LightYellow;

          g.FillRectangle(MyBrush, Nodes[i].x - hx, Nodes[i].y - hy, 2 * hx, 2 * hy);
          g.DrawRectangle(MyPen, Nodes[i].x - hx, Nodes[i].y - hy, 2 * hx, 2 * hy);
          s = Convert.ToString(Nodes[i].name);
          SizeF size = g.MeasureString(s, MyFont);
          g.DrawString(s, MyFont, Brushes.Black,
              Nodes[i].x - size.Width / 2,
              Nodes[i].y - size.Height / 2);

        }
        if (fl)
          g.DrawLine(MyPen, new Point(x1, y1), new Point(x2, y2));
      }
    }
  }
}
