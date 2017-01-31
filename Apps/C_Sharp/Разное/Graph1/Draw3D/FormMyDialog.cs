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
    public partial class FormMyDialog : Form
    {
        public FormMyDialog()
        {
            InitializeComponent();
        }

        private void FormMyDialog_Activated(object sender, EventArgs e)
        {
            Lib.NumNode = 0;
            int L = Lib.graph.Nodes.Length;
            for (int i = 0; i < L; i++)
            {
                comboBox1.Items.Add(Lib.graph.Nodes[i].name);
                comboBox1.Text = Lib.graph.Nodes[7].name;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            //Lib.NumNode = comboBox1.SelectedIndex;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lib.NumNode = comboBox1.SelectedIndex;
        }
    }
}
