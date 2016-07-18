using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _17_6
{
  public partial class WoL : Form
  {
    WoLLogics _WoLTree;
    Graphics _Graph;
    bool _IsDrawing = false;
    public WoL()
    {
      InitializeComponent();
    }

    private void _ctrlBaton_Click(object sender, EventArgs e)
    {
      string Input = _ctrlTxb.Text;
      _WoLTree = new WoLLogics(_ctrlPanel.Width, _ctrlPanel.Height);
      _WoLTree.WoLExpr(ref Input, out _WoLTree.pars_Top);
      if (_WoLTree.pars_Err == 0)
      {
        _WoLTree.WoLSetCoords(_WoLTree.pars_Top, 220, 30);
        _ctrlLblAns.Text = bool.Parse(_WoLTree.pars_Top.Value.ToString()) == true ? "T" : "F";
        WoLDraw();
      }
      else
        MessageBox.Show("Ошибка в дереве: " + (WoLErrors)_WoLTree.pars_Err);
    }

    private void WoL_Load(object sender, EventArgs e)
    {
      _Graph = _ctrlPanel.CreateGraphics();
    }

    public void WoLDraw()
    {
      _WoLTree.WoLDraw();
      _Graph.DrawImage(_WoLTree.pars_Canvas, 0, 0);
    }

    private void _ctrlPanel_MouseDown(object sender, MouseEventArgs e)
    {
      _WoLTree.pars_SelNode = _WoLTree.WoLFindNode(_WoLTree.pars_Top, e.X, e.Y);
      _IsDrawing = _WoLTree.pars_SelNode != null;
    }

    private void _ctrlPanel_MouseUp(object sender, MouseEventArgs e)
    {
      _IsDrawing = false;
    }

    private void _ctrlPanel_MouseMove(object sender, MouseEventArgs e)
    {
      if (_IsDrawing)
      {
        _WoLTree.WoLDelta(_WoLTree.pars_SelNode, _WoLTree.pars_SelNode.x - e.X, _WoLTree.pars_SelNode.y - e.Y);
        WoLDraw();
      }
    }
  }
}
