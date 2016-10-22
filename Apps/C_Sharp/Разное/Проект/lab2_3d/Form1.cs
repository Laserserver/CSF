using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        polygon[] polygons;
        public Form1()
        {
            InitializeComponent();
            this.polygons = new polygon[2];

            polygons[0] = new polygon();
            polygons[0].color = Brushes.Green;
            polygons[0].points = new point3d[] { new point3d(400, 100,5), new point3d(460, 100,5), new point3d(460, 120,5), new point3d(400, 120,5) };



            polygons[1] = new polygon();
            polygons[1].color = Brushes.Red;
            polygons[1].points = new point3d[] { new point3d(400, 100,5), new point3d(420, 100,5), new point3d(420, 200,5), new point3d(400, 200,5) };
        
        }


        PointF[][] twod()
        {
            PointF[][] result = new PointF[polygons.Length][];
            for (int i = 0; i < polygons.Length; i++)
            {
                result[i] = new PointF[polygons[i].points.Length];
                for (int j = 0; j < polygons[i].points.Length; j++)
                {

                    float x = polygons[i].points[j].x;
                    float y = polygons[i].points[j].y;
                    result[i][j] = new PointF(x, y);
                }
            }
            return result;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            PointF[][] matrix = twod();
            for (int i = 0; i < matrix.Length; i++)
                e.Graphics.FillPolygon(polygons[i].color, matrix[i]);

        }
    }
}
