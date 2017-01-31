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
    public partial class FormTools : Form
    {
        public FormTools()
        {
            InitializeComponent();
        }

        private void FormTools_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            this.Location = new Point(w - this.Width, 30);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Lib.graph.typ_graph = 0;
            Program.formMain.MyDraw(false);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Lib.graph.typ_graph = 1;
            Program.formMain.MyDraw(false);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            FormGraph.flTools = Convert.ToByte((sender as RadioButton).Tag);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Lib.graph.visibleA = checkBox1.Checked;
            Program.formMain.MyDraw(false);
        }

    }
}
