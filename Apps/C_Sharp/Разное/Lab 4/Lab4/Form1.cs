using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fade = new List<bool>();
            spectrum = new List<byte[]>();
            light = new List<UniformPoint>();            
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }
        Random random;
        Triangle[] triangles;
        Color[] colors;        
        UniformPoint[] vertices;        
        double[,] zBuffer;
        double pd = 1;
        List<bool> fade;
        List<byte[]> spectrum;
        List<UniformPoint> light;

        int alpha = 255;
        void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }
        double CalculateW(int x1, int y1, int z1, int x2, int y2, int z2, int x3, int y3, int z3, int x, int y)
        {
            int a = y1 * z2 + y2 * z3 + y3 * z1 - y3 * z2 - y2 * z1 - y1 * z3;
            int b = x1 * z2 + x2 * z3 + x3 * z1 - x3 * z2 - x2 * z1 - x1 * z3;
            int c = x1 * y2 + x2 * y3 + x3 * y1 - x3 * y2 - x2 * y1 - x1 * y3;
            int d = x1 * y2 * z3 + y1 * z2 * x3 + x2 * y3 * z1 - x3 * y2 * z1 - x2 * y1 * z3 - x1 * y3 * z2;
            double w = ((double)(b * y - a * x + d)) / c;       
            return w;
        }
        void ProcessTriangle(int triangle, Bitmap image, Graphics dc)
        {
            int a = triangles[triangle].GetI(0);
            int b = triangles[triangle].GetI(1);
            int c = triangles[triangle].GetI(2);
            if (vertices[a].GetIY() > vertices[b].GetIY())
                Swap(ref a, ref b);
            if (vertices[a].GetIY() > vertices[c].GetIY())
            {
                Swap(ref a, ref c);
                Swap(ref c, ref b);
            }
            else if (vertices[b].GetIY() > vertices[c].GetIY())
                Swap(ref c, ref b);
            if (vertices[a].GetIY() == vertices[b].GetIY() && vertices[a].GetIX() > vertices[b].GetIX())
                Swap(ref a, ref b);
            int x1 = vertices[a].GetIX();
            int y1 = vertices[a].GetIY();
            int z1 = vertices[a].GetIZ();
            int x2 = vertices[b].GetIX();            
            int y2 = vertices[b].GetIY();
            int z2 = vertices[b].GetIZ();
            int x3 = vertices[c].GetIX();
            int y3 = vertices[c].GetIY();
            int z3 = vertices[c].GetIZ();       
            int pLx = Math.Abs(x3 - x1);
            int pLy = y3 - y1;
            int sLx = Math.Abs(x2 - x1);
            int sLy = y2 - y1;
            int pD = 0;
            int sD = 0;
            int pX = x1;
            int pX1 = pX;
            int sX = x1;
            int sX1 = sX;
            int pDs = pLy << 1;
            int sDs = sLy << 1;
            int pT = pLx << 1;
            int sT = sLx << 1;
            int k = x3;
            int l = x1;
            int m = x2;
            int n = x1;
            Color color = Color.FromArgb(alpha, random.Next(55, 255), random.Next(55, 255), random.Next(55, 255));  
            for (int y = y1; y <= y3; y++)
            {
                if (y == y2)
                {
                    sLy = y3 - y2;
                    sLx = Math.Abs(x3 - x2);
                    sD = 0;
                    sDs = sLy << 1;
                    sT  = sLx << 1;
                    m = x3;
                    n = x2;
                    sX = x2;
                    sX1 = sX;
                }
                pD += pT;
                sD += sT;
                while (pD > pLy && pX != k)
                {
                    pD -= pDs;
                    if (k > l)
                        pX++;
                    else pX--;
                }
                if(pT != 0)
                if (k > l )
                    pX1 = pX - 1;
                else pX1 = pX + 1;
                while (sD > sLy && sX != m)
                {
                    sD -= sDs;
                    if (m > n)
                        sX++;
                    else sX--;
                }
                if(sT !=0 )
                if (m > n)
                    sX1 = sX - 1;
                else sX1 = sX + 1;
                
                for (int x = Math.Min(pX1, sX1); x <= Math.Max(pX1, sX1); x++)
                    if (x >= 0 && y >= 0 && x < image.Width && y < image.Height)
                    {
                        double w = CalculateW(x1, y1, z1, x2, y2, z2, x3, y3, z3, x, y);
                        if (w < zBuffer[x, y] && w > 0)
                        {
                            image.SetPixel(x, y, color);
                            zBuffer[x, y] = w;
                        }
                    }
            }          
        }

        void MakePolygon(int n, double radius, double h, UniformPoint[] ret)
        {
            double addAngle = Math.PI * 2 / n;
            double angle = 0;
            for (int i = 0; i < n; i++)
            {
                ret[i] = new UniformPoint(radius * Math.Cos(angle), radius * Math.Sin(angle), h, 1);
                angle += addAngle;                
            }
        }    

        void MakePrism(int edgeCount, int height, int radius)
        {
            triangles = new Triangle[edgeCount * 4];
            vertices = new UniformPoint[edgeCount * 2 + 2];
            UniformPoint[] tmp = new UniformPoint[edgeCount];
            MakePolygon(edgeCount, radius, 0, tmp);
            for (int i = 0; i < edgeCount; i++)
                vertices[i] = tmp[i];
            MakePolygon(edgeCount, radius, height, tmp);
            for (int i = 0; i < edgeCount; i++)
                vertices[i + edgeCount] = tmp[i];
            vertices[edgeCount * 2] = new UniformPoint(0, 0, 0, 1);
            vertices[edgeCount * 2 + 1] = new UniformPoint(0, 0, height, 1);

            for (int i = 0; i < triangles.Length; i++)
                triangles[i] = new Triangle(0, 0, 0);

            for (int i = 0; i < edgeCount; i++)
            {
                int v1 = i;
                int v2 = (i + 1) % edgeCount;                
                int v3 = i + edgeCount;
                int v4 = i + edgeCount + 1;
                if(v4 == edgeCount * 2)
                    v4 = edgeCount;

                triangles[i] = new Triangle(edgeCount * 2, v1, v2);
                triangles[i + edgeCount] = new Triangle(edgeCount * 2 + 1, v3, v4);

                triangles[i + edgeCount * 2] = new Triangle(v1, v3, v4);
                triangles[i + edgeCount * 3] = new Triangle(v1, v4, v2);
            }

        }

        void FillParaphilia(double[][] paraphilia)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    paraphilia[i][j] = 0;
            paraphilia[0][2] = -1;
            paraphilia[1][0] = 1;
            paraphilia[2][1] = 1;
            paraphilia[3][3] = 1;
        }
        void Draw()
        {
            random = new Random();
            zBuffer = new double[panel2.Width, panel2.Height];

            for (int i = 0; i < panel2.Width; i++)
                for (int j = 0; j < panel2.Height; j++)
                {                  
                    zBuffer[i, j] = 1 << 22;
                   
                }
            int xView = 0;
            int yView = 0;
            int zView = 0;
            int radius = 0;
            int height = 0;
            int edgeCount = 0;
            float d = 0;
            try
            {
                xView = Convert.ToInt32(viewPointX.Text);
                yView = Convert.ToInt32(viewPointY.Text);
                zView = Convert.ToInt32(viewPointZ.Text);
                edgeCount = Convert.ToInt32(edgeCountBox.Text);
                height = Convert.ToInt32(heightBox.Text);
                radius = Convert.ToInt32(radiusBox.Text);
                d = (float)Convert.ToDouble(screenDist.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("В рот мне ноги");
                return;
            }
            MakePrism(edgeCount, height, radius);
            double mv = Math.Sqrt(xView * xView + yView * yView);
            double me = Math.Sqrt(xView * xView + yView * yView + zView * zView);
            double cost = 0;
            double sint = 1;
            if(mv != 0)
            {
                cost = (double)(xView) / mv;
                sint = (double)(yView) / mv;
            }
            double cosp = (double)(zView) / me;
            double sinp = mv / me;
            double[][] rotateZ = new double[4][];
            double[][] rotateY = new double[4][];
            double[][] tmp = new double[4][];
            double[][] tmp2 = new double[4][];
            double[][] translation = new double[4][];
            double[][] paraphilia = new double[4][];
            for (int i = 0; i < 4; i++)
            {
                tmp[i] = new double[4];
                tmp2[i] = new double[4];
                rotateY[i] = new double[4];
                rotateZ[i] = new double[4];
                translation[i] = new double[4];
                paraphilia[i] = new double[4];
            }
            FillParaphilia(paraphilia);
            Matrix.Make3DRotationY(sinp, cosp, rotateY);
            Matrix.Make3DRotationZ(cost, -sint, rotateZ);
            Matrix.Make3DTranslation(-me, 0, 0, translation);
            Matrix.MatrixMatrixMlp(rotateZ, rotateY, 4, tmp);
            Matrix.MatrixMatrixMlp(tmp, translation, 4, tmp2);
            Matrix.MatrixMatrixMlp(tmp2, paraphilia, 4, tmp);
            float dx = panel2.Width / 2;
            float dy = panel2.Height / 2;
            Graphics dc = panel2.CreateGraphics();
            dc.Clear(panel2.BackColor);
            Pen pen = new Pen(Color.White, 2);
       
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].Transform(tmp);                
                if (perspective.Checked)
                    vertices[i].MakePerspectiveTransformation(d);
                vertices[i].Shift(dx, dy, 0);                              
            }          
            if (isWireframe.Checked)
                for (int i = 0; i < triangles.Length; i++)
                {
                    float x1 = (float)vertices[triangles[i].GetI(0)].GetX();
                    float y1 = (float)vertices[triangles[i].GetI(0)].GetY();
                    float x2 = (float)vertices[triangles[i].GetI(1)].GetX();
                    float y2 = (float)vertices[triangles[i].GetI(1)].GetY();
                    float x3 = (float)vertices[triangles[i].GetI(2)].GetX();
                    float y3 = (float)vertices[triangles[i].GetI(2)].GetY();
                    dc.DrawLine(pen, x1, y1, x2, y2);
                    dc.DrawLine(pen, x1, y1, x3, y3);
                    dc.DrawLine(pen, x2, y2, x3, y3);
                }

            else
            {                             
                Bitmap image = new Bitmap(panel2.Width, panel2.Height);
                for (int i = 0; i < triangles.Length; i++)
                    ProcessTriangle(i, image, dc);
                dc.DrawImage(image, new Point(0, 0));
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Draw();
        } 
    }
}