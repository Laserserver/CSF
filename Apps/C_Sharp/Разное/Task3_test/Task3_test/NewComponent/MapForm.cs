using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Task3_test.NewComponent
{
    public  partial class MapForm : Form
    {
        Country[] countrys;
        Map_of_Europe Control;
        public MapForm(Country[] country,Map_of_Europe control)
        {
            InitializeComponent();
            this.countrys = country;
            this.Control = control;
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            //toolTip1.SetToolTip(Norway, "Норвегия jdhdkjshgsdkjfhgdskjfhgkdjsfhjgksdfglsdflgsdkfhgkdjfnbjnjfnbfdjkhgddfkljgdlfkjdkfkldjdkflgldkfhg");
            //toolTip1.SetToolTip(Sweden, "Швеция");
            
           // toolTip1.SetToolTip(p)
            for (int i = 0; i < countrys.Length; i++)
            {
                toolTip1.SetToolTip(countrys[i].picture, countrys[i].Name);
            }
        }

        private void MapForm_MouseMove(object sender, MouseEventArgs e)
        {
            coordinate.Text = e.X + ";" + e.Y;
            for (int i = 0; i < countrys.Length; i++)
            {

                if (((e.X >= countrys[i].coordinates.BorderLeft.X) && (e.X <= countrys[i].coordinates.BorderRight.X)) && ((e.Y >= countrys[i].coordinates.BorderLeft.Y) && (e.Y <= countrys[i].coordinates.BorderRight.Y)))
                {
                    countrys[i].picture.Visible = true;
                    this.Controls.Add(countrys[i].picture);
                    this.Control.SelectedCountry = countrys[i];
                    if (countrys[i].brief_information.Image != null)
                    {
                        countrys[i].brief_information.Location = new Point(0, 448);
                        countrys[i].brief_information.Size = new Size(400,400);
                        countrys[i].brief_information.SizeMode = PictureBoxSizeMode.Zoom;
                        countrys[i].brief_information.BackColor = Color.Transparent;
                        countrys[i].brief_information.Visible = true;
                        this.Controls.Add(countrys[i].brief_information);
                    }
                    else
                    {
                       // this.Control.SelectedCountry = countrys[0];
                    }
                    
                }
                else
                {
                    countrys[i].picture.Visible = false;
                    countrys[i].brief_information.Visible = false;
                }
            }
                

        }

        private void MapForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        public Country  fuction_return()
        {
            return this.Control.SelectedCountry;
        }

        

       
    }
}
