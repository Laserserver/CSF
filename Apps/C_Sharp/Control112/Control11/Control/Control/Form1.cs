using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    public partial class Diagr : Form
    {
        public double[] mas;
        Graphics _canvas;
        Bitmap _tb;
        public Diagr()
        {
            InitializeComponent();

            _canvas = CreateGraphics();
            _tb = new Bitmap(ClientSize.Width, ClientSize.Height);
        }

        private void New_Click(object sender, EventArgs e)
        {


        }

        private void userControl11_Load(object sender, EventArgs e)
        {
            // string s1 = Diagram.MyNumbers;
            //// string s1 = Numbers.Text;
            // string[] arrstring = new string[1];
            // if (s1 != "")
            // {
            //     arrstring = s1.Split(' ');
            // }
            // mas = new double[arrstring.Length];
            // for (int i = 0; i < arrstring.Length; i++)
            // {
            //     mas[i] = Convert.ToInt32(arrstring[i]);
            // }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {

            this.Invalidate();
        }

        private void userControl11_Load_1(object sender, EventArgs e)
        {

        }

        private void Diagr_Load(object sender, EventArgs e)
        {

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioNumPer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void userControl11_MyNumberChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (Graphics g = Graphics.FromImage(_tb))
            {
                g.Clear(Color.Black);
                g.DrawLine(Pens.White, 0, 0, 100, 100);
                _canvas.DrawImage(_tb, ClientRectangle);
            }
        }
    }
}
