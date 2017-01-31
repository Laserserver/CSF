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
    partial class FormInst : Form
    {
        public FormInst()
        {
            InitializeComponent();
        }
        public int mod = 2;
        public int team = 1;
        public Strategy s = (Strategy)1;
        private void buttonStart_Click(object sender, EventArgs e)
        {
            mod = 0;

            buttonAdd.Enabled = true;

            foreach (Form f in Application.OpenForms)
            {
                if (f is FormMain)
                {
                    (f as FormMain).timerMoving.Start();

                    (f as FormMain).timerState.Start();
                }
            }
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            team = (int)numericTeam.Value;
            s = (Strategy)(((double)trackBarStrategy.Value) / 10<0.5?0: ((double)trackBarStrategy.Value) / 10==1? ((double)trackBarStrategy.Value) / 10+1:0); 
            mod = 1;
            buttonAdd.Enabled = false;
        }

        private void trackBarStrategy_Scroll(object sender, EventArgs e)
        {
            labelStrategy.Text = ((Strategy)(((double)trackBarStrategy.Value) / 10 < 0.5 ? 0 : ((double)trackBarStrategy.Value) / 10 == 1 ? ((double)trackBarStrategy.Value) / 10 + 1 : 1)).ToString();
        }

        private void numericTeam_ValueChanged(object sender, EventArgs e)
        {
            team = (int)numericTeam.Value;
        }
    }
}
