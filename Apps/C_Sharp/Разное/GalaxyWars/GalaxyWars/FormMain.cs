using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalaxyWars
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        static Graphics g;
        static Draw draw;
        static Size size;
        FormInst forminst;
        private void FormMain_Load(object sender, EventArgs e)
        {
            Init();
            size = ClientRectangle.Size;
            draw = new Draw(ClientRectangle.Size);
            forminst = new FormInst();
            forminst.Show();
        }
        void Init()
        {

            g = CreateGraphics();
            
        }
        public static void New(object sender, EventArgs e)
        {
           
            draw = new Draw(size);
            foreach (Form f in Application.OpenForms)
            {
                if (f is FormMain)
                {
                    (f as FormMain).Draw(true);
                    (f as FormMain).timerMoving.Enabled = false;
                    (f as FormMain).timerState.Enabled = false;
                }
            }

        }
        public void FormMain_Paint(object sender, PaintEventArgs e)
        {
            Draw(false);
        }

        private void FormMain_ClientSizeChanged(object sender, EventArgs e)
        {

            size = ClientRectangle.Size;
            g = CreateGraphics();
            //draw = new Draw(size);
            Draw(true);
        }
        void Draw(bool refresh)
        {

            if(refresh)
            draw.Refresh(ClientRectangle.Size);
            draw.ImDraw(g,false);
        }
        private void FormMain_MouseClick(object sender, MouseEventArgs e)
        {
            switch (forminst.mod)
            {
                case 1:
                    for(int i = 0; i<draw.star.Planets.Count;i++)
                    {
                        Rectangle a = draw.star.Planets[i].Area;
                        if (a.X<=e.X&&a.Y<=e.Y&&a.X+a.Width>=e.X&&a.Height+a.Y>=e.Y)
                        {
                            draw.star.Planets[i].team = new Civilisation(forminst.team,forminst.s,draw.star.Planets[i]);
                            draw.civ.Add(draw.star.Planets[i].team);
                        }
                    }
                    break;
                case 2:
                    break;
                case 0:
                    timerMoving.Start();
                    break;
            }
            Draw(false);
        }

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void timerMoving_Tick(object sender, EventArgs e)
        {
            Draw(false);            
        }

        private void timerState_Tick(object sender, EventArgs e)
        {
            draw.Work(true);
        }
    }
}
