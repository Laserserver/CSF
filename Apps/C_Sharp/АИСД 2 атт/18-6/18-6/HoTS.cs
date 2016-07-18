using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _18_6
{
    public partial class HoTS : Form
    {
        int[] Arr;
        Random _rnd = new Random();
        Graphics Graph;
        HoTSTree Tree;
        bool drawing = false;

        public HoTS()
        {
            InitializeComponent();
        }

        private void _ctrlBatonRand_Click(object sender, EventArgs e)
        {
            int leng = int.Parse(_ctrlTxbNumR.Text);
            Arr = new int[leng];
            Graph.Clear(Color.White);
            Tree = new HoTSTree(_ctrlPanel.Width, _ctrlPanel.Height);
            _ctrlNumsVis.Text = "";
            for (int i = 0; i < leng; i++)
            {
                Arr[i] = _rnd.Next(0, 100);
                _ctrlNumsVis.Text += Arr[i] + "\r\n";
            }
            
            for (int i = 0; i < leng; i++)
            {
                if (_ctrlNumsVis.Lines[i] != "")
                {
                    int k = Convert.ToInt32(_ctrlNumsVis.Lines[i]);
                    Tree.Insert(ref Tree.tree_Top, k, 200, 40);
                }
            }
            MyDraw();
        }

        private void _ctrlBaton_Click(object sender, EventArgs e)
        {
            if (_ctrlTxb.Text != "")
            MessageBox.Show(Tree.ReturnNum(int.Parse(_ctrlTxb.Text), 0).ToString());
        }

        private void _ctrlPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Tree.DeSelect(Tree.tree_Top);
            Tree.tree_NodeSelect = Tree.FindNode(Tree.tree_Top, e.X, e.Y);
            drawing = Tree.tree_NodeSelect != null;
            if (drawing)
                Tree.tree_NodeSelect.visit = true;
        }

        private void _ctrlPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
                Tree.Delta(Tree.tree_NodeSelect, Tree.tree_NodeSelect.x - e.X, Tree.tree_NodeSelect.y - e.Y);
            else
            {
                Tree.DeSelect(Tree.tree_Top);
                Tree.tree_NodeSelect = Tree.FindNode(Tree.tree_Top, e.X, e.Y);
                if (Tree.tree_NodeSelect != null)
                    Tree.tree_NodeSelect.visit = true;
            }
            MyDraw();
        }

        private void _ctrlPanel_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void HoTS_Load(object sender, EventArgs e)
        {
            Graph = _ctrlPanel.CreateGraphics();
            Tree = new HoTSTree(_ctrlPanel.Width, _ctrlPanel.Height);
        }

        public void MyDraw()
        {
            Tree.Draw();
            Graph.DrawImage(Tree.tree_Canvas, 0, 0);
        }
    }
}
