using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphDM
{
    public class Graph
    {
        public List<Node> nodes;
        public Queue<Node> queue;
        public Stack<Node> stack;
        public List<Node> wayDepth;
        public List<Node> wayWidth;
        public List<Edge> edges;
        public List<Edge> sorted;
        private List<Edge> potential;
        private Node tempNode;
        private Edge tempEdge;
        public int sum;

        public Graph()
        {
            nodes = new List<Node>();
            queue = new Queue<Node>();
            stack = new Stack<Node>();
            wayDepth = new List<Node>();
            wayWidth = new List<Node>();
            tempNode = new Node(-1, 0, 0);
            tempEdge = new Edge(null, null, -1);
            potential = new List<Edge>();
            nodes = new List<Node>();
            edges = new List<Edge>();
            sorted = new List<Edge>();
            sorted = edges;
            BubbleSort(sorted);
        }

        /// <summary>
        /// Обход в глубину
        /// </summary>
        public void DepthStack(Node node)
        {
            node.visitedD = true;
            stack.Push(node);
            wayDepth.Add(node);
            foreach (var n in node.children)
            {
                if (stack.Count != 0)
                {
                    if (!n.visitedD)
                    {
                        DepthStack(n);
                    }
                }
            }
            stack.Pop();
        }

        /// <summary>
        /// Обход в ширину
        /// </summary>
        public void Width(Node node)
        {
            wayWidth.Clear();
            node.visitedB = true;
            queue.Enqueue(node);
            wayWidth.Add(node);
            while (queue.Count != 0)
            {
                Node temp = queue.Dequeue();
                foreach (var n in temp.children)
                {
                    if (!n.visitedB)
                    {
                        n.visitedB = true;
                        queue.Enqueue(n);
                        wayWidth.Add(n);
                    }
                }
            }
        }

        /// <summary>
        /// Метод сортировки ребер по весу
        /// </summary>
        public void BubbleSort(List<Edge> arr)
        {
            int n = arr.Count;
            for (int i = 1; i <= n - 1; i++)
            {
                for (int j = n - 1; j >= i; j--)
                {
                    if (arr[j - 1].val > arr[j].val)
                    {
                        Edge t = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = t;
                    }
                }
            }
        }

        /// <summary>
        /// Алгоритм Краскала построения минимального остовного дерева
        /// </summary>
        public void Kruskal()
        {
            int i = 1;
            foreach (Edge v in sorted)
            {
                if (v.n1.mark == 0 && v.n2.mark == 0)
                {
                    v.ok = true;
                    v.n1.mark = i;
                    v.n2.mark = i;
                    sum += v.val;
                }
                if (v.n1.mark == 0 && v.n2.mark != 0)
                {
                    v.ok = true;
                    v.n1.mark = v.n2.mark;
                    sum += v.val;
                }
                if (v.n1.mark != 0 && v.n2.mark == 0)
                {
                    v.ok = true;
                    v.n2.mark = v.n1.mark;
                    sum += v.val;
                }
                if (v.n1.mark != 0 && v.n2.mark != 0 && v.n1.mark != v.n2.mark)
                {
                    int mark = v.n2.mark;
                    v.ok = true;
                    foreach (Node n in nodes)
                    {
                        if (n.mark == mark)
                        {
                            n.mark = v.n1.mark;
                        }
                    }
                    v.n2.mark = v.n1.mark;
                    sum += v.val;
                }
                i++;
            }
        }

        /// <summary>
        /// Алгоритм Прима построения минимального остовного дерева
        /// </summary>
        public void Prim()
        {
            tempNode = nodes[0];
            tempNode.mark = 1;
            foreach (Edge v in edges)
            {
                if (v.n1 == tempNode || v.n2 == tempNode)
                {
                    potential.Add(v);
                }
            }
            BubbleSort(potential);

            while (potential.Count != 0)
            {
                tempEdge = potential[0];
                if (tempEdge.n1.mark == 0 || tempEdge.n2.mark == 0)
                {
                    tempEdge.ok = true;
                    if (tempEdge.n1.mark != 1)
                    {
                        tempEdge.n1.mark = 1;
                        tempNode = tempEdge.n1;
                    }
                    if (tempEdge.n2.mark != 1)
                    {
                        tempEdge.n2.mark = 1;
                        tempNode = tempEdge.n2;
                    }
                    sum += tempEdge.val;
                    potential.Remove(tempEdge);
                    foreach (Edge edge in edges)
                    {
                        if ((edge.n1 == tempNode || edge.n2 == tempNode) && !edge.ok && !potential.Contains(edge))
                        {
                            potential.Add(edge);
                        }
                    }
                    BubbleSort(potential);
                }
                else
                {
                    potential.Remove(tempEdge);
                }
            }
        }
    }
}
