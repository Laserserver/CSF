// ================================================
// | Downloaded From                              |
// | Visual C# Kicks - http://www.vcskicks.com/   |
// ================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace EulerRotation
{
    public partial class Form1 : Form
    {
        Cube cube;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tX.Value = 0;
            tY.Value = 0;
            tZ.Value = 0;
            render();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cube = new Cube(100);
            render();
        }

        private void render()
        {
            //Set the rotation values
            cube.RotateX = tX.Value;
            cube.RotateY = tY.Value;
            cube.RotateZ = tZ.Value;

            //Cube is positioned based on center
            Point origin = new Point(picCube.Width / 2, picCube.Height / 2);

            picCube.Image = cube.drawCube(origin);
        }

        private void tX_Scroll(object sender, EventArgs e)
        {
            render();
        }

        private void tY_Scroll(object sender, EventArgs e)
        {
            render();
        }

        private void tZ_Scroll(object sender, EventArgs e)
        {
            render();
        }
    }

    internal class Math3D
    {
        public class Point3D
        {
            //The Point3D class is rather simple, just keeps track of X Y and Z values,
            //and being a class it can be adjusted to be comparable
            public double X;
            public double Y;
            public double Z;

            public Point3D(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public Point3D(float x, float y, float z)
            {
                X = (double)x;
                Y = (double)y;
                Z = (double)z;
            }

            public Point3D(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public Point3D()
            {
            }

            public override string ToString()
            {
                return "(" + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
            }
        }

        public class Camera
        {
            //For 3D drawing we need a point of perspective, thus the Camera
            public Point3D Position = new Point3D();
        }

        public static Point3D RotateX(Point3D point3D, double degrees)
        {
            //Here we use Euler's matrix formula for rotating a 3D point x degrees around the x-axis

            //[ a  b  c ] [ x ]   [ x*a + y*b + z*c ]
            //[ d  e  f ] [ y ] = [ x*d + y*e + z*f ]
            //[ g  h  i ] [ z ]   [ x*g + y*h + z*i ]

            //[ 1    0        0   ]
            //[ 0   cos(x)  sin(x)]
            //[ 0   -sin(x) cos(x)]

            double cDegrees = (Math.PI * degrees) / 180.0f; //Convert degrees to radian for .Net Cos/Sin functions
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            double y = (point3D.Y * cosDegrees) + (point3D.Z * sinDegrees);
            double z = (point3D.Y * -sinDegrees) + (point3D.Z * cosDegrees);

            return new Point3D(point3D.X, y, z);
        }

        public static Point3D RotateY(Point3D point3D, double degrees)
        {
            //Y-axis

            //[ cos(x)   0    sin(x)]
            //[   0      1      0   ]
            //[-sin(x)   0    cos(x)]

            double cDegrees = (Math.PI * degrees) / 180.0; //Radians
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            double x = (point3D.X * cosDegrees) + (point3D.Z * sinDegrees);
            double z = (point3D.X * -sinDegrees) + (point3D.Z * cosDegrees);

            return new Point3D(x, point3D.Y, z);
        }

        public static Point3D RotateZ(Point3D point3D, double degrees)
        {
            //Z-axis

            //[ cos(x)  sin(x) 0]
            //[ -sin(x) cos(x) 0]
            //[    0     0     1]

            double cDegrees = (Math.PI * degrees) / 180.0; //Radians
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            double x = (point3D.X * cosDegrees) + (point3D.Y * sinDegrees);
            double y = (point3D.X * -sinDegrees) + (point3D.Y * cosDegrees);

            return new Point3D(x, y, point3D.Z);
        }

        public static Point3D Translate(Point3D points3D, Point3D oldOrigin, Point3D newOrigin)
        {
            //Moves a 3D point based on a moved reference point
            Point3D difference = new Point3D(newOrigin.X - oldOrigin.X, newOrigin.Y - oldOrigin.Y, newOrigin.Z - oldOrigin.Z);
            points3D.X += difference.X;
            points3D.Y += difference.Y;
            points3D.Z += difference.Z;
            return points3D;
        }

        //These are to make the above functions workable with arrays of 3D points
        public static Point3D[] RotateX(Point3D[] points3D, double degrees)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = RotateX(points3D[i], degrees);
            }
            return points3D;
        }

        public static Point3D[] RotateY(Point3D[] points3D, double degrees)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = RotateY(points3D[i], degrees);
            }
            return points3D;
        }

        public static Point3D[] RotateZ(Point3D[] points3D, double degrees)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = RotateZ(points3D[i], degrees);
            }
            return points3D;
        }

        public static Point3D[] Translate(Point3D[] points3D, Point3D oldOrigin, Point3D newOrigin)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = Translate(points3D[i], oldOrigin, newOrigin);
            }
            return points3D;
        }

    }

    internal class Cube
    {
        //Example cube class to demonstrate the use of 3D points and 3D rotation

        public int width = 0;
        public int height = 0;
        public int depth = 0;

        double xRotation = 0.0;
        double yRotation = 0.0;
        double zRotation = 0.0;

        Math3D.Camera camera1 = new Math3D.Camera();
        Math3D.Point3D cubeOrigin;

        public double RotateX
        {
            get { return xRotation; }
            set { xRotation = value; }
        }

        public double RotateY
        {
            get { return yRotation; }
            set { yRotation = value; }
        }

        public double RotateZ
        {
            get { return zRotation; }
            set { zRotation = value; }
        }

        public Cube(int side)
        {
            width = side;
            height = side;
            depth = side;
            cubeOrigin = new Math3D.Point3D(width / 2, height / 2, depth / 2);
        }

        public Cube(int side, Math3D.Point3D origin)
        {
            width = side;
            height = side;
            depth = side;
            cubeOrigin = origin;
        }

        public Cube(int Width, int Height, int Depth)
        {
            width = Width;
            height = Height;
            depth = Depth;
            cubeOrigin = new Math3D.Point3D(width / 2, height / 2, depth / 2);
        }

        public Cube(int Width, int Height, int Depth, Math3D.Point3D origin)
        {
            width = Width;
            height = Height;
            depth = Depth;
            cubeOrigin = origin;
        }

        //Finds the othermost points. Used so when the cube is drawn on a bitmap,
        //the bitmap will be the correct size
        public static Rectangle getBounds(PointF[] points)
        {
            double left = points[0].X;
            double right = points[0].X;
            double top = points[0].Y;
            double bottom = points[0].Y;
            for (int i = 1; i < points.Length; i++)
            {
                if (points[i].X < left)
                    left = points[i].X;
                if (points[i].X > right)
                    right = points[i].X;
                if (points[i].Y < top)
                    top = points[i].Y;
                if (points[i].Y > bottom)
                    bottom = points[i].Y;
            }

            return new Rectangle(0, 0, (int)Math.Round(right - left), (int)Math.Round(bottom - top));
        }

        public Bitmap drawCube(Point drawOrigin)
        {
            //FRONT FACE
            //Top Left - 7
            //Top Right - 4
            //Bottom Left - 6
            //Bottom Right - 5

            //Vars
            PointF[] point3D = new PointF[24]; //Will be actual 2D drawing points
            Point tmpOrigin = new Point(0, 0);

            Math3D.Point3D point0 = new Math3D.Point3D(0, 0, 0); //Used for reference

            //Zoom factor is set with the monitor width to keep the cube from being distorted
            double zoom = (double)Screen.PrimaryScreen.Bounds.Width / 1.5;

            //Set up the cube
            Math3D.Point3D[] cubePoints = fillCubeVertices(width, height, depth);

            //Calculate the camera Z position to stay constant despite rotation            
            Math3D.Point3D anchorPoint = (Math3D.Point3D)cubePoints[4]; //anchor point
            double cameraZ = -(((anchorPoint.X - cubeOrigin.X) * zoom) / cubeOrigin.X) + anchorPoint.Z;
            camera1.Position = new Math3D.Point3D(cubeOrigin.X, cubeOrigin.Y, cameraZ);            

            //Apply Rotations, moving the cube to a corner then back to middle
            cubePoints = Math3D.Translate(cubePoints, cubeOrigin, point0);
            cubePoints = Math3D.RotateX(cubePoints, xRotation); //The order of these
            cubePoints = Math3D.RotateY(cubePoints, yRotation); //rotations is the source
            cubePoints = Math3D.RotateZ(cubePoints, zRotation); //of Gimbal Lock
            cubePoints = Math3D.Translate(cubePoints, point0, cubeOrigin);

            //Convert 3D Points to 2D
            Math3D.Point3D vec;
            for (int i = 0; i < point3D.Length; i++)
            {
                vec = cubePoints[i];
                if (vec.Z - camera1.Position.Z >= 0)
                {
                    point3D[i].X = (int)((double)-(vec.X - camera1.Position.X) / (-0.1f) * zoom) + drawOrigin.X;
                    point3D[i].Y = (int)((double)(vec.Y - camera1.Position.Y) / (-0.1f) * zoom) + drawOrigin.Y;
                }
                else
                {
                    tmpOrigin.X = (int)((double)(cubeOrigin.X - camera1.Position.X) / (double)(cubeOrigin.Z - camera1.Position.Z) * zoom) + drawOrigin.X;
                    tmpOrigin.Y = (int)((double)-(cubeOrigin.Y - camera1.Position.Y) / (double)(cubeOrigin.Z - camera1.Position.Z) * zoom) + drawOrigin.Y;

                    point3D[i].X = (float)((vec.X - camera1.Position.X) / (vec.Z - camera1.Position.Z) * zoom + drawOrigin.X);
                    point3D[i].Y = (float)(-(vec.Y - camera1.Position.Y) / (vec.Z - camera1.Position.Z) * zoom + drawOrigin.Y);

                    point3D[i].X = (int)point3D[i].X;
                    point3D[i].Y = (int)point3D[i].Y;
                }
            }

            //Now to plot out the points
            Rectangle bounds = getBounds(point3D);
            bounds.Width += drawOrigin.X;
            bounds.Height += drawOrigin.Y;

            Bitmap tmpBmp = new Bitmap(bounds.Width, bounds.Height);
            Graphics g = Graphics.FromImage(tmpBmp);

            //Back Face
            g.DrawLine(Pens.Black, point3D[0], point3D[1]);
            g.DrawLine(Pens.Black, point3D[1], point3D[2]);
            g.DrawLine(Pens.Black, point3D[2], point3D[3]);
            g.DrawLine(Pens.Black, point3D[3], point3D[0]);

            //Front Face
            g.DrawLine(Pens.Black, point3D[4], point3D[5]);
            g.DrawLine(Pens.Black, point3D[5], point3D[6]);
            g.DrawLine(Pens.Black, point3D[6], point3D[7]);
            g.DrawLine(Pens.Black, point3D[7], point3D[4]);

            //Right Face
            g.DrawLine(Pens.Black, point3D[8], point3D[9]);
            g.DrawLine(Pens.Black, point3D[9], point3D[10]);
            g.DrawLine(Pens.Black, point3D[10], point3D[11]);
            g.DrawLine(Pens.Black, point3D[11], point3D[8]);

            //Left Face
            g.DrawLine(Pens.Black, point3D[12], point3D[13]);
            g.DrawLine(Pens.Black, point3D[13], point3D[14]);
            g.DrawLine(Pens.Black, point3D[14], point3D[15]);
            g.DrawLine(Pens.Black, point3D[15], point3D[12]);

            //Bottom Face
            g.DrawLine(Pens.Black, point3D[16], point3D[17]);
            g.DrawLine(Pens.Black, point3D[17], point3D[18]);
            g.DrawLine(Pens.Black, point3D[18], point3D[19]);
            g.DrawLine(Pens.Black, point3D[19], point3D[16]);

            //Top Face
            g.DrawLine(Pens.Black, point3D[20], point3D[21]);
            g.DrawLine(Pens.Black, point3D[21], point3D[22]);
            g.DrawLine(Pens.Black, point3D[22], point3D[23]);
            g.DrawLine(Pens.Black, point3D[23], point3D[20]);

            g.Dispose(); //Clean-up

            return tmpBmp;
        }

        public static Math3D.Point3D[] fillCubeVertices(int width, int height, int depth)
        {
            Math3D.Point3D[] verts = new Math3D.Point3D[24];

            //front face
            verts[0] = new Math3D.Point3D(0, 0, 0);
            verts[1] = new Math3D.Point3D(0, height, 0);
            verts[2] = new Math3D.Point3D(width, height, 0);
            verts[3] = new Math3D.Point3D(width, 0, 0);

            //back face
            verts[4] = new Math3D.Point3D(0, 0, depth);
            verts[5] = new Math3D.Point3D(0, height, depth);
            verts[6] = new Math3D.Point3D(width, height, depth);
            verts[7] = new Math3D.Point3D(width, 0, depth);

            //left face
            verts[8] = new Math3D.Point3D(0, 0, 0);
            verts[9] = new Math3D.Point3D(0, 0, depth);
            verts[10] = new Math3D.Point3D(0, height, depth);
            verts[11] = new Math3D.Point3D(0, height, 0);

            //right face
            verts[12] = new Math3D.Point3D(width, 0, 0);
            verts[13] = new Math3D.Point3D(width, 0, depth);
            verts[14] = new Math3D.Point3D(width, height, depth);
            verts[15] = new Math3D.Point3D(width, height, 0);

            //top face
            verts[16] = new Math3D.Point3D(0, height, 0);
            verts[17] = new Math3D.Point3D(0, height, depth);
            verts[18] = new Math3D.Point3D(width, height, depth);
            verts[19] = new Math3D.Point3D(width, height, 0);

            //bottom face
            verts[20] = new Math3D.Point3D(0, 0, 0);
            verts[21] = new Math3D.Point3D(0, 0, depth);
            verts[22] = new Math3D.Point3D(width, 0, depth);
            verts[23] = new Math3D.Point3D(width, 0, 0);

            return verts;
        }
    }
}