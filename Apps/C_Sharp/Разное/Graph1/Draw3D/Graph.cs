using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Collections;

namespace Draw3D
{
    // ============================= Стек ============================
    public class MyStack             
    {
        Node top;
        Node tail;

        public MyStack()                  // конструктор
        {
            top = null; tail = null;
        }

        public void Push(object data)     // положить в стек
        {
            top = new Node(top, data);
            if (top.next == null)
                tail = top;
        }

        public object Pop()               // взять из стека
        {
            if (top == null) throw new
                InvalidOperationException();
            object result = top.data;
            top = top.next;
            return result;
        }

        public bool isEmpty()             // проверка на пустоту
        {
            return top == null;
        }

        public class Node                 // узел
        {
            public Node next;
            public object data;
            public Node(Node next, object data)// конструктор
            {
                this.next = next;
                this.data = data;
            }
        }

        public void PushQueue(object inf) // положить в хвост очереди
        {
            Node p = new Node(null, inf);
            if (isEmpty())
            {
                top = p; tail = p;
            }
            else
            {
                tail.next = p; tail = p;
            }
        }

        public string StackToStr()
        {
            string result = ""; 
            while (!isEmpty())
                result += Convert.ToString(Pop())+" ";
            return result;
        }
    }

    // ============================= TEdge ============================
    public struct TEdge
    {
        public int A;            //
        public int numNode;      //
        public int x1c, x2c, yc; //
        public Color color;
        public bool select;
    }

    // ============================= TNode ============================
    public class TNode
    {
        public string name;  // 4+4*Name.Length
        public TEdge[] Edge; // 4+L2*(5*4) - ребра
        public bool visit;
        public bool check = true;
        public int x, y;   // 4+4
        public int numVisit;
        public Color color;
        public int dist, oldDist;
    }

    public struct Lib
    {
        public static Graph graph;
        public static int NumNode;
        public static int Num;
        public static MyStack myStack;
        public static MyStack path;
        public static int[] arr = new int[100];
    }

    // ============================= Graph ============================
    public partial class Graph
    {
        const int hx = 50, hy = 10; 
        public Bitmap bitmap;
        public TNode[] Nodes = new TNode[0];// узлы
        public static TNode SelectNode;
        public static TNode SelectNodeBeg;
        public byte typ_graph = 1;
        public bool visibleA = false;
        public int x1;
        public int x2;
        public int y1;
        public int y2;
        public int[,] A;  // матрица смежности
        Font MyFont;
        Color[] Colors = new Color[7] { Color.White, Color.Yellow, Color.Lime, Color.Gray, Color.Red, Color.Azure, Color.SandyBrown};

        int IsNode(int n1, int n2) // у узла n2 есть ребро на n1
        {
            int result = -1;
            int L = 0;
            if (Nodes[n2].Edge != null)
            {
                L=Nodes[n2].Edge.Length; 
            bool Ok = false; 
            int i = -1;
            while ((i<L-1) && !Ok)
                Ok = Nodes[n2].Edge[++i].numNode == n1;
            if (Ok)
                result = i;
            }
            return result;        
        }
        
        public void SetSim() // установить граф неориентированным
        { 
            int N = Nodes.Length;
            for (int i=0; i<N; i++)
            {
                int L = 0;
                if (Nodes[i].Edge != null)
                {
                    L = Nodes[i].Edge.Length;
                    for (int j = 0; j < L; j++)
                    {
                        int NumNode = Nodes[i].Edge[j].numNode;
                        int m = IsNode(i, Nodes[i].Edge[j].numNode);
                        if (m == -1)
                        {
                            int Le = 0;
                            if (Nodes[NumNode].Edge != null)
                            {
                                Le = Nodes[NumNode].Edge.Length;
                                Array.Resize<TEdge>(ref Nodes[NumNode].Edge, ++Le);
                                Nodes[NumNode].Edge[Le - 1].A = Nodes[i].Edge[j].A;
                                Nodes[NumNode].Edge[Le - 1].numNode = i;
                                Nodes[NumNode].Edge[Le - 1].x1c = Nodes[i].Edge[j].x2c;
                                Nodes[NumNode].Edge[Le - 1].x2c = Nodes[i].Edge[j].x1c;
                                Nodes[NumNode].Edge[Le - 1].yc = Nodes[i].Edge[j].yc;
                            }
                        }
                        else
                            if (Nodes[i].Edge[j].A != 0)
                                Nodes[NumNode].Edge[m].A = Nodes[i].Edge[j].A;
                    }
                }
            }
        }
        
        public void ChangeBitmap(int VW, int VH)
        {
            bitmap = new Bitmap(VW, VH);
            Draw(false);
        }

        public Graph(int VW, int VH) 
        {
            bitmap = new Bitmap(VW, VH);
            MyFont = new Font("Courier New", 10, FontStyle.Bold);
        }

        public int FindNumEdge(int i, int j) // i-ый узел имеет смежный j-ый узел
        {
            int result = -1;
            int L = Nodes[i].Edge.Length;
            bool ok = false;
            while ((result < L - 1) && !ok)
                ok = Nodes[i].Edge[++result].numNode == j;
            if (!ok)
                return -1;
            else
                return result;
        }

        public void SetA()
        {
            int N = Nodes.Length;
            A = new int[N,N];
            for ( int i=0; i<N; i++)
            for ( int j=0; j<N; j++) 
                A[i,j] = int.MaxValue;
            for (int i = 0; i < N; i++)
            {
                A[i, i] = 0;
                int LL = 0;
                if (Nodes[i].Edge != null)
                {
                    LL = Nodes[i].Edge.Length;
                    for (int j = 0; j < LL; j++)
                        A[i, Nodes[i].Edge[j].numNode] = Nodes[i].Edge[j].A;
                }
            }
        }

        public void Clear() // очистить граф 
        {
            int N = Nodes.Length;
            for (int i = 0; i < N; i++ )
                Array.Resize<TEdge>(ref Nodes[i].Edge, 0);
            Array.Resize<TNode>(ref Nodes, 0);
        }

        public void AddNode(int x, int y) // добавить узел 
        { 
            int N = Nodes.Length;
            Array.Resize<TNode>(ref Nodes, ++N);
            Nodes[N-1] = new TNode();
            Nodes[N-1].name = "Node "+Convert.ToString(N-1);
            Nodes[N-1].x = x; 
            Nodes[N-1].y = y;
            Nodes[N - 1].color = Color.White;
        }
        
        public void AddEdge()  // добавить ребро
        {
            int n = -1; bool ok = false;
            int Ln = Nodes.Length;
            while ((n < Ln - 1) && !ok)
                ok = Nodes[++n] == SelectNode;

            int L = 0;
            if (SelectNodeBeg.Edge != null) 
                L = SelectNodeBeg.Edge.Length;
            Array.Resize<TEdge>(ref SelectNodeBeg.Edge, ++L);
            SelectNodeBeg.Edge[L - 1].numNode = n;
            SelectNodeBeg.Edge[L - 1].A = 0;
            SelectNodeBeg.Edge[L - 1].x1c = x1 - SelectNodeBeg.x;
            SelectNodeBeg.Edge[L - 1].x2c = x2 - SelectNode.x;
            SelectNodeBeg.Edge[L - 1].yc = (SelectNode.y + SelectNodeBeg.y) / 2;
            SelectNodeBeg.Edge[L - 1].color = Color.Silver;
        }
        
        public TNode FindNode(int x, int y) // найти узел
        {
            int N = Nodes.Length; 
            int i = -1; 
            bool Ok = false;
            while ((i<N-1) && !Ok)
            {
                i++;
                Ok = (Nodes[i].x-hx<=x) && (x<=Nodes[i].x+hx) && 
                     (Nodes[i].y-hy<=y) && (y<=Nodes[i].y+hy);
            }
            if (Ok) return Nodes[i]; else return null;
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
                            switch (typ_graph)
                            {
                                case 0:
                                    if (Nodes[i].Edge[j].select)
                                        MyPen = Pens.Red;
                                    else
                                        MyPen = new Pen( Nodes[i].Edge[j].color); // Pens.Black;
                                    int a1 = Nodes[i].x;
                                    int b1 = Nodes[i].y;
                                    int a2 = Nodes[Nodes[i].Edge[j].numNode].x;
                                    int b2 = Nodes[Nodes[i].Edge[j].numNode].y;
                                    g.DrawLine(MyPen, new Point(a1, b1), new Point(a2, b2));

                                    s = Convert.ToString(Nodes[i].Edge[j].A);  
                                    SizeF size = g.MeasureString(s,MyFont);
                                    //g.DrawRectangle(MyPen, (a1 + a2) / 2 - size.Width / 2, (b1 + b2) / 2 - size.Height / 2, size.Width, size.Height);
                                    if (Lib.graph.visibleA)
                                    {
                                        g.FillRectangle(Brushes.White, (a1 + a2) / 2 - size.Width / 2, (b1 + b2) / 2 - size.Height / 2, size.Width, size.Height);
                                        g.DrawString(s, MyFont, Brushes.Black,
                                            (a1 + a2) / 2 - size.Width / 2,
                                            (b1 + b2) / 2 - size.Height / 2);
                                    }
                                break;
                                case 1:
                                    a1 = Nodes[i].x + Nodes[i].Edge[j].x1c;
                                    b1 = Nodes[i].y;
                                    a2 = Nodes[Nodes[i].Edge[j].numNode].x + Nodes[i].Edge[j].x2c;
                                    b2 = Nodes[Nodes[i].Edge[j].numNode].y;

                                    if (Nodes[i].Edge[j].select)
                                        MyPen = Pens.Red;
                                    else
                                        MyPen = new Pen( Nodes[i].Edge[j].color); // Pens.Black;

                                    g.DrawLine(MyPen, new Point(a1, b1 + hy), new Point(a1, (b1 + b2) / 2));
                                    g.DrawLine(MyPen, new Point(a1, (b1 + b2) / 2), new Point(a2, (b1 + b2) / 2));
                                    g.DrawLine(MyPen, new Point(a2, (b1 + b2) / 2), new Point(a2, b2 - hy));

                                    s = Convert.ToString(Nodes[i].Edge[j].A);  
                                    size = g.MeasureString(s,MyFont);
                                    
                                    //g.DrawRectangle(MyPen, (a1 + a2) / 2 - size.Width / 2, (b1 + b2) / 2 - size.Height / 2, size.Width, size.Height);
                                    if (Lib.graph.visibleA)
                                    {
                                        g.FillRectangle(Brushes.White, (a1 + a2) / 2 - size.Width / 2, (b1 + b2) / 2 - size.Height / 2, size.Width, size.Height);
                                        g.DrawString(s, MyFont, Brushes.Black,
                                            (a1 + a2) / 2 - size.Width / 2,
                                            (b1 + b2) / 2 - size.Height / 2);
                                    }
                                    if (b1<b2)
                                        g.FillEllipse(Brushes.Black,a2-3,b2-hy-3-3,6,6);
                                    else
                                        g.FillEllipse(Brushes.Black, a2 - 3, b2 + hy - 3 + 3, 6, 6);
                                break;
                            }
                        }
                    }
                }
                
                // Nodes
                for (int i=0; i<N; i++)
                {
                    Nodes[i].color = Color.Yellow;
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
                    if (!Nodes[i].check)
                    {
                        MyBrush.Color = Color.Green;
                        Nodes[i].color = Color.Green;
                    }
                    switch (typ_graph)
                    { 
                        case 0:
                            MyBrush.Color = Nodes[i].color;
                            g.FillEllipse(MyBrush, Nodes[i].x - hy, Nodes[i].y - hy, 2 * hy, 2 * hy);
                            //MyPen.Color = Color.Black;
                            g.DrawEllipse(Pens.Black /*MyPen*/, Nodes[i].x - hy, Nodes[i].y - hy, 2 * hy, 2 * hy);
                            s = Convert.ToString(i);  
                            SizeF size = g.MeasureString(s,MyFont);
                            g.DrawString(s, MyFont, Brushes.Black, 
                                Nodes[i].x - size.Width/2, 
                                Nodes[i].y - size.Height/2);
                            break;
                        case 1:
                            g.FillRectangle(MyBrush, Nodes[i].x - hx, Nodes[i].y - hy, 2 * hx, 2 * hy);
                            g.DrawRectangle(MyPen, Nodes[i].x - hx, Nodes[i].y - hy, 2 * hx, 2 * hy);
                            s = Convert.ToString(Nodes[i].name); //+"("+Convert.ToString(Nodes[i].numVisit)+")";  
                            size = g.MeasureString(s,MyFont);
                            g.DrawString(s, MyFont, Brushes.Black, 
                                Nodes[i].x - size.Width/2, 
                                Nodes[i].y - size.Height/2);
                            break;
                    }
                }
                if (fl)
                    g.DrawLine(MyPen, new Point(x1,y1), new Point(x2,y2));
                //MyFont.Dispose();
            }
        }
        
        protected int LengthFile()  // вычислить размер файла
        {
            int n = 4;
            int L1 = Nodes.Length;
            for (int i=0; i<=L1-1; i++)
            {
                n += 16+4*Nodes[i].name.Length;
                int L2=0; 
                if (Nodes[i].Edge != null)
                    L2 = Nodes[i].Edge.Length;
                n += L2 * 20;
            }
            return n;
        }

        byte[] byData;
        int ofs = 0;

        protected void IntInData(int k)
        {
            byte[] byByte;
            byByte = BitConverter.GetBytes(k);
            byByte.CopyTo(byData, ofs); ofs += 4;
        }

        protected void StrInData(string s)
        {
            byte[] byByte;
            int L = s.Length; IntInData(L);
            char[] charData = s.ToCharArray();
            byByte = new byte[4 * charData.Length];
            Encoder e = Encoding.UTF32.GetEncoder();
            e.GetBytes(charData, 0, charData.Length, byByte, 0, true);
            byByte.CopyTo(byData, ofs); ofs += 4 * L;
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
                    IntInData(Nodes[i].Edge[j].A);
                    IntInData(Nodes[i].Edge[j].x1c);
                    IntInData(Nodes[i].Edge[j].x2c);
                    IntInData(Nodes[i].Edge[j].yc);
                    IntInData(Nodes[i].Edge[j].numNode);
                }
            }
            aFile.Write(byData, 0, N);
            aFile.Close();
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
                    for (int j = 0; j <= L2 - 1; j++ )
                    {
                        Nodes[i].Edge[j].A = DataInInt(); 
                        Nodes[i].Edge[j].x1c = DataInInt();
                        Nodes[i].Edge[j].x2c = DataInInt();
                        Nodes[i].Edge[j].yc = DataInInt(); 
                        Nodes[i].Edge[j].numNode = DataInInt();
                        Nodes[i].Edge[j].color = Color.Silver;
                    }
            }

            aFile.Close();
        }
        
        int DistLine(int u, int v, int x1, int y1, int x2, int y2)  // расстояние до линии
        {

            int A = y2 - y1; 
            int B = -x2 + x1; 
            int C = -x1*A-y1*B;
            int D = A*A+B*B;
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
                        int a2 = Nodes[Nodes[i].Edge[j].numNode].x;
                        int b2 = Nodes[Nodes[i].Edge[j].numNode].y;
                        int u1 = Math.Min(a1,a2);
                        int u2 = Math.Max(a1, a2);
                        int v1 = Math.Min(b1, b2);
                        int v2 = Math.Max(b1, b2);
                        int Eps = 4;
                        ok=(u1-Eps<=x) && (x<=u2+Eps) && (v1-Eps<=y) && (y<=v2+Eps);
                        ok=(DistLine(x,y,a1,b1,a2,b2)<=Eps) && ok;
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
            for (int i = NumEdge; i<L-2; i++)
                Nodes[NumNode].Edge[i] = Nodes[NumNode].Edge[i+1];
            Array.Resize<TEdge>(ref Nodes[NumNode].Edge,L-1);
        }
    }
}
