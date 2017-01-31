using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Draw3D
{
    public partial class Graph
    {
        List<int> nodes;
        // ================= Алгоритмы ==================================
        void ClearVisit()
        {
            int N = Nodes.Length; Lib.Num = 0;
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

        void VisitTrue(int n)  // отметить посещенный
        {
            Nodes[n].visit = true;
            Lib.Num++;
            Nodes[n].numVisit = Lib.Num;
        }

        void SetDoubleRed(int m, int n)    // закрасить двойственную дугу
        {
            int L = Nodes[m].Edge.Length; bool ok = false; int i = -1;
            while ((i < L - 1) && !ok)
                ok = Nodes[m].Edge[++i].numNode == n;
            if (ok)
                Nodes[m].Edge[i].color = Color.Black;
        }
        void SetDoubleSilver(int m, int n)    // закрасить двойственную дугу
        {
            int L = Nodes[m].Edge.Length; bool ok = false; int i = -1;
            while ((i < L - 1) && !ok)
                ok = Nodes[m].Edge[++i].numNode == n;
            if (ok)
                Nodes[m].Edge[i].color = Color.Silver;
        }
        void SetEdgeSilver(int v, int i)    // закрасить дугу
        {
            Nodes[v].Edge[i].color = Color.Silver;
            SetDoubleSilver(Nodes[v].Edge[i].numNode, v);
        }
        void SetEdgeBlack(int v, int i)    // закрасить дугу
        {
            Nodes[v].Edge[i].color = Color.Black;
            SetDoubleRed(Nodes[v].Edge[i].numNode, v);
        }

        public static string StackToStr(MyStack path)
        {
            string result = "";
            while (!path.isEmpty())
            {
                int i = (int)path.Pop();
                result = result + Convert.ToString(i) + " ";
            }
            return result;
        }

        int FindDepth(int n, string nameNode)
        {
            int result = -1;
            VisitTrue(n);                  // отметить посещенный
            if (Nodes[n].name == nameNode)
                result = n;
            else
            {
                int L = 0;
                if (Nodes[n].Edge != null)
                {
                    L = Nodes[n].Edge.Length;
                    int i = -1; result = -1;
                    while ((i < L - 1) & (result == -1))
                    {
                        int m = Nodes[n].Edge[++i].numNode;
                        if (!Nodes[m].visit)
                        {
                            SetEdgeBlack(n, i); // закрасить дугу
                            result = FindDepth(m, nameNode);
                        }
                    }
                }
            }
            return result;
        }

        // Поиск в глубину
        public int DepthSearch(int n, string nameNode)
        {
            ClearVisit();
            int result = FindDepth(n, nameNode);
            return result;
        }

        int FindNotVisit(int t, out int i)
        {
            // найти непосещенный узел
            int LL = 0; int result = -1; i = -1;
            if (Nodes[t].Edge != null)
            {
                LL = Nodes[t].Edge.Length;
                bool Ok = false;
                while ((i < LL - 1) && !Ok)
                    Ok = !Nodes[Nodes[t].Edge[++i].numNode].visit;
                if (Ok)
                    result = Nodes[t].Edge[i].numNode;
            }
            return result;
        }

        public int DepthSearchStack(int n, string nameNode)
        {
            Lib.myStack = new MyStack();
            ClearVisit();
            int result = -1;
            VisitTrue(n);                     // отметить посещенный
            do
            {
                if (Nodes[n].name == nameNode)
                    result = n;               // узел найден
                else
                {
                    int i;
                    int m = FindNotVisit(n, out i); // найти непосещенный узел
                    if (m != -1)
                    {
                        SetEdgeBlack(n, i);   // закрасить дугу
                        Lib.myStack.Push(n);  // поместить в стек
                        VisitTrue(m);         // отметить посещенный
                        n = m;
                    }
                    else
                        n = (int)Lib.myStack.Pop(); // взять из стека
                }
            }
            while (!(Lib.myStack.isEmpty() || (result != -1)));
            return result;
        }

        public int BreadthSearch(int v, string nameNode)
        // поиск в ширину
        {
            ClearVisit();
            Lib.myStack = new MyStack();
            int result = -1;
            VisitTrue(v);                    // отметить посещенный
            Lib.myStack.PushQueue(v);        // поместить в очередь
            while (!Lib.myStack.isEmpty() && (result == -1))
            {
                v = (int)Lib.myStack.Pop();    // взять из очереди
                if (Nodes[v].Edge != null)
                {
                    int L = Nodes[v].Edge.Length;
                    int i = -1;
                    while ((i < L - 1) && (result == -1))
                    {
                        int m = Nodes[v].Edge[++i].numNode;
                        if (!Nodes[m].visit)     // еще не посещали
                        {
                            SetEdgeBlack(v, i);  // закрасить дугу
                            Lib.myStack.PushQueue(m); // поместить в очередь
                            if (Nodes[m].name == nameNode)
                                result = m;
                            VisitTrue(m);        // отметить посещенный
                        }
                    }
                }
            }
            return result;
        }

        void FindDepth(int n)
        {
            VisitTrue(n);              // отметить посещенный
            int LL = 0;
            if (Nodes[n].Edge != null)
            {
                LL = Nodes[n].Edge.Length; int i = -1;
                while (i < LL - 1)
                {
                    int m = Nodes[n].Edge[++i].numNode;
                    if (!Nodes[m].visit)
                    {
                        SetEdgeBlack(n, i); // закрасить ребро
                        FindDepth(m);
                    }
                }
            }
        }

        public void SetTreeDepth(int n)
        // построение стягивающего дерева (остов) - поиск в глубину
        {
            ClearVisit();
            FindDepth(n);
        }

        int FindEdge(int v)
        {
            int LL = 0;
            if (Nodes[v].Edge != null)
            {
                LL = Nodes[v].Edge.Length;
                bool Ok = false; int i = -1;
                while ((i < LL - 1) & !Ok)
                    Ok = Nodes[v].Edge[++i].color != Color.Black;
                if (Ok) return i; else return -1;
            }
            else
                return -1;
        }

        void MethodPath(int one, int two, ref List<string> qwerty, string str, bool flag)
        {
            if (flag && two == one)
            {
                
                qwerty.Add(str);
                return;
            }
            //Выберем следующий узел
            if (Nodes[two].Edge != null)//проверка на наличие связей
            {
                for (int i = 0; i < Nodes[two].Edge.Length; i++)
                {
                    flag = true;
                    bool ok = true, ok1 = true;
                    if (Nodes[Nodes[two].Edge[i].numNode].color == Color.Green)
                        ok = false;
                    if (Nodes[two].Edge[i].color == Color.Black)
                        ok1 = false;
                    if (ok && ok1)
                    {
                        SetEdgeBlack(two, i);
                        MethodPath(one, Nodes[two].Edge[i].numNode, ref qwerty, str + Nodes[two].Edge[i].numNode + ' ', flag);
                        SetEdgeSilver(two, i);
                    }
                }
            }
        }
        public List<string> Core()
        {
            List<string> lst = new List<string>();
            for (int i = 0; i < Nodes.Length; i++)
            {
                bool ok1 = false;
                bool ok = true;
                if (Nodes[i].color == Color.Green)
                    ok = false;
                if (ok)
                {
                    lst.Add("Krugi nachinaushiesa s vershiny " + i);
                    string str = Convert.ToString(i) + " ";
                    MethodPath(i, i, ref lst, str, ok1);
                }
            }
            return lst;
        }
        void Writer(List<string> lst)
        {
            FileStream fileput = new FileStream("QNewF.txt", FileMode.Create);
            using (BinaryWriter put = new BinaryWriter(fileput))
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    put.Write(lst[i]);
                }
                put.Close();
            }
            fileput.Close();
        }
        public void PathEuler()
        {
            ClearVisit();
            Lib.myStack = new MyStack();
            Lib.path = new MyStack();
            int v = 0;
            Lib.myStack.Push(v);             // положить в стек
            while (!Lib.myStack.isEmpty())
            {
                int i = FindEdge(v);
                if (i != -1)
                {
                    int u = Nodes[v].Edge[i].numNode;
                    Lib.myStack.Push(u);    // положить в стек
                    SetEdgeBlack(v, i);     // закрасить ребра
                    v = u;
                }
                else
                {
                    v = (int)Lib.myStack.Pop();// взять из стека
                    Lib.path.Push(v);          // положить в стек
                }
            }
        }

        string SetPath()
        {
            string result = "";
            for (int j = 1; j < Nodes.Length; j++)
                result += Convert.ToString(Lib.arr[j]) + " ";
            return result;
        }

        void Gamilt(int k, ref System.Windows.Forms.ListBox.ObjectCollection Items)
        {
            int y = Lib.arr[k - 1];
            int LL = 0;
            if (Nodes[y].Edge != null)
            {
                LL = Nodes[y].Edge.Length;
                for (int i = 0; i < LL; i++)
                {
                    int u = Nodes[y].Edge[i].numNode;
                    if (k == Nodes.Length + 1)
                        Items.Add(SetPath()); // вывести путь
                    else
                        if (!Nodes[u].visit)
                        {
                            Lib.arr[k] = u;
                            Nodes[u].visit = true; // отметить посещенный
                            Gamilt(k + 1, ref Items);
                            Nodes[u].visit = false;// отметить посещенный
                        }
                }
            }
        }

        public void Gamilton(System.Windows.Forms.ListBox.ObjectCollection Items)
        {
            ClearVisit();
            int N = Nodes.Length; int v0 = 0;
            Lib.arr[1] = v0;
            VisitTrue(v0);                    // отметить посещенный
            Gamilt(2, ref Items);
        }

        void SetMatr()
        {
            int N = Nodes.Length;
            A = new int[N, N];
            for (int i = 0; i <= N - 1; i++)
                for (int j = 0; j <= N - 1; j++)
                    A[i, j] = 0xFFFFF; // int.MaxValue; 
            for (int i = 0; i <= N - 1; i++)
            {
                A[i, i] = 0;
                int LL = 0;
                if (Nodes[i].Edge != null)
                {
                    LL = Nodes[i].Edge.Length;
                    for (int j = 0; j <= LL - 1; j++)
                        A[i, Nodes[i].Edge[j].numNode] = Nodes[i].Edge[j].A;
                }
            }
        }

        public void MinDist0(int s)
        {
            SetMatr();
            int N = Nodes.Length;
            for (int v = 0; v <= N - 1; v++)
                Nodes[v].dist = A[s, v];
            Nodes[s].dist = 0;
            for (int k = 0; k <= N - 1; k++)
                for (int v = 0; v <= N - 1; v++)
                    if (v != s)
                        for (int u = 0; u <= N - 1; u++)
                            Nodes[v].dist = Math.Min(Nodes[v].dist, Nodes[u].dist + A[u, v]);
        }

        public void Bellmann(int from)
        // было ли на этом шаге изменено значение кратчайшего
        // пути хоть до одной вершины
        {
            int N = Nodes.Length;
            bool Ok;
            for (int i = 0; i <= N - 1; i++)
                if (i == from)
                    Nodes[i].dist = 0;
                else
                    Nodes[i].dist = 0xFFFFF;
            do
            {
                // сохраняем значение кратчайшего пути на предыдущем шаге
                for (int i = 0; i <= N - 1; i++)
                    Nodes[i].oldDist = Nodes[i].dist;
                Ok = false;
                for (int i = 0; i <= N - 1; i++)
                {
                    int LL = 0;
                    if (Nodes[i].Edge != null)
                    {
                        LL = Nodes[i].Edge.Length;
                        if (LL > 0)
                            // просматриваем ребра, входящие в текущую вершину
                            for (int j = 0; j <= LL - 1; j++)
                                if (Nodes[i].Edge[j].A + Nodes[Nodes[i].Edge[j].numNode].oldDist <
                                    Nodes[i].dist) // если нашли путь короче
                                {
                                    Nodes[i].dist =
                                        Nodes[i].Edge[j].A + Nodes[Nodes[i].Edge[j].numNode].oldDist; // исправляем Dist
                                    Ok = true;                          // и ставим флаг
                                }
                    }
                }
            }
            while (Ok); // если очередная итерация прошла неуспешно
        }

        int FindMinDist(int p)
        {
            int MinDist = 0xFFFFF; // int.MaxValue;
            int result = 0;
            int N = Nodes.Length;
            for (int i = 0; i <= N - 1; i++)
            {
                if (!Nodes[i].visit && (i != p))
                {
                    Nodes[i].dist = Math.Min(Nodes[i].dist, Nodes[p].dist + A[p, i]);
                    if (Nodes[i].dist < MinDist)
                    {
                        MinDist = Nodes[i].dist;
                        result = i;
                    }
                }
            }
            return result;
        }

        void PathToStack(int s, int p)
        {
            Lib.myStack = new MyStack();
            int N = Nodes.Length;
            while (p != s)
            {
                Lib.myStack.Push(p); // положить в стек
                int i = -1; bool Ok = false;
                while ((i < N - 1) & !Ok)
                    Ok = (++i != p) && (Nodes[p].dist == Nodes[i].dist + A[i, p]);
                p = i;
            }
        }

        public int Dijkst(int s, int t)
        {
            int result;
            ClearVisit();
            SetMatr();
            // Инициализация
            int N = Nodes.Length;
            for (int i = 0; i <= N - 1; i++)
                Nodes[i].dist = 0xFFFFF; // int.MaxValue;
            Nodes[s].dist = 0; VisitTrue(s);
            int p = s;
            do
            {
                p = FindMinDist(p); // обновление и найти
                VisitTrue(p);       // пометка = false
            }
            while (p != t);
            result = Nodes[p].dist;
            PathToStack(s, p);

            return result;
        }
        public int[,] Nechot()
        {
            int count = 0; nodes = new List<int>();
            for (int i = 0; i < Nodes.Length; i++)
            {
                if (Nodes[i].Edge.Length % 2 == 1)
                {
                    nodes.Add(i);
                    Nodes[i].color = Color.Green;
                    ++count;
                }
            }
            int[,] examp = new int[count, count];
            return examp;
        }
        public int[,] DijkstraMoi(int[,] examp)
        {
            int qi = 0, qj = 0;
            for (int i = 0; i < Nodes.Length; i++)
            {
                for (int j = 0; j < Nodes.Length; j++)
                {
                    if (Nodes[i].color == Color.Green && Nodes[j].color == Color.Green)
                    {
                        examp[qi, qj] = Dijkst(i, j);
                    }
                    if (i == j)
                        examp[qi, qj] = 2147483646;
                    qj++;
                }
                qi++;
            }
            return examp;
        }
        void SortNumEdge(ref int[] V)
        {
            int N = Nodes.Length;
            int L1, L2;
            for (int i = 0; i <= N - 1; i++) V[i] = i;
            for (int i = 0; i <= N - 2; i++)
                for (int j = N - 1; j >= i + 1; j--)
                {
                    if (Nodes[V[j]].Edge != null)
                        L1 = Nodes[V[j]].Edge.Length;
                    else
                        L1 = 0;
                    if (Nodes[V[j - 1]].Edge != null)
                        L2 = Nodes[V[j - 1]].Edge.Length;
                    else
                        L2 = 0;

                    if (L1 < L2)
                    {
                        int t = V[j]; V[j] = V[j - 1]; V[j - 1] = t;
                    }
                }
        }

        bool IsBorder(int i, int k)
        {
            int j = -1; bool result = false;
            int N = Nodes.Length;
            while ((j < N - 1) & !result)
                result = Nodes[++j].visit & (Nodes[j].color == Colors[k]) & (A[i, j] != 0xFFFFF);
            return result;
        }

        public int SetColor()
        // переборный алгоритм закраски
        {
            int N = Nodes.Length;
            int[] V = new int[N];
            for (int i = 0; i <= N - 1; i++)
                V[i] = i;
            SortNumEdge(ref V);
            ClearVisit(); SetMatr();
            bool Ok;
            int k = 0;
            do
            {
                Ok = false; int i = -1;
                while ((i < N - 1) & !Ok)
                    Ok = !Nodes[V[++i]].visit;
                if (Ok)                           // найдена неокрашенная
                {
                    VisitTrue(V[i]);              // окрасили
                    Nodes[V[i]].color = Colors[k];

                    for (i = 0; i <= N - 1; i++)
                        if (!Nodes[V[i]].visit &  // не окрашена
                            !IsBorder(V[i], k))   // нет соседей цвета k
                        {
                            VisitTrue(V[i]);      // окрашено
                            Nodes[V[i]].color = Colors[k];
                        }
                    k++;
                }
            }
            while (Ok);
            return k;
        }

        struct TEdges          // временная структура для ребра
        {
            public int n1;     // № первой вершины
            public int n2;     // № второй вершины
            public int A;      // вес ребра
        }
        TEdges[] Edges;

        void SetColorEdge()
        {
            while (!Lib.myStack.isEmpty())
            {
                int t = (int)Lib.myStack.Pop(); // взять из стека № ребра
                int N = Nodes.Length;
                for (int i = 0; i <= N - 1; i++)
                {
                    int LL = 0;
                    if (Nodes[i].Edge != null)
                    {
                        LL = Nodes[i].Edge.Length;
                        for (int j = 0; j <= LL - 1; j++)
                            if (((i == Edges[t].n1) & (Nodes[i].Edge[j].numNode == Edges[t].n2)) |
                                ((i == Edges[t].n2) & (Nodes[i].Edge[j].numNode == Edges[t].n1)))
                                SetEdgeBlack(i, j); // закрасить ребро
                    }
                }
            }
        }

        bool Find(int m1, int m2)
        {
            bool Result = false;
            if (Edges == null)
                return Result;
            int N = Edges.Length; int i = -1;
            while ((i < N - 1) && !Result)
                Result = ((Edges[++i].n1 == m1) & (Edges[i].n2 == m2)) | ((Edges[i].n1 == m2) & (Edges[i].n2 == m1));
            return Result;
        }

        public void Craskal()
        {
            ClearVisit();
            Lib.myStack = new MyStack();
            int N = Nodes.Length; int m = 0;
            // формируем массив всех ребер
            for (int i = 0; i <= N - 1; i++)
            {
                int L = 0;
                if (Nodes[i].Edge != null)
                {
                    L = Nodes[i].Edge.Length;
                    for (int j = 0; j <= L - 1; j++)
                        if (!Find(i, Nodes[i].Edge[j].numNode))
                        {
                            Array.Resize<TEdges>(ref Edges, ++m);
                            Edges[m - 1].n1 = i;
                            Edges[m - 1].n2 = Nodes[i].Edge[j].numNode;
                            Edges[m - 1].A = Nodes[i].Edge[j].A;
                        }
                }
            }
            TEdges h = new TEdges();

            // Сортируем ребра графа по возрастанию весов
            for (int i = 0; i <= m - 2; i++)
                for (int j = m - 1; j >= i + 1; j--)
                    if (Edges[j].A < Edges[j - 1].A)
                    {
                        h = Edges[j]; Edges[j] = Edges[j - 1]; Edges[j - 1] = h;
                    }

            int[] Link = new int[N];
            // Вначале все ребра в разных компонентах связности
            for (int i = 0; i <= N - 1; i++) Link[i] = i;

            int numEdge = 0; // номер ребра
            int q = N - 1;       // номер вершины
            while ((numEdge <= m - 1) & (q != 0))
            {
                // если вершины в разных компонентах связности
                if (Link[Edges[numEdge].n1] != Link[Edges[numEdge].n2])
                {
                    int t = Edges[numEdge].n2;
                    Lib.myStack.Push(numEdge);   // поместить в стек номер ребра
                    for (int j = 0; j <= N - 1; j++)
                        if (Link[j] == t)
                            Link[j] = Link[Edges[numEdge].n1]; // в один компонент связности
                    q--;
                }
                numEdge++;
            }
            SetColorEdge(); // закраска ребер
        }

        void SetVisit(int i)
        {
            if (!Nodes[i].visit)
            {
                if (Nodes[i].Edge != null)
                    for (int j = 0; j <= Nodes[i].Edge.Length - 1; j++)
                    {
                        SetEdgeBlack(i, j); // закрасить ребро
                        SetVisit(Nodes[i].Edge[j].numNode);
                    }
                Lib.myStack.Push(i);
                VisitTrue(i);           // отметить песещение
            }
        }

        public void TopSort()
        {
            int N = Nodes.Length;
            ClearVisit();
            Lib.myStack = new MyStack();
            for (int i = 0; i <= N - 1; i++)
                SetVisit(i);
        }

        void SetEdgeR(int v)
        {
            if (!Nodes[v].visit)
            {
                VisitTrue(v);
                Lib.myStack.Push(v);
                int LL = 0;
                if (Nodes[v].Edge != null)
                {
                    LL = Nodes[v].Edge.Length;
                    for (int i = 0; i <= LL - 1; i++)
                        SetEdgeR(Nodes[v].Edge[i].numNode);
                }
            }
        }

        public void SetEdge(int s)
        {
            ClearVisit();
            Lib.myStack = new MyStack();
            SetEdgeR(s);
        }

    }
}
