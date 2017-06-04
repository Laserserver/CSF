using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;
using System.Windows.Controls;
using System.Windows.Media;

namespace Icosaedr
{
    public static class Drawer
    {
        private static Vector3D zero = new Vector3D(0, 0, 0);
        private static Vector3D xV = new Vector3D(2, 0, 0);
        private static Vector3D yV = new Vector3D(0, -2, 0);
        private static Vector3D zV = new Vector3D(0, 0, 2 );
        private static Line xVLine;
        private static Line yVLine;
        private static Line zVLine;
        private static List<Line> lines=new List<Line>();
        public static double CamX=30, CamY=0, CamZ=-30;
        private static double MaxDepth=0, MinDepth=0, focus;

        public static void Draw(Canvas canv)
        {
            canv.Children.Clear();
            lines.Clear();
            FindMinMaxDepth();

            xVLine=DrawLine(zero, AffineTransforms.RotateXYZ(CamX, CamY, CamZ, xV), canv, false, Brushes.Gray);
            yVLine=DrawLine(zero, AffineTransforms.RotateXYZ(CamX, CamY, CamZ, yV), canv, false, Brushes.Gray);
            zVLine=DrawLine(zero, AffineTransforms.RotateXYZ(CamX, CamY, CamZ, zV), canv, false, Brushes.Gray);

            foreach (List<int> gr in ModelStorage.flist)
            {
                for(int i=0;i<gr.Count;i++)
                {
                    Vector3D v1;
                    if (i>0) v1 = ModelStorage.vlist[gr[i - 1]-1];
                    else v1 = ModelStorage.vlist[gr[gr.Count - 1] - 1];
                    Vector3D v2 = ModelStorage.vlist[gr[i]-1];
                    v1 = AffineTransforms.RotateXYZ(CamX, CamY, CamZ, v1);
                    v2 = AffineTransforms.RotateXYZ(CamX, CamY, CamZ, v2);
                    lines.Add(DrawLine(v1, v2, canv, true, Brushes.Black));              
                }
            }
        }
        public static void Update(Canvas canv)
        {
            FindMinMaxDepth();

            UpdateLine(xVLine,zero, AffineTransforms.RotateXYZ(CamX, CamY, CamZ, xV), canv, false, Brushes.Gray);
            UpdateLine(yVLine, zero,AffineTransforms.RotateXYZ(CamX, CamY, CamZ, yV), canv, false, Brushes.Gray);
            UpdateLine(zVLine, zero, AffineTransforms.RotateXYZ(CamX, CamY, CamZ, zV), canv, false, Brushes.Gray);
            int index = 0;
            foreach (List<int> gr in ModelStorage.flist)
            {
                for (int i = 0; i < gr.Count; i++)
                {
                    Vector3D v1;
                    if (i > 0) v1 = ModelStorage.vlist[gr[i - 1] - 1];
                    else v1 = ModelStorage.vlist[gr[gr.Count - 1] - 1];
                    Vector3D v2 = ModelStorage.vlist[gr[i] - 1];
                    v1 = AffineTransforms.RotateXYZ(CamX, CamY, CamZ, v1);
                    v2 = AffineTransforms.RotateXYZ(CamX, CamY, CamZ, v2);
                    UpdateLine(lines[index], v1, v2, canv, true, Brushes.Black);
                    index++;
                }
            }
        }
        private static Line DrawLine(Vector3D v1, Vector3D v2, Canvas canv, bool perspective, Brush brush)
        {
            Line l = new Line();
            UpdateLine(l, v1,v2,canv,perspective,brush);
            canv.Children.Add(l);
            return l;
        }
        public static void UpdateLine(Line l, Vector3D v1, Vector3D v2, Canvas canv, bool perspective, Brush brush)
        {
            l.HorizontalAlignment = HorizontalAlignment.Left;
            l.VerticalAlignment = VerticalAlignment.Top;
            l.X1 = ConvertX(v1.X, v1.Y, canv.Width / 2, perspective);
            l.Y1 = ConvertY(v1.Z, v1.Y, canv.Height / 2, perspective);
            l.X2 = ConvertX(v2.X, v2.Y, canv.Width / 2, perspective);
            l.Y2 = ConvertY(v2.Z, v2.Y, canv.Height / 2, perspective);
            l.Stroke = brush;
            l.StrokeThickness = 1;
        }
        private static double ConvertX(double x, double depth, double center, bool perspective)
        {
            double k;
            if (perspective) k = (focus - depth) / (focus - MinDepth);
            else k = 1;
            return x * Settings.zoom*k + center;
        }
        private static double ConvertY(double y, double depth, double center, bool perspective)
        {
            double k;
            if (perspective) k = (focus - depth) / (focus - MinDepth);
            else k = 1;
            return -y * Settings.zoom * k + center;
        }
        private static void FindMinMaxDepth()
        {
            MaxDepth = 0;
            MinDepth = 0;
            foreach (List<int> gr in ModelStorage.flist)
            {
                for (int i = 0; i < gr.Count; i++)
                {
                    Vector3D v1 = ModelStorage.vlist[gr[i] - 1];
                    if (v1.Y < MinDepth) MinDepth = v1.Y;
                    if (v1.Y > MaxDepth) MaxDepth = v1.Y;
                }
            }
            focus = (MaxDepth - MinDepth)*4;
        }
    }
}
