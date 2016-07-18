using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace _18_21
{
  public class HoTSNode                   // узел
  {
    public int node_Data;
    public HoTSNode node_Left;
    public HoTSNode node_Right;
    public int x;
    public int y;
    public bool visit;

    public HoTSNode(HoTSNode Left, HoTSNode Right, int Data, int x, int y) // конструктор
    {
      node_Left = Left;
      node_Right = Right;
      node_Data = Data;
      this.x = x;
      this.y = y;
      visit = false;
    }
  }

  public class HoTSTree
  {
    public HoTSNode tree_Top;
    public HoTSNode tree_NodeSelect;
    public Bitmap tree_Canvas;

    bool Result = false;
    Graphics _Graph;
    Pen _Ren;
    SolidBrush _Brush = (SolidBrush)Brushes.White;
    Font _Font;


    public HoTSTree(int VW, int VH)       // конструктор
    {
      tree_Top = null;
      tree_Canvas = new Bitmap(VW, VH);
      _Font = new Font("Courier New", 10, FontStyle.Bold);
    }

    public void HoTSDeSelect(HoTSNode Node)
    {
      if (Node != null)
      {
        HoTSDeSelect(Node.node_Left);
        Node.visit = false;
        HoTSDeSelect(Node.node_Right);
      }
    }

    public void HoTSInsert(ref HoTSNode t, int data, int x, int y)  // вставка
    {
      if (t == null)
        t = new HoTSNode(null, null, data, x, y);
      else
          if (data < Convert.ToInt32(t.node_Data))
        HoTSInsert(ref t.node_Left, data, t.x - 50, t.y + 50);
      else
        HoTSInsert(ref t.node_Right, data, t.x + 50, t.y + 50);
      
    }

    void HoTSGetNum(HoTSNode p)
    {
      if (p != null)
      {
        if (p.node_Left != null && p.node_Left.node_Data == p.node_Data)
          Result = true;
        else
            if (p.node_Right != null && p.node_Right.node_Data == p.node_Data)
          Result = true;
        else
        {
          HoTSGetNum(p.node_Left);
          HoTSGetNum(p.node_Right);
        }
      }
    }

    public bool HoTSGetResult()
    {
      HoTSGetNum(tree_Top);
      return Result;
    }

    // ======
    public void Delta(HoTSNode p, int dx, int dy)  // смещение поддерева
    {
      p.x -= dx; p.y -= dy;
      if (p.node_Left != null)
        Delta(p.node_Left, dx, dy);
      if (p.node_Right != null)
        Delta(p.node_Right, dx, dy);
    }

    public HoTSNode FindNode(HoTSNode p, int x, int y) // поиск по координатам 
    {
      HoTSNode result = null;
      if (p == null)
        return result;
      if (((p.x - x) * (p.x - x) + (p.y - y) * (p.y - y)) < 100)
        result = p;
      else
      {
        result = FindNode(p.node_Left, x, y);
        if (result == null)
          result = FindNode(p.node_Right, x, y);
      }
      return result;
    }

    void DrawNode(HoTSNode p)               // рисование дерева
    {
      int R = 17;
      if (p.node_Left != null)
        _Graph.DrawLine(_Ren, p.x, p.y, p.node_Left.x, p.node_Left.y);
      if (p.node_Right != null)
        _Graph.DrawLine(_Ren, p.x, p.y, p.node_Right.x, p.node_Right.y);

      if (p.visit)
        _Brush = (SolidBrush)Brushes.Yellow;
      else
        _Brush = (SolidBrush)Brushes.LightYellow;

      _Graph.FillEllipse(_Brush, p.x - R, p.y - R, 2 * R, 2 * R);
      _Graph.DrawEllipse(_Ren, p.x - R, p.y - R, 2 * R, 2 * R);
      string s = Convert.ToString(p.node_Data);
      SizeF size = _Graph.MeasureString(s, _Font);
      _Graph.DrawString(s, _Font, Brushes.Black,
          p.x - size.Width / 2,
          p.y - size.Height / 2);

      if (p.node_Left != null)
        DrawNode(p.node_Left);
      if (p.node_Right != null)
        DrawNode(p.node_Right);
    }

    public void Draw()                  // рисование дерева
    {
      using (_Graph = Graphics.FromImage(tree_Canvas))
      {
        Color cl = Color.FromArgb(255, 255, 255);
        _Graph.Clear(cl);
        _Ren = Pens.Black;
        if (tree_Top != null)
          DrawNode(tree_Top);
      }
    }
  }
}
