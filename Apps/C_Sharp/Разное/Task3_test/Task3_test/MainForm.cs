using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Task3_test
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = e.X.ToString() + ";" + e.Y.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void but_show_Click(object sender, EventArgs e)
        {
            map_of_Europe1.ShowMap();
            map_of_Europe1.MF.FormClosed += new FormClosedEventHandler(MF_FormClosed);
           

        }

        void MF_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Size = new System.Drawing.Size(363, 241);
            TB_info.Visible = true;
            label1.Visible = true;
            label1.Text += map_of_Europe1.SelectedCountry.Name + "))";
            TB_info.Text=map_of_Europe1.SelectedCountry.ExtendedInfo;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void esc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
