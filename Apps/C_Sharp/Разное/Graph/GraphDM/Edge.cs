using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphDM
{
    public class Edge
    {
        public Node n1;
        public Node n2;
        public int val;
        public string name;
        public bool ok;
        public int mark;

        public Edge(Node n1, Node n2, int val)
        {
            mark = 0;
            ok = false;
            this.n1 = n1;
            this.n2 = n2;
            this.val = val;
            if (n1 != null && n2 != null)
            {
                name = n1.info.ToString() + " и " + n2.info.ToString() + ":     " + val.ToString();
            }
        }

        public void Draw(Graphics gr)
        {
            Pen pen;
            if (ok)
            {
                pen = new Pen(Color.Lime);
            }
            else
            {
                pen = new Pen(Color.DarkRed);
            }
            Font font = new Font("Arial", 10);
            int x = Math.Min(n1.x, n2.x) + Math.Abs(n2.x - n1.x) / 2;
            int y = Math.Min(n1.y, n2.y) + Math.Abs(n2.y - n1.y) / 2;
            gr.DrawLine(pen, n1.x, n1.y, n2.x, n2.y);
            Point center = new Point(x, y);

        }
    }
}
