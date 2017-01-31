using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphDM
{
    public class Node
    {
        public int info;
        public int x, y;
        public List<Node> children;
        public bool visitedD, visitedB;
        public int mark;

        public Node(int info, int x, int y)
        {
            children = new List<Node>();
            this.info = info;
            this.x = x;
            this.y = y;
            visitedD = false;
            visitedB = false;
        }
    }
}
