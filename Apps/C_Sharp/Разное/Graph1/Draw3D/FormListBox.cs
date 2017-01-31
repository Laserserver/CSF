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
    public partial class FormListBox : Form
    {
        public int fl_proc = 0;
        public FormListBox()
        {
            InitializeComponent();
        }

        private void FormListBox_Activated(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            switch (fl_proc)
            {
                case 0:
                    Text = "Гамильтоновы пути";
                    Lib.graph.Gamilton(listBox1.Items);
                    break;
                case 1:
                    Text = "Минимальные расстояния";
                    Lib.graph.MinDist0(0);
                    for (int v =0; v<Lib.graph.Nodes.Length; v++)
                        listBox1.Items.Add("0 => " + Convert.ToString(v) + ':' + 
                            Convert.ToString(Lib.graph.Nodes[v].dist));
                    break;
                case 2:
                    Text = "Минимальные расстояния Форда-Беллмана";
                    Lib.graph.Bellmann(0);
                    int N = Lib.graph.Nodes.Length;
                    string s;
                    for (int i = 0; i <= N - 1; i++)
                    {
                        if (Lib.graph.Nodes[i].dist == 0xFFFFFF)
                            s = "No path";
                        else
                            s = Convert.ToString(Lib.graph.Nodes[i].dist);
                        s = Convert.ToString(i) + " " + s;
                        listBox1.Items.Add(s);
                    }
                    break;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
