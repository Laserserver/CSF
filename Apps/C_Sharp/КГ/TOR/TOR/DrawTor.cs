using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace TOR
{
    class Tor
    {
        Pen pen = new Pen(Color.Black, 1);
        readonly MathDescription.Points[,] countP;
        readonly MathDescription.Points[,] viewP;
        int N = 40, n = 40, R = 100;
        double R1 = 40, R2 = 50;
        double[,] arr;
      
        public double Speed { get; set; }

        public Tor()
        {
            countP = new MathDescription.Points[N, n];
            viewP = new MathDescription.Points[countP.GetLength(0), countP.GetLength(1)];
            CreateCoordinates();
            Array.Copy(countP, viewP, countP.Length);
        }

        private void CreateCoordinates()
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < n; j++)
                    countP[i, j] = Expansion(R, R2, R1, (i * 360 / (N - 1)), j * 360 / (n - 1));
        }

    
        public MathDescription.Points Expansion(double _R, double _r, double _r1, double A, double B)
        {

            MathDescription.Points point = new MathDescription.Points();        
            point.x = (_R + _r * Math.Cos(A * Math.PI / 180)) * Math.Cos(B * Math.PI / 180);
            point.y = (_R + _r *  Math.Cos(A * Math.PI / 180)) * Math.Sin(B * Math.PI / 180);
            point.z = _r1 * Math.Sin(A * Math.PI / 180);
            return point;
        }

        public Bitmap DrawingTor(int _width, int _height, int d, int type)
        {       
            Bitmap bmp = new Bitmap(_width, _height);
            Graphics graph = Graphics.FromImage(bmp);
           
            
            graph.SmoothingMode = SmoothingMode.AntiAlias;
            
            MathDescription.Points[,] points = new MathDescription.Points[N, n];
            
            Array.Copy(viewP, points, viewP.Length);
            points = MathDescription.RotateX(points, Speed);
            points = MathDescription.RotateY(points, Speed);
           // points = MathDescription.RotateZ(points, Speed);
            points = MathDescription.Perspective(points);
            DrawingPoint(points, d);
                    
          
            Point[] p = new Point[4];
            List<_4Points> coordList = new List<_4Points>();
            for (int i = 0; i < N - 1; i++)
                for (int j = 0; j < n - 1; j++)
                    coordList.Add(new _4Points(points[i, j], points[i, j + 1], points[i + 1, j], points[i + 1, j + 1]));
            
            double cur = 0;
            arr = new double[coordList.Count, 2];
            for (int i = 0; i < coordList.Count(); i++)
            {
                cur = 0;
                cur = (coordList[i].point_1.z + coordList[i].point_2.z + coordList[i].point_3.z + coordList[i].point_4.z) / 4;
                arr[i, 0] = cur;
                arr[i, 1] = i;
            }
            
            double[] NormAngle = new double[coordList.Count];
            for (int m = 0; m < coordList.Count; m++)
            {
                NormAngle[m] = CosNormal(coordList[m]);
            }

            QSort(arr, 0, coordList.Count - 1);
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                p[0].X = (int)coordList[(int)arr[i, 1]].point_1.x + d;
                p[0].Y = (int)coordList[(int)arr[i, 1]].point_1.y + d;
                
                p[1].X = (int)coordList[(int)arr[i, 1]].point_2.x + d;
                p[1].Y = (int)coordList[(int)arr[i, 1]].point_2.y + d;
                
                p[2].X = (int)coordList[(int)arr[i, 1]].point_4.x + d;
                p[2].Y = (int)coordList[(int)arr[i, 1]].point_4.y + d;
                
                p[3].X = (int)coordList[(int)arr[i, 1]].point_3.x + d;
                p[3].Y = (int)coordList[(int)arr[i, 1]].point_3.y + d;

                if (type == 1)
                {

                    int _alpha = Math.Abs((int)(255 * (NormAngle[(int)arr[i, 1]])));
                    Color clr = Color.FromArgb(_alpha, 25, 100, 120);
                    SolidBrush dr = new SolidBrush(clr);
                    graph.FillPolygon(Brushes.Black, p);
                    graph.FillPolygon(dr, p);
                }
                else
                    graph.DrawPolygon(pen, p);
            }
            
            return bmp;
        }

        private double CosNormal(_4Points p)
        {
            double cos = new double();
            double[] coord = new double[3]; 
            coord[0] = (p.point_2.y - p.point_1.y) * (p.point_3.z - p.point_1.z) - (p.point_2.z - p.point_1.z) * (p.point_3.y - p.point_1.y);  //координаты нормали по x
            coord[1] = (p.point_2.z - p.point_1.z) * (p.point_3.x - p.point_1.x) - (p.point_2.x - p.point_1.x) * (p.point_3.z - p.point_1.z);  //координаты нормали по y
            coord[2] = (p.point_2.x - p.point_1.x) * (p.point_3.y - p.point_1.y) - (p.point_2.y - p.point_1.y) * (p.point_3.x - p.point_1.x);  //координаты нормали по z
            cos = coord[2]/(Math.Sqrt(Math.Pow(coord[0], 2) + Math.Pow(coord[1], 2) + Math.Pow(coord[2], 2)));
            return cos;
        }

        private void DrawingPoint(MathDescription.Points[,] points, int d)
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < n; j++)
                {
                    points[i, j].x = points[i, j].x;
                    points[i, j].y = points[i, j].y;
                }
        }

        private void QSort(double[,] _facets, int _in, int _out)
        {
            if (_in >= _out) return;
            int temp = Partition(_facets, _in, _out);
            QSort(_facets, _in, temp - 1);
            QSort(_facets, temp + 1, _out);
        }

        private static int Partition(double[,] _facets, int _in, int _out)
        {
            int marker = _in;
            for (int i = _in; i <= _out; i++)
            {
                if (_facets[i, 0] <= _facets[_out, 0])
                {
                    double temp = _facets[marker, 0];
                    _facets[marker, 0] = _facets[i, 0];
                    _facets[i, 0] = temp;
                    temp = _facets[marker, 1];
                    _facets[marker, 1] = _facets[i, 1];
                    _facets[i, 1] = temp;
                    marker++;
                }
            }
            return marker - 1;
        }
    }
}
