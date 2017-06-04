using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formforclr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Act();
            InitializeComponent();
        }

        private void Act()
        {
            Controls.Add(new Label()
            {
                Location = new Point(100, 40),
                Text = "No button has been clicked",
                AutoSize = true
            });
            for (int i = 0; i < 5; i++)
            {
                Controls.Add(new Button());
                Controls[Controls.Count - 1].Width = 70;
                Controls[Controls.Count - 1].Text = "Button " + (i + 1).ToString();
                Controls[Controls.Count - 1].Height = 20;
                Controls[Controls.Count - 1].Location = new Point(20, i * 25);
                Controls[Controls.Count - 1].Tag = i + 1;
                //Controls[Controls.Count - 1].Click += (object sender, EventArgs e) => MessageBox.Show("Button " + (sender as Button).Tag.ToString() + " has been clicked");
                Controls[Controls.Count - 1].Click += (object sender, EventArgs e) => Controls[0].Text = ("Button " + (sender as Button).Tag.ToString() + " has been clicked");
            }
        }
    }
}
