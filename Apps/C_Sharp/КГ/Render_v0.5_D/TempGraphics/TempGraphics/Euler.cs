using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TempGraphics
{
  internal class Math3D
  {
    public double Zoom;
    public class Point3D
    {
      public double X, Y, Z;
      public Point3D(double X, double Y, double Z)
      {
        this.Z = Z;
        this.X = X;
        this.Y = Y;
      }
      public Point3D(float x, float y, float z)
      {
        X = x;
        Y = y;
        Z = z;
      }
      public Point3D()
      {
      }
    }

    public Math3D()
    {
      
    }
    public class Camera
    {
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
  internal class Model3D
  {
    Math3D.Point3D[] Points;
    Edge3D[] Edges;
    Polygon3D[] Polygons;
    public Math3D Mathes;
    public int Width, Height;
    Math3D.Camera Cam;
    int PLength;
    int ELength;
    int RLength;
    public Math3D.Point3D Origin;
    double xRotation = 0.0;
    double yRotation = 0.0;
    double zRotation = 0.0;
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

    public Model3D()
    {
      Points = new Math3D.Point3D[0];
      Edges = new Edge3D[0];
      Mathes = new Math3D();
      Cam = new Math3D.Camera();
      Polygons = new Polygon3D[0];
      PLength = ELength = RLength = 0;
    }
    public class Edge3D
    {
      public int F, S;
      public Edge3D(int F, int S)
      {
        this.F = F;
        this.S = S;
      }
    }
    public class Polygon3D : Edge3D
    {
      int T;
      public Polygon3D(int F, int S, int T) : base(F, S)
      {
        this.F = F;
        this.S = S;
        this.T = T;
      }
    }
    public void Parse(string Input)
    {
      double AllX = 0, AllY = 0, AllZ = 0;
      double X, Y, Z;
      string[] Arr = Input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
      int Length = Arr.Length;
      string[] Row;
      for (int i = 0; i < Length; i++)
      {
        if (Arr[i] != "" && Arr[i][0] != '#')
          switch (Arr[i].Substring(0, 2))
          {
            case "v ":
              Row = Arr[i].Split(null as string[], StringSplitOptions.RemoveEmptyEntries);
              Array.Resize(ref Points, ++PLength);
              X = double.Parse(Row[1], System.Globalization.CultureInfo.InvariantCulture);
              Y = double.Parse(Row[2], System.Globalization.CultureInfo.InvariantCulture);
              Z = double.Parse(Row[3], System.Globalization.CultureInfo.InvariantCulture);
              AllX += X;
              AllY += Y;
              AllZ += Z;
              Points[PLength - 1] = new Math3D.Point3D(X, Y, Z);
              break;
            case "f ":
              Row = Arr[i].Split(' ');
              string[] Temp;
              int[] F = new int[3];
              for (int k = 1; k <= 3; k++)
              {
                Temp = Row[k].Split('/');
                F[k - 1] = int.Parse(Temp[0]);
              }
              Array.Resize(ref Polygons, ++RLength);
              Polygons[RLength - 1] = new Polygon3D(F[0], F[1], F[2]);
              Array.Resize(ref Edges, ELength + 3);
              ELength += 3;
              Edges[ELength - 3] = new Edge3D(F[0], F[1]);
              Edges[ELength - 2] = new Edge3D(F[1], F[2]);
              Edges[ELength - 1] = new Edge3D(F[2], F[0]);
              break;
          }
      }
      Origin = new Math3D.Point3D(AllX / PLength, AllY / PLength, AllZ / PLength);
    }
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
      PointF[] point3D = new PointF[PLength]; //Will be actual 2D drawing points
      Point tmpOrigin = new Point(0, 0);

      Math3D.Point3D point0 = new Math3D.Point3D(0, 0, 0); //Used for reference
      

      //Calculate the camera Z position to stay constant despite rotation            
      Math3D.Point3D anchorPoint = Points[4]; //anchor point
      double cameraZ = -(((anchorPoint.X - Origin.X) * Mathes.Zoom) / Origin.X) + anchorPoint.Z;
      Cam.Position = new Math3D.Point3D(Origin.X, Origin.Y, cameraZ);

      //Apply Rotations, moving the cube to a corner then back to middle
      Points = Math3D.Translate(Points, Origin, point0);
      Points = Math3D.RotateX(Points, xRotation); //The order of these
      Points = Math3D.RotateY(Points, yRotation); //rotations is the source
      Points = Math3D.RotateZ(Points, zRotation); //of Gimbal Lock
      Points = Math3D.Translate(Points, point0, Origin);

      //Convert 3D Points to 2D
      Math3D.Point3D vec;
      for (int i = 0; i < PLength; i++)
      {
        vec = Points[i];
        if (vec.Z - Cam.Position.Z >= 0)
        {
          point3D[i].X = (int)((double)-(vec.X - Cam.Position.X) / (-0.1f) * Mathes.Zoom) + drawOrigin.X;
          point3D[i].Y = (int)((double)(vec.Y - Cam.Position.Y) / (-0.1f) * Mathes.Zoom) + drawOrigin.Y;
        }
        else
        {
          tmpOrigin.X = (int)((double)(Origin.X - Cam.Position.X) / (double)(Origin.Z - Cam.Position.Z) * Mathes.Zoom) + drawOrigin.X;
          tmpOrigin.Y = (int)((double)-(Origin.Y - Cam.Position.Y) / (double)(Origin.Z - Cam.Position.Z) * Mathes.Zoom) + drawOrigin.Y;

          point3D[i].X = (float)((vec.X - Cam.Position.X) / (vec.Z - Cam.Position.Z) * Mathes.Zoom + drawOrigin.X);
          point3D[i].Y = (float)(-(vec.Y - Cam.Position.Y) / (vec.Z - Cam.Position.Z) * Mathes.Zoom + drawOrigin.Y);

          point3D[i].X = (int)point3D[i].X;
          point3D[i].Y = (int)point3D[i].Y;
        }
      }

      //Now to plot out the points
      /*Rectangle bounds = getBounds(point3D);
      bounds.Width += drawOrigin.X;
      bounds.Height += drawOrigin.Y;*/

      Bitmap tmpBmp = new Bitmap(Width, Height);
      Graphics g = Graphics.FromImage(tmpBmp);

      for (int i = 0; i < ELength; i++)
      {
        g.DrawLine(Pens.White, point3D[Edges[i].F - 1], point3D[Edges[i].S - 1]);
      }
      g.Dispose(); //Clean-up

      return tmpBmp;
    }
  }
}
