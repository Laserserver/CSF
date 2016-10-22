using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOR
{
    public partial class Form1 : Form
    {
        Tor _tor;
        int i = 0;
        int typeDraw;

        public void Draw(int type)
        {
            pic.Image = _tor.DrawingTor(pic.Width, pic.Height, 300, type);
            timer1.Enabled = true;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void goF_Click(object sender, EventArgs e)
        {
            typeDraw = 0;
            timer1.Enabled = false;
            timer1.Enabled = true;
        }

        private void stop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _tor = new Tor();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw(typeDraw);
            _tor.Speed = i + 1;
            i++;
        }

        private void goS_Click(object sender, EventArgs e)
        {
            typeDraw = 1;
            timer1.Enabled = true;
        }

        private void goА_Click(object sender, EventArgs e)
        {
            typeDraw = 0;
            timer1.Enabled = true;
        }

        private void nPersp_Click(object sender, EventArgs e)
        {
            typeDraw = 2;
            timer1.Enabled = true;
        }
    }
}
