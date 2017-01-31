using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Draw3D
{
    public partial class FormGraph : Form
    {
        public static byte flTools = 0;
        bool drawing = false;
        Graphics g;
        string FileName = "";

        public FormGraph()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Dat (*.dat)|*.dat|All Files (*.*)|*.*";
            openFileDialog1.Filter = "Dat (*.dat)|*.dat|All Files (*.*)|*.*";
            Lib.graph = new Graph(ClientRectangle.Width, ClientRectangle.Height);
            //displayGraphics = CreateGraphics();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            //Lib.graph = new Graph(ClientRectangle.Width, ClientRectangle.Height);
        }

        public void MyDraw(bool fl)
        {
            Lib.graph.Draw(fl);
            g.DrawImage(Lib.graph.bitmap, ClientRectangle);
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            MyDraw(false);
        }

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            switch (flTools)
            {
                case 0:
                    Graph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
                    drawing = Graph.SelectNode != null;
                    break;
                case 1:
                    Lib.graph.AddNode(e.X, e.Y);
                    MyDraw(false);
                    break;
                case 2:
                    Graph.SelectNodeBeg = Lib.graph.FindNode(e.X, e.Y);
                    drawing = Graph.SelectNodeBeg != null;
                    Lib.graph.x1 = e.X; Lib.graph.y1 = e.Y;
                    Lib.graph.x2 = e.X; Lib.graph.y2 = e.Y;
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
            }
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                switch (flTools)
                {
                    case 0:
                        Graph.SelectNode.x = e.X;
                        Graph.SelectNode.y = e.Y;
                        MyDraw(false);
                        break;
                    case 2:
                        Lib.graph.x2 = e.X; Lib.graph.y2 = e.Y;
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
                        Graph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
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

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
            switch (flTools)
            {
                case 2:
                    Graph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
                    if (Graph.SelectNode != null)
                    {
                        Lib.graph.AddEdge();
                        MyDraw(false);
                    }
                    break;
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (Lib.graph != null)
                Lib.graph.ChangeBitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
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
            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
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

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FileName = saveFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileName = saveFileDialog1.FileName;
                Lib.graph.Save(FileName);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void propertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Graph.SelectNode != null) && (Program.formProperty.ShowDialog() == DialogResult.OK));
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void матрицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.formMatrix.ShowDialog() == DialogResult.OK);
        }

        private void поискВГлубинуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.formMyDialog.Text = "Поиск в глубину";
            if (Program.formMyDialog.ShowDialog() == DialogResult.OK)
            {
                int n = Lib.graph.DepthSearch(0,Lib.graph.Nodes[Lib.NumNode].name);
                //Caption:=IntToStr(n);
                MyDraw(false);
            }

        }

        private void поискВГлубинустекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.formMyDialog.Text = "Поиск в глубину (стек)";
            if (Program.formMyDialog.ShowDialog() == DialogResult.OK)
            {
                int n = Lib.graph.DepthSearchStack(0, Lib.graph.Nodes[Lib.NumNode].name);
                //Caption:=IntToStr(n);
                Text = "Path: "+ Lib.myStack.StackToStr();
                MyDraw(false);
            }
        }

        private void поискВШиринуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.formMyDialog.Text = "Поиск в глубину (стек)";
            if (Program.formMyDialog.ShowDialog() == DialogResult.OK)
            {
                int n = Lib.graph.BreadthSearch(0, Lib.graph.Nodes[Lib.NumNode].name);
                //Caption:=IntToStr(n);
                Text = "Path: " + Lib.myStack.StackToStr();
                MyDraw(false);
            }
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void построениеДереваостовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lib.graph.SetTreeDepth(0);
            MyDraw(false);
        }

        private void эйлеровыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lib.graph.PathEuler();
            MyDraw(false);
            MessageBox.Show("Path: " + Graph.StackToStr(Lib.path)); // ShowMessage('Path: '+StackToStr(Path));
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lib.graph.Clear();
            MyDraw(false);
        }

        private void гамильтоновыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.formListBox.fl_proc = 0;
            if (Program.formListBox.ShowDialog() == DialogResult.OK) ;
        }

        private void общийАлгоритмToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.formListBox.fl_proc = 1;
            if (Program.formListBox.ShowDialog() == DialogResult.OK) ;
        }

        private void фордаБелманаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.formListBox.fl_proc = 2;
            if (Program.formListBox.ShowDialog() == DialogResult.OK) ;
        }

        private void дейкстрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = Lib.graph.Dijkst(0,7);
            MyDraw(false);
            MessageBox.Show("Path: " + Graph.StackToStr(Lib.myStack)+"; MinDist = "+Convert.ToString(n)); 
        }

        private void переборныйАлгоритмToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int k = Lib.graph.SetColor();
            MyDraw(false);
            MessageBox.Show("Хроматическое число = "+Convert.ToString(k)); 
        }

        private void топологическаяСортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lib.graph.TopSort();
            MyDraw(false);
            MessageBox.Show("Path: "+Graph.StackToStr(Lib.myStack)); 
        }

        private void минимальныйОстовКраскалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lib.graph.Craskal();
            MyDraw(false);
        }

        private void выделениеСвязностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lib.graph.SetEdge(0);
            MyDraw(false);
            MessageBox.Show("Path: " + Graph.StackToStr(Lib.myStack));
        }

        private void PathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            if(form1.ShowDialog() == DialogResult.OK)
            {}
        }

        private void tttToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        /*private void FormGraph_DoubleClick(object sender, MouseEventArgs e)
        {
            Graph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
            if (Graph.SelectNode != null)
            {
                Graph.SelectNode.color = Color.Black;
                MyDraw(false);
            }
        }
         */

    }
}
