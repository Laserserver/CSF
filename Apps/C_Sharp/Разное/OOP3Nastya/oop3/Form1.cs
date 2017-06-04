using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP3
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;
        public Form1()
        {
            InitializeComponent();
            Instance = this;
            Game.Singletone.LabelLink = label1;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            try
            {
                Game.StartGame(gameControlForm1.WidthCells, gameControlForm1.HeightCells, chbIsPc1.Checked, false);
                btnStartGame.Enabled = false;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
                btnStartGame.Enabled = true;
            }
        }
    }
}
