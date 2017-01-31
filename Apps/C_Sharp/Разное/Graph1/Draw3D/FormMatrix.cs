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
    public partial class FormMatrix : Form
    {
        TNode[] nodes;
        public FormMatrix()
        {
            InitializeComponent();
        }

        private void FormMatrix_Load(object sender, EventArgs e)
        {
            nodes = Lib.graph.Nodes;
            int L = nodes.Length;
            for (int j = 0; j <= L - 1; j++)
            {
                dataGridView1.Columns.Add("adr" + Convert.ToString(j), Convert.ToString(j));
                dataGridView1.Columns[j].Width = 30;
            }

            dataGridView1.ColumnCount = L;
            dataGridView1.RowCount = L;
            Lib.graph.SetA();
            for (int i = 0; i < L; i++)
                for (int j = 0; j < L; j++)
                    if ((Lib.graph.A[i, j] != 0xFFFFF) & (i != j) & (Lib.graph.A[i, j] != int.MaxValue))
                        dataGridView1[i, j].Value = Convert.ToString(Lib.graph.A[i, j]);
                    else
                        //if (Lib.graph.A[i, j] == 0xFFFFF)
                            dataGridView1[i, j].Value = "";
                        //else
                        //    dataGridView1[i, j].Value = "oo";
        }

        private void buttonSymmetria_Click(object sender, EventArgs e)
        {
            Lib.graph.SetSim();
            Lib.graph.SetA();
            int L = nodes.Length;
            for (int i = 0; i < L; i++)
                for (int j = 0; j < L; j++)
                    if ((Lib.graph.A[i, j] != int.MaxValue) & (i != j))
                        dataGridView1[i, j].Value = Convert.ToString(Lib.graph.A[i, j]);
                    else
                        dataGridView1[i, j].Value = "";
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            int L = nodes.Length;
            for (int i = 0; i < L; i++)
                for (int j = 0; j < L; j++)
                    if ((string)dataGridView1[i, j].Value != "")
                    {
                        int n = Lib.graph.FindNumEdge(i, j);
                        Lib.graph.Nodes[i].Edge[n].A =
                            Convert.ToInt32(dataGridView1[i, j].Value);
                    }

        }
    }
}
