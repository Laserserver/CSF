using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Render
{
    class Model
    {
        public Bitmap texture;
        double maxZ;
        double maxX;
        double maxY;

        public class TextureP
        {
            public double X;
            public double Y;
            public TextureP(double x, double y)
            {
                X = x;
                Y = y;
            }
        }
        public class Polygon
        {
            public List<int> vtInd;
            public int[] dots;
            public double dist;
            public double[] center;
            public double X;
            public double Y;
            public double Z;

        }
        public class myPoint
        {
            public double X;
            public double Y;
            public double Z;
            public double[] normal;
            //public myPoint() { normal = new double[0]; }
        }
        
        public Polygon[] polygons;
        public myPoint[] points;
        public List<TextureP> tPoints;


        public void CalculateCenter()
        {
            double x1 = 0;
            double y1 = 0;
            double z1 = 0;
            int c = 0;
            for (int i = 0; i < polygons.Length; i++)
            {
                for (int j = 0; j < polygons[i].dots.Length; j++)
                {
                    x1 += points[polygons[i].dots[j] - 1].X;
                    y1 += points[polygons[i].dots[j] - 1].Y;
                    z1 += points[polygons[i].dots[j] - 1].Z;
                    c++;
                }
                x1 = x1 / c;
                y1 = y1 / c;
                z1 = z1 / c;
                polygons[i].center = new double[]{ x1, y1, z1 };
            }
        }
        public void TurnDownForWhat(double angl, int x, int y, int z)
        {
            double[,] p = new double[points.Length, 3];
            for (int i = 0; i < points.Length; i++)
            {
                p[i, 0] = points[i].X;
                p[i, 1] = points[i].Y;
                p[i, 2] = points[i].Z;
            }
            p = Matrix.TurnMatrix(p, angl, x, y, z);
            for (int j = 0; j < points.Length; j++)
            {
                points[j].X = p[j, 0];
                points[j].Y = p[j, 1];
                points[j].Z = p[j, 2];
            }
        }
        public void Zoom(double step)
        {
            double[,] p = new double[points.Length, 3];
            for (int i = 0; i < points.Length; i++)
            {
                p[i, 0] = points[i].X;
                p[i, 1] = points[i].Y;
                p[i, 2] = points[i].Z;
            }
            p = Matrix.ZoomMatrix(p, step, step, step);
            for (int j = 0; j < points.Length; j++)
            {
                points[j].X = p[j, 0];
                points[j].Y = p[j, 1];
                points[j].Z = p[j, 2];
            }
        }

        public void DistCenter()
        {
            //points[polygons[j].dots[0] - 1].X
            

            for (int i = 0; i < polygons.Length; i++)
            {
                double x = 0;
                double y = 0;
                double z = 0;
                int c = 0;
                for (int j = 0; j < polygons[i].dots.Length; j++)
                {
                    x += points[polygons[i].dots[j] - 1].X;
                    y += points[polygons[i].dots[j] - 1].Y;
                    z += points[polygons[i].dots[j] - 1].Z;
                    c++;
                }
                x = x / c;
                y = y / c;
                z = z / c;
                polygons[i].center[0] = x;
                polygons[i].center[1] = y;
                polygons[i].center[2] = z;

                polygons[i].dist = Math.Sqrt(Math.Pow((x- x), 2) + Math.Pow((y - y), 2) + Math.Pow((1000 + 100 - z), 2));

            }
                            
        }

        public void SortPolygons()
        {
            DistCenter();
            int j;
            int step = polygons.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < (polygons.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (polygons[j].dist < polygons[j + step].dist))
                    {
                        Polygon tmp = polygons[j];
                        polygons[j] = polygons[j + step];
                        polygons[j + step] = tmp;
                        j -= step;
                    }
                }
                step = step / 2;
            }
        }
       
        public void PushNormal()
        {
            double[] x = new double[3];
            double[] y = new double[3];
            double[] z = new double[3];
            
            for (int i = 0; i < polygons.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    x[j] = points[polygons[i].dots[j] - 1].X;
                    y[j] = points[polygons[i].dots[j] - 1].Y;
                    z[j] = points[polygons[i].dots[j] - 1].Z;
                }
                polygons[i].X = (y[1] - y[0]) * (z[2] - z[0]) - (y[2] - y[0]) * (z[1] - z[0]);
                //polygons[i].Y = (x[1] - x[0]) * (z[2] - z[0]) - (x[2] - x[0]) * (z[1] - z[0]);
                polygons[i].Y = (x[2] - x[0]) * (z[1] - z[0]) - (x[1] - x[0]) * (z[2] - z[0]);
                polygons[i].Z = (x[1] - x[0]) * (y[2] - y[0]) - (x[2] - x[0]) * (y[1] - y[0]);
            }
        }
    
        public Model()
        {
            points = new myPoint[0];
            polygons = new Polygon[0];
            tPoints = new List<TextureP>();
        }
        public void PushPolygon(int[] arr, List<int> textureDots)
        {
            Array.Resize<Polygon>(ref polygons, polygons.Length + 1);
            polygons[polygons.Length - 1] = new Polygon();
            polygons[polygons.Length - 1].dots = arr;
            polygons[polygons.Length - 1].vtInd = textureDots;
        }
        public void PushPoint(string x, string y, string z)
        {
            Array.Resize<myPoint>(ref points, points.Length + 1);  
            points[points.Length - 1] = new myPoint();
            points[points.Length - 1].X = double.Parse(x, System.Globalization.CultureInfo.InvariantCulture);
            points[points.Length - 1].Y = double.Parse(y, System.Globalization.CultureInfo.InvariantCulture);
            points[points.Length - 1].Z = double.Parse(z, System.Globalization.CultureInfo.InvariantCulture);
            if (points.Length == 1)
            {
                maxX = points[points.Length - 1].X;
                maxY = points[points.Length - 1].Y;
                maxZ = points[points.Length - 1].Z;
            }
            else
            {
                if (points[points.Length - 1].Z > maxZ)
                {
                    maxZ = points[points.Length - 1].Z;
                    maxX = points[points.Length - 1].X;
                    maxY = points[points.Length - 1].Y;
                }
            }   
        }
        public void Print()
        {
            for (int i = 0; i < points.Length; i++)
            {
                Console.WriteLine(points[i].X.ToString() + " " + points[i].Y.ToString() + " " + points[i].Z.ToString() + "\n");
            }
        }
        private void calculatePointNormal()
        {
            for (int i = 0; i < polygons.Length; i++)
                for (int j = 0; j < polygons[i].dots.Length; j++)
                    if (points[polygons[i].dots[j] - 1].normal != null)
                    {
                        points[polygons[i].dots[j] - 1].normal[0] = 0;
                        points[polygons[i].dots[j] - 1].normal[1] = 0;
                        points[polygons[i].dots[j] - 1].normal[2] = 0;
                    }

            for (int i = 0; i < polygons.Length; i++)
            {
                for (int j = 0; j < polygons[i].dots.Length; j++)
                {
                    if (points[polygons[i].dots[j] - 1].normal == null)
                    {
                        points[polygons[i].dots[j] - 1].normal = new double[3];
                        points[polygons[i].dots[j] - 1].normal[0] = polygons[i].X;
                        points[polygons[i].dots[j] - 1].normal[1] = polygons[i].Y;
                        points[polygons[i].dots[j] - 1].normal[2] = polygons[i].Z;
                    }
                    else
                    {
                        points[polygons[i].dots[j] - 1].normal[0] += polygons[i].X;
                        points[polygons[i].dots[j] - 1].normal[1] += polygons[i].Y;
                        points[polygons[i].dots[j] - 1].normal[2] += polygons[i].Z;
                    }
                }
            }
        }
        public void StartSepPolygon(Bitmap bitmap)
        {
            int deep = Const.deepCoef;
            calculatePointNormal();
            TextureP[] textP = new TextureP[0];
            for (int i = 0; i < polygons.Length; i++)
            {
                myPoint[] arr = new myPoint[polygons[i].dots.Length];
                for (int j = 0; j < arr.Length; j++)
                    arr[j] = points[polygons[i].dots[j] - 1];
                for (int q = 0; q < polygons[i].vtInd.Count; q++)
                {
                    Array.Resize<TextureP>(ref textP, textP.Length + 1);
                    textP[textP.Length - 1] = tPoints[polygons[i].vtInd[q]];
                }
                RecurseSepPolygon(bitmap, arr, textP, deep);
            }
            
        }
        private void RecurseSepPolygon(Bitmap bitmap, myPoint[] currPoints, TextureP[] textP,  int deepCoef)
        {
            //for (int i = 0; i < textP.Length; i++)
            //{
            //    Console.WriteLine(textP[i].X.ToString() + '|' + textP[i].Y.ToString());
                
            //}
            //Console.WriteLine("______________");
                
            if (deepCoef == 0)
            {
                //отрисовка
                double[] currNormal = new double[3];
                if (currPoints.Length == 4)
                {
                    currNormal[0] = currPoints[0].normal[0] + currPoints[1].normal[0] + currPoints[2].normal[0] + currPoints[3].normal[0];
                    currNormal[1] = currPoints[0].normal[1] + currPoints[1].normal[1] + currPoints[2].normal[1] + currPoints[3].normal[1];
                    currNormal[2] = currPoints[0].normal[2] + currPoints[1].normal[2] + currPoints[2].normal[2] + currPoints[3].normal[2];
                }
                if (currPoints.Length == 3)
                {
                    currNormal[0] = currPoints[0].normal[0] + currPoints[1].normal[0] + currPoints[2].normal[0];
                    currNormal[1] = currPoints[0].normal[1] + currPoints[1].normal[1] + currPoints[2].normal[1];
                    currNormal[2] = currPoints[0].normal[2] + currPoints[1].normal[2] + currPoints[2].normal[2]; 
                }
                Point[] pp = new Point[currPoints.Length];
                for (int i = 0; i < pp.Length; i++)
                {
                    pp[i].X = Convert.ToInt32(Const.CenterX + (currPoints[i].X - (currPoints[i].Z) * Math.Cos(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
                    pp[i].Y = Convert.ToInt32(Const.CenterY - (currPoints[i].Y + (currPoints[i].Z) * Math.Sin(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
                }
                using (Graphics G = Graphics.FromImage(bitmap))
                {
                    double ang = (Const.LightV[0] * currNormal[0] + Const.LightV[1] * currNormal[1] + Const.LightV[2] * currNormal[2]) / (
                                Math.Sqrt(Math.Pow(Const.LightV[0], 2) + Math.Pow(Const.LightV[1], 2) + Math.Pow(Const.LightV[2], 2)) *
                                Math.Sqrt(Math.Pow(currNormal[0], 2)+ Math.Pow(currNormal[1], 2) + Math.Pow(currNormal[2], 2)));
                    int counter = 0;
                    double sumX = 0;
                    double sumY = 0;
                    for (int i = 0; i < textP.Length; i++)
                    {
                        sumX += textP[i].X;
                        sumY += textP[i].Y;
                        counter++;
                    }

                    TextureP tp = new TextureP((sumX / counter) * texture.Width, (sumY / counter) * texture.Height);
                    Color color = texture.GetPixel(Convert.ToInt32(tp.X), Convert.ToInt32(tp.Y));
                    if (ang >= 0)
                        G.FillPolygon(new SolidBrush(Color.FromArgb(Convert.ToInt32(color.R * ang), Convert.ToInt32(color.G * ang), Convert.ToInt32(color.B * ang))), pp);
                    else
                        G.FillPolygon(new SolidBrush(Color.FromArgb(Convert.ToInt32(140 * 0.00001), Convert.ToInt32(255 * 0.00001), Convert.ToInt32(140 * 0.00001))), pp);
                    if (Const.isNormal)
                    for (int i = 0; i < currPoints.Length; i++)
                    {
                        int x_fin = Convert.ToInt32(Const.CenterX + (currPoints[i].X - (currPoints[i].Z) * Math.Cos(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
                        int y_fin = Convert.ToInt32(Const.CenterY - (currPoints[i].Y + (currPoints[i].Z) * Math.Sin(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
                        int xN = Convert.ToInt32(Const.CenterX + (currPoints[i].normal[0] + currPoints[i].X - (currPoints[i].normal[2] + currPoints[i].Z) * Math.Cos(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
                        int yN = Convert.ToInt32(Const.CenterX + (currPoints[i].normal[1] + currPoints[i].Y - (currPoints[i].normal[2] + currPoints[i].Z) * Math.Cos(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
                        G.DrawLine(new Pen(Color.Pink), x_fin, y_fin, xN, yN);
                    }
                }
                    return;
            }
            List<myPoint> P = new List<myPoint>();
            myPoint center = new myPoint();
            center.normal = new double[3];
            center.X = 0;
            center.Y = 0;
            center.Z = 0;
                for (int i = 0; i < currPoints.Length - 1; i++)
                {
                    myPoint p = new myPoint();
                    p.X = 0.5 * currPoints[i].X + 0.5 * currPoints[i + 1].X;
                    p.Y = 0.5 * currPoints[i].Y + 0.5 * currPoints[i + 1].Y;
                    p.Z = 0.5 * currPoints[i].Z + 0.5 * currPoints[i + 1].Z;
                    p.normal = new double[3];
                    p.normal[0] = (currPoints[i].normal[0] + currPoints[i + 1].normal[0]);
                    p.normal[1] = (currPoints[i].normal[1] + currPoints[i + 1].normal[1]);
                    p.normal[2] = (currPoints[i].normal[2] + currPoints[i + 1].normal[2]);
                    double q = Math.Sqrt(Math.Pow(p.normal[0], 2) + Math.Pow(p.normal[1], 2) + Math.Pow(p.normal[2], 2));
                    p.normal[0] = p.normal[0] /(q * 10);
                    p.normal[1] = p.normal[1] / (q * 10);
                    p.normal[2] = p.normal[2] / (q * 10);
                    P.Add(p);                   
                    center.X += currPoints[i].X / 4;
                    center.Y += currPoints[i].Y / 4;
                    center.Z += currPoints[i].Z / 4;
                }
                center.X += currPoints[currPoints.Length - 1].X / 4;
                center.Y += currPoints[currPoints.Length - 1].Y / 4;
                center.Z += currPoints[currPoints.Length - 1].Z / 4;
                myPoint p1 = new myPoint();
                p1.X = 0.5 * (currPoints[currPoints.Length - 1].X + currPoints[0].X);
                p1.Y = 0.5 * (currPoints[currPoints.Length - 1].Y + currPoints[0].Y);
                p1.Z = 0.5 * (currPoints[currPoints.Length - 1].Z + currPoints[0].Z);
                p1.normal = new double[3];
                p1.normal[0] = currPoints[currPoints.Length - 1].normal[0] + currPoints[0].normal[0];
                p1.normal[1] = currPoints[currPoints.Length - 1].normal[1] + currPoints[0].normal[1];
                p1.normal[2] = currPoints[currPoints.Length - 1].normal[2] + currPoints[0].normal[2];
                double q1 = Math.Sqrt(Math.Pow(p1.normal[0], 2) + Math.Pow(p1.normal[1], 2) + Math.Pow(p1.normal[2], 2));
                p1.normal[0] /= (q1 * 10);
                p1.normal[1] /= (q1 * 10);
                p1.normal[2] /= (q1 * 10);
                P.Add(p1);
            if (currPoints.Length == 4)
            {
                center.normal[0] = currPoints[0].normal[0] + currPoints[1].normal[0] + currPoints[2].normal[0] + currPoints[3].normal[0];
                center.normal[1] = currPoints[0].normal[1] + currPoints[1].normal[1] + currPoints[2].normal[1] + currPoints[3].normal[1];
                center.normal[2] = currPoints[0].normal[2] + currPoints[1].normal[2] + currPoints[2].normal[2] + currPoints[3].normal[2];
                q1 = Math.Sqrt(Math.Pow(center.normal[0], 2) + Math.Pow(center.normal[1], 2) + Math.Pow(center.normal[2], 2));
                center.normal[0] /= (q1 * 10);
                center.normal[1] /= (q1 * 10);
                center.normal[2] /= (q1 * 10);
                TextureP centerTP = new TextureP(0.25 * (textP[0].X + textP[1].X + textP[2].X + textP[3].X), 0.25 * (textP[0].Y + textP[1].Y + textP[2].Y + textP[3].Y));
                RecurseSepPolygon(bitmap, new myPoint[] { currPoints[0], P[0], center, P[3] }, new TextureP[] {
                    textP[0],
                    new TextureP(textP[0].X * 0.5 + textP[1].X * 0.5, textP[0].Y * 0.5 + textP[1].Y * 0.5),
                    centerTP,
                    new TextureP(textP[0].X * 0.5 + textP[3].X * 0.5, textP[0].Y * 0.5 + textP[3].Y * 0.5)
                    },
                    deepCoef - 1); //влево вверх
                RecurseSepPolygon(bitmap, new myPoint[] { P[0], currPoints[1], P[1], center }, new TextureP[] {
                    new TextureP(textP[0].X * 0.5 + textP[1].X * 0.5, textP[0].Y * 0.5 + textP[1].Y * 0.5), 
                    textP[1],
                    new TextureP(textP[1].X * 0.5 + textP[2].X * 0.5, textP[1].Y * 0.5 + textP[2].Y * 0.5),
                    centerTP
                    },
                    deepCoef - 1); //вправо вверх
                RecurseSepPolygon(bitmap, new myPoint[] { center, P[1], currPoints[2], P[2] }, new TextureP[] {
                    centerTP,
                    new TextureP(textP[1].X * 0.5 + textP[2].X * 0.5, textP[1].Y * 0.5 + textP[2].Y * 0.5),
                    textP[2],
                    new TextureP(textP[2].X * 0.5 + textP[3].X * 0.5, textP[2].Y * 0.5 + textP[3].Y * 0.5)
                    },
                    deepCoef - 1); //вправо вниз
                RecurseSepPolygon(bitmap, new myPoint[] { P[3], center, P[2], currPoints[3] }, new TextureP[] {
                    new TextureP(textP[0].X * 0.5 + textP[3].X * 0.5, textP[0].Y * 0.5 + textP[3].Y * 0.5),
                    centerTP,
                    new TextureP(textP[2].X * 0.5 + textP[3].X * 0.5, textP[2].Y * 0.5 + textP[3].Y * 0.5),
                    textP[3]
                    }, 
                    deepCoef - 1); //влево вниз
            }
            if (currPoints.Length == 3)
            {
                RecurseSepPolygon(bitmap, new myPoint[] { currPoints[0], P[0], P[2] }, new TextureP[] {
                    textP[0],
                    new TextureP((textP[0].X + textP[1].X) * 0.5, (textP[0].Y + textP[1].Y) * 0.5),
                    new TextureP((textP[0].X + textP[2].X) * 0.5, (textP[0].Y + textP[2].Y) * 0.5)
                    
                    
                    
                },
                    deepCoef - 1); //вверх
                RecurseSepPolygon(bitmap, new myPoint[] { P[0], currPoints[1], P[1] }, new TextureP[] {
                    new TextureP((textP[0].X + textP[1].X) * 0.5, (textP[0].Y + textP[1].Y) * 0.5),
                    textP[1],
                    new TextureP((textP[1].X + textP[2].X) * 0.5, (textP[1].Y + textP[2].Y) * 0.5)
                    

                    }, 
                    deepCoef - 1); //вправо вниз
                RecurseSepPolygon(bitmap, new myPoint[] { P[2], P[1], currPoints[2] }, new TextureP[] {
                    new TextureP((textP[0].X + textP[2].X) * 0.5, (textP[0].Y + textP[2].Y) * 0.5),
                    new TextureP((textP[1].X + textP[2].X) * 0.5, (textP[1].Y + textP[2].Y) * 0.5),
                    textP[2]

                    }, 
                    deepCoef - 1); //влево вниз
                RecurseSepPolygon(bitmap, new myPoint[] { P[2], P[0], P[1] }, new TextureP[] {
                    new TextureP((textP[0].X + textP[2].X) * 0.5, (textP[0].Y + textP[2].Y) * 0.5),
                    new TextureP((textP[0].X + textP[1].X) * 0.5, (textP[0].Y + textP[1].Y) * 0.5),
                    new TextureP((textP[1].X + textP[2].X) * 0.5, (textP[1].Y + textP[2].Y) * 0.5),
                    
                    }, 
                    deepCoef - 1); //центр
            }
        }


        #region DRAW
        public void Draw(Bitmap DrawOn, string coefControl, bool isFill, bool edgeMod, bool pointsOn)
        {
            using (Graphics G = Graphics.FromImage(DrawOn))
            {
                double x;
                double y;
                double z;
                int x_fin;
                int y_fin;
                G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                G.Clear(Color.Black);
                y = polygons[0].Y;
                x = polygons[0].X;
                z = polygons[0].Z;
                int xx = Convert.ToInt32((Const.LightV[0] + x - (Const.LightV[2] + z) * Math.Cos(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
                int yy = Convert.ToInt32((Const.LightV[1] + y + (Const.LightV[2] + z) * Math.Sin(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
                //G.DrawLine(new Pen(Color.Red), 1, 1, Convert.ToInt32((x + (z) * Math.Sin(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst), Convert.ToInt32((y + (z) * Math.Sin(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst));
                //G.DrawLine(new Pen(Color.Red), Convert.ToInt32((x + (z) * Math.Sin(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst), Convert.ToInt32( (y + (z) * Math.Sin(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst), 1 + xx, 1 + yy);
                if (polygons != null)
                {
                    if (isFill)
                        if (Const.soft)
                        {
                            StartSepPolygon(DrawOn);
                        }
                        else
                            for (int i = 0; i < polygons.Length; i++)
                            {
                                x = polygons[i].X;
                                y = polygons[i].Y;
                                z = polygons[i].Z;
                                Color color = centerPoint(polygons[i].vtInd.ToArray());
                                
                                x_fin = Convert.ToInt32(Const.CenterX + (x - (z) * Math.Cos(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
                                y_fin = Convert.ToInt32(Const.CenterY - (y + (z) * Math.Sin(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
                                double ang = /*Math.Acos(*/(Const.LightV[0] * polygons[i].X + Const.LightV[1] * polygons[i].Y + Const.LightV[2] * polygons[i].Z) / (
                                    Math.Sqrt(Math.Pow(Const.LightV[0], 2) + Math.Pow(Const.LightV[1], 2) + Math.Pow(Const.LightV[2], 2)) *
                                    Math.Sqrt(polygons[i].X * polygons[i].X + polygons[i].Y * polygons[i].Y + polygons[i].Z * polygons[i].Z))/*)*/;
                                if (ang >= 0)
                                    G.FillPolygon(new SolidBrush(Color.FromArgb(Convert.ToInt32(color.R * ang), Convert.ToInt32(color.G * ang), Convert.ToInt32(color.B * ang))), toArr(i));
                                else
                                    G.FillPolygon(new SolidBrush(Color.FromArgb(Convert.ToInt32(140 * 0.00001), Convert.ToInt32(255 * 0.00001), Convert.ToInt32(140 * 0.00001))), toArr(i));
                            }
                    else
                        if (edgeMod)
                        for (int i = 0; i < polygons.Length; i++)
                        {
                            G.DrawPolygon(new Pen(Color.AliceBlue), toArr(i));
                        }
                }

                if (pointsOn)
                    for (int i = 0; i < points.Length; i++)
                    {
                        x = points[i].X;
                        y = points[i].Y;
                        z = points[i].Z;
                        x_fin = Convert.ToInt32(Const.CenterX + (x - (z) * Math.Cos(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
                        y_fin = Convert.ToInt32(Const.CenterY - (y + (z) * Math.Sin(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
                        //G.FillEllipse(new SolidBrush(Color.Aquamarine), x_fin, y_fin, 1, 1);
                        G.DrawEllipse(new Pen(Color.SlateGray), x_fin, y_fin, 1, 1);
                    }
                if (Const.isNormal)
                    for (int i = 0; i < polygons.Length; i++)
                    {
                        int x_fin1 = 0;
                        int y_fin1 = 0;
                        int x_fin2 = 0;
                        int y_fin2 = 0;
                        DrawNormals(out x_fin1, out y_fin1, out x_fin2, out y_fin2, i);
                        G.DrawLine(new Pen(Color.Pink), x_fin1, y_fin1, x_fin2, y_fin2);
                    }
                //if (f.currModel.polygons != null)
                //{
                //    G.DrawPolygon(new Pen(Color.AliceBlue), );
                //}   
            }
        }

        private Color centerPoint(int[] IND)
        {
            int counter = 0;
            double sumX = 0;
            double sumY = 0;
            for (int i = 0; i < IND.Length; i++)
            {
                sumX += tPoints[IND[i]].X;
                sumY += tPoints[IND[i]].Y;
                counter++;
            }
            TextureP tp = new TextureP((sumX / counter) * texture.Width, (sumY / counter) * texture.Height);
            Color color = texture.GetPixel(Convert.ToInt32(tp.X), Convert.ToInt32(tp.Y));
            return color;
        }
        private void DrawNormals(out int x_fin1, out int y_fin1, out int x_fin2, out int y_fin2, int i)
        {

            double x2 = polygons[i].X * 10 + polygons[i].center[0];
            double y2 = polygons[i].Y * 10 + polygons[i].center[1];
            double z2 = polygons[i].Z * 10 + polygons[i].center[2];
            x_fin1 = Convert.ToInt32(Const.CenterX + (polygons[i].center[0] - (polygons[i].center[2]) * Math.Cos(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
            y_fin1 = Convert.ToInt32(Const.CenterY - (polygons[i].center[1] + (polygons[i].center[2]) * Math.Sin(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
            x_fin2 = Convert.ToInt32(Const.CenterX + (x2 - (z2) * Math.Cos(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
            y_fin2 = Convert.ToInt32(Const.CenterY - (y2 + (z2) * Math.Sin(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
        }
        private Point[] toArr(int t)
        {
            double x;
            double y;
            double z;
            Point[] p = new Point[0];
            for (int i = 0; i < polygons[t].dots.Length; i++)
            {
                Array.Resize<Point>(ref p, p.Length + 1);
                x = (points[polygons[t].dots[i] - 1].X);
                y = (points[polygons[t].dots[i] - 1].Y);
                z = (points[polygons[t].dots[i] - 1].Z);
                p[p.Length - 1].X = Convert.ToInt32(Const.CenterX + (x - (z) * Math.Cos(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);
                p[p.Length - 1].Y = Convert.ToInt32(Const.CenterY - (y + (z) * Math.Sin(Const.Angl / 180.0 * Math.PI) / 2.0) * Const.zoomConst);

            }
            return p;
        }
        #endregion

    }
}
