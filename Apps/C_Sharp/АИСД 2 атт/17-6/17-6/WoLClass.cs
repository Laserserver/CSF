using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace _17_6
{
  public enum WoLOperations
  {
    AND = 1,
    OR = 2,
  }

  public enum WoLErrors
  {
    NotEnoughBracketException = 9,
    NotEnoughSummandsException = 6,
    NotEnoughElementsException = 5,
    WaitingForExpressionException = 4
  }

  public class WoLLogics
  {
    public byte pars_Err;
    public WoLNode pars_Top;
    public WoLNode pars_SelNode;

    public Bitmap pars_Canvas;
    Graphics _Graph;
    Pen _Pen;
    SolidBrush _Brush = (SolidBrush)Brushes.White;
    Font _Font;

    public abstract class WoLNode  // узел
    {
      public abstract object DoOperation();
      public int x;
      public int y;
      protected object value;
      public object Value
      {
        get
        {
          return DoOperation();
        }
      }
    }

    public class WoLValueNode : WoLNode
    {
      public WoLValueNode(bool Data)
      {
        value = Data;
      }
      public override object DoOperation()
      {
        return value;
      }
    }

    public class WoLOperation : WoLNode
    {
      public WoLOperations opnode_Operation;
      public WoLNode opnode_Left;
      public WoLNode opnode_Right;

      public WoLOperation(WoLOperations Operation, WoLNode Left, WoLNode Right)
      {
        opnode_Left = Left;
        opnode_Operation = Operation;
        opnode_Right = Right;
      }

      public override object DoOperation()
      {
        bool Left = bool.Parse(opnode_Left.DoOperation().ToString());
        bool Right = bool.Parse(opnode_Right.DoOperation().ToString());

        switch (opnode_Operation)
        {
          case WoLOperations.OR:
            value = Left | Right;
            return value;
          case WoLOperations.AND:
            value = Left & Right;
            return value;
          default:
            throw new NotImplementedException();
        }
      }
    }

    public WoLLogics(int Width, int Height)
    {
      pars_Top = null;
      pars_Canvas = new Bitmap(Width, Height);
      _Font = new Font("Courier New", 10, FontStyle.Bold);
      pars_Err = 0;
    }

    bool _WoLTestConst(char Input, params char[] Letters)
    {
      return Array.IndexOf(Letters, Input) >= 0;
    }

    string _WoLTakeElements(ref string Input, byte Number)
    {
      string result = Input.Substring(0, Number);
      Input = Input.Substring(Number);
      Input = Input.Trim();
      return result;
    }

    void _WoLSetValue(ref string Input, out bool Letter)
    {
      Input = Input.Trim();
      Letter = true;
      string Output = "";
      if ((Input != "") && _WoLTestConst(Input[0], 't', 'T', 'F', 'f'))
      {
        Output += _WoLTakeElements(ref Input, 1);
      }
      switch (Output)
      {
        case "T":
        case "t":
          Letter = true;
          break;
        case "F":
        case "f":
          Letter = false;
          break;
      }
      Input.Trim();
    }

    void _WoLFact(ref string Input, out WoLNode Node)  //Элемент
    {
      Node = null;
      Input = Input.Trim();

      if (Input.Length != 0)
      {
        if (_WoLTestConst(Input[0], 't', 'T', 'F', 'f'))
        {
          bool Letter;
          _WoLSetValue(ref Input, out Letter);
          if (pars_Err != 0)
            return;
          Node = new WoLValueNode(Letter);
        }
        else
        if (Input[0] == '(')
        {
          _WoLTakeElements(ref Input, 1);
          WoLExpr(ref Input, out Node);
          if (pars_Err != 0)
            return;
          Input = Input.Trim();
          if ((Input.Length > 0) && (Input[0] != ')'))
          {
            pars_Err = 9; //Нет скобки
            return;
          }
          _WoLTakeElements(ref Input, 1);
        }
        else
          pars_Err = 6;
      }
      else
        pars_Err = 6; //?!?!?!?!
    }

    public void WoLExpr(ref string Input, out WoLNode Node)   //Выражение в скобках
    {
      Input = Input.Trim();
      Node = null;
      if (Input.Length != 0)
      {
        _WoLAnd(ref Input, out Node);
        if (pars_Err != 0)
          return;
        Input = Input.Trim();

        while ((Input.Length > 0) && (Input[0] == '|'))
        {
          _WoLTakeElements(ref Input, 1);
          if (Input.Length == 0)
          {
            pars_Err = 0;
            return;
          }
          WoLNode SecondNode;
          _WoLOr(ref Input, out SecondNode);
          if (pars_Err != 0)
            return;
          WoLNode FirstNode = Node;

          WoLOperations Op = WoLOperations.OR;
          Node = new WoLOperation(Op, FirstNode, SecondNode);
        }
      }
    }

    void _WoLAnd(ref string Input, out WoLNode Node)  //AND
    {
      Input = Input.Trim();
      Node = null;
      if (Input.Length != 0)
      {
        _WoLFact(ref Input, out Node);
        if (pars_Err != 0)
          return;
        while ((Input.Length != 0) && (Input[0] == '&'))
        {
          _WoLTakeElements(ref Input, 1);
          if (Input.Length == 0)
          {
            pars_Err = 6; //Нужен множитель
            return;
          }
          WoLNode SecondNode;
          _WoLFact(ref Input, out SecondNode);
          if (pars_Err != 0)
            return;
          WoLNode FirstNode = Node;
          WoLOperations Op = WoLOperations.AND;
          Node = new WoLOperation(Op, FirstNode, SecondNode);
        }
      }
      else
        pars_Err = 5;  //Нужно слагаемое
    }

    void _WoLOr(ref string Input, out WoLNode Node)
    {
      Node = null;
      Input = Input.Trim();
      string _Sign;
      if (Input.Length != 0)
      {
        _WoLFact(ref Input, out Node);
        while ((Input.Length != 0) &&(Input[0] == '|'))
        {
          _Sign = _WoLTakeElements(ref Input, 1);
          if (Input.Length == 0)
          {
            pars_Err = 5;
            return;
          }
          WoLNode SecondNode;
          _WoLAnd(ref Input, out SecondNode);
        }
      }
      else
        pars_Err = 4; //Нужно выражение
    }  //OR

    public void WoLSetCoords(WoLNode Node, int x, int y)
    {
      Node.x = x;
      Node.y = y;
      if ((Node is WoLOperation) && ((Node as WoLOperation).opnode_Left != null))
        WoLSetCoords((Node as WoLOperation).opnode_Left, x - 50, y + 50);
      if ((Node is WoLOperation) && ((Node as WoLOperation).opnode_Right != null))
        WoLSetCoords((Node as WoLOperation).opnode_Right, x + 50, y + 50);
    }

    public void WoLDraw()
    {
      _Graph = Graphics.FromImage(pars_Canvas);
      Color _Col = Color.FromArgb(255, 255, 255);
      _Graph.Clear(_Col);
      _Pen = Pens.Black;
      if (pars_Top != null)
        WoLDrawNode(pars_Top);
    }

    void WoLDrawNode(WoLNode Node)
    {
      int R = 17;
      if ((Node is WoLOperation) && ((Node as WoLOperation).opnode_Left != null))
        _Graph.DrawLine(_Pen, Node.x, Node.y, (Node as WoLOperation).opnode_Left.x, (Node as WoLOperation).opnode_Left.y);
      if ((Node is WoLOperation) && ((Node as WoLOperation).opnode_Right != null))
        _Graph.DrawLine(_Pen, Node.x, Node.y, (Node as WoLOperation).opnode_Right.x, (Node as WoLOperation).opnode_Right.y);

      _Brush = (SolidBrush)Brushes.LightYellow;
      _Graph.FillEllipse(_Brush, Node.x - R, Node.y - R, 2 * R, 2 * R);
      _Graph.DrawEllipse(_Pen, Node.x - R, Node.y - R, 2 * R, 2 * R);

      string Data = "";
      if (Node is WoLOperation)
        switch ((Node as WoLOperation).opnode_Operation)
        {
          case WoLOperations.OR:
            Data = "|";
            break;
          case WoLOperations.AND:
            Data = "&";
            break;
        }
      else
        Data = Node.Value.ToString();

      SizeF size = _Graph.MeasureString(Data[0].ToString(), _Font);
      _Graph.DrawString(Data[0].ToString(), _Font, Brushes.Black, Node.x - size.Width / 2, Node.y - size.Height / 2);
      if ((Node is WoLOperation) && ((Node as WoLOperation).opnode_Left != null))
        WoLDrawNode((Node as WoLOperation).opnode_Left);
      if ((Node is WoLOperation) && ((Node as WoLOperation).opnode_Right != null))
        WoLDrawNode((Node as WoLOperation).opnode_Right);
    }

    //Дальше писал не сам
    public WoLNode WoLFindNode(WoLNode Node, int x, int y) // поиск по координатам 
    {
      WoLNode result = null;
      if (Node == null)
        return result;
      if (((Node.x - x) * (Node.x - x) + (Node.y - y) * (Node.y - y)) < 100)
        result = Node;
      else
      {
        if ((Node is WoLOperation) && ((Node as WoLOperation).opnode_Left != null))
          result = WoLFindNode((Node as WoLOperation).opnode_Left, x, y);
        if ((result == null) && (Node is WoLOperation) && ((Node as WoLOperation).opnode_Right != null))
          result = WoLFindNode((Node as WoLOperation).opnode_Right, x, y);
      }
      return result;
    }

    public void WoLDelta(WoLNode Node, int dx, int dy)  // смещение поддерева
    {
      Node.x -= dx; Node.y -= dy;
      if ((Node is WoLOperation) && ((Node as WoLOperation).opnode_Left != null))
        WoLDelta((Node as WoLOperation).opnode_Left, dx, dy);
      if ((Node is WoLOperation) && ((Node as WoLOperation).opnode_Right != null))
        WoLDelta((Node as WoLOperation).opnode_Right, dx, dy);
    }

  }
}
