using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphDM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }

        Graph mainGraph, workGraph;
        Graphics gr;
        Node n1, n2, n3, n4, n5, n6, n7, n8, n9, n10;
        Edge v12, v13, v24, v25, v36, v37, v67, v48, v49, v59, v710, v89;

        private void Form1_Load(object sender, EventArgs e)
        {
            // =============graph=================


            mainGraph = new Graph();
            workGraph = mainGraph;

            n1 = new Node(1, 250, 10);
            n2 = new Node(2, 150, 60);
            n3 = new Node(3, 350, 60);
            n4 = new Node(4, 80, 100);
            n5 = new Node(5, 220, 100);
            n6 = new Node(6, 280, 100);
            n7 = new Node(7, 430, 100);
            n8 = new Node(8, 10, 145);
            n9 = new Node(9, 150, 145);
            n10 = new Node(10, 510, 145);

            mainGraph.nodes.Add(n1);
            mainGraph.nodes.Add(n2);
            mainGraph.nodes.Add(n3);
            mainGraph.nodes.Add(n4);
            mainGraph.nodes.Add(n5);
            mainGraph.nodes.Add(n6);
            mainGraph.nodes.Add(n7);
            mainGraph.nodes.Add(n8);
            mainGraph.nodes.Add(n9);
            mainGraph.nodes.Add(n10);

            n1.children.Add(n2);
            n1.children.Add(n3);
            n2.children.Add(n1);
            n2.children.Add(n4);
            n2.children.Add(n5);
            n3.children.Add(n1);
            n3.children.Add(n6);
            n3.children.Add(n7);
            n4.children.Add(n2);
            n4.children.Add(n8);
            n5.children.Add(n2);
            n5.children.Add(n9);
            n6.children.Add(n3);
            n6.children.Add(n7);
            n7.children.Add(n10);
            n7.children.Add(n3);
            n7.children.Add(n6);
            n8.children.Add(n4);
            n8.children.Add(n9);
            n9.children.Add(n8);
            n9.children.Add(n4);
            n9.children.Add(n5);
            n10.children.Add(n7);

            v12 = new Edge(n1, n2, 10);
            v13 = new Edge(n1, n3, 4);
            v24 = new Edge(n2, n4, 1);
            v25 = new Edge(n2, n5, 3);
            v36 = new Edge(n3, n6, 7);
            v37 = new Edge(n3, n7, 11);
            v48 = new Edge(n4, n8, 6);
            v49 = new Edge(n4, n9, 15);
            v59 = new Edge(n5, n9, 13);
            v67 = new Edge(n6, n7, 2);
            v710 = new Edge(n7, n10, 4);
            v89 = new Edge(n8, n9, 14);

            workGraph.edges.Add(v12);
            workGraph.edges.Add(v13);
            workGraph.edges.Add(v24);
            workGraph.edges.Add(v25);
            workGraph.edges.Add(v36);
            workGraph.edges.Add(v37);
            workGraph.edges.Add(v48);
            workGraph.edges.Add(v49);
            workGraph.edges.Add(v59);
            workGraph.edges.Add(v67);
            workGraph.edges.Add(v710);
            workGraph.edges.Add(v89);

            workGraph.BubbleSort(workGraph.sorted);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            gr = e.Graphics;
            gr.Clear(Color.White);
            Font font = new Font("Arial", 10, FontStyle.Bold);

            foreach (var n in workGraph.nodes)
            {
                for (int i = 0; i < n.children.Count; i++)
                {
                    gr.DrawLine(Pens.DarkRed, n.x, n.y, n.children[i].x, n.children[i].y);
                }
            }

            foreach (var v in workGraph.edges)
            {
                v.Draw(gr);
            }

            foreach (var n in workGraph.nodes)
            {
                gr.FillEllipse(Brushes.FloralWhite, n.x - 10, n.y - 10, 40, 40);
                gr.DrawEllipse(Pens.DarkRed, n.x - 10, n.y - 10, 40, 40);
                gr.DrawString(n.info.ToString(), font, Brushes.DarkRed, n.x + 5, n.y + 5);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            int num = Convert.ToInt32(textBox1.Text) - 1;
            if (num < 0 || num > 10)
            {
                num = 0;
            }
            foreach (var n in mainGraph.nodes)
            {
                n.visitedB = false;
            }
            mainGraph.Width(mainGraph.nodes[num]);
            foreach (var n in mainGraph.wayWidth)
            {
                richTextBox2.Text += n.info.ToString() + ' ';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainGraph.wayDepth.Clear();
            richTextBox3.Text = "";
            int num = Convert.ToInt32(textBox1.Text) - 1;
            if (num < 0 || num > 10)
            {
                num = 0;
            }
            foreach (var n in mainGraph.nodes)
            {
                n.visitedD = false;
            }
            mainGraph.DepthStack(mainGraph.nodes[num]);
            foreach (var n in mainGraph.wayDepth)
            {
                richTextBox3.Text += n.info.ToString() + ' ';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var v in workGraph.edges)
            {
                richTextBox1.Text += v.name + '\n';
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            workGraph.Kruskal();
            textBox2.Text = "Weight: " + workGraph.sum.ToString();
            this.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            workGraph.Prim();
            textBox3.Text = "Weight: " + workGraph.sum.ToString();
            this.Invalidate();
        }
    }
}
