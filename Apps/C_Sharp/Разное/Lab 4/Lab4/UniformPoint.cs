using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    public struct UniformPoint
    {
        double[] coordinates;
        public UniformPoint(UniformPoint p)
        {
            coordinates = new double[4];
            p.coordinates.CopyTo(coordinates, 0);
        }
        public UniformPoint(double x, double y, double z, double w)
        {
            coordinates = new double[4];
            coordinates[0] = x;
            coordinates[1] = y;
            coordinates[2] = z;
            coordinates[3] = w;
        }
        public void Shift(double dx, double dy, double dz)
        {
            coordinates[0] += dx;
            coordinates[1] = dy - coordinates[1];
            coordinates[2] += dz;
        }
        public void Transform(double[][] t, ref UniformPoint p)
        {
            p.coordinates = Matrix.VectorMatrixMlp(coordinates, t, 4);
        }
        public void Transform(double[][] t)
        {
            coordinates = Matrix.VectorMatrixMlp(coordinates, t, 4);
        }
        public float GetX()
        {
            return (float)coordinates[0];
        }        
        public float GetY()
        {
            return (float)coordinates[1];
        }
        public float GetZ()
        {
            return (float)coordinates[2];
        }
        public int GetIX()
        {
            return (int)Math.Round(coordinates[0]);
        }
        public int GetIY()
        {
            return (int)Math.Round(coordinates[1]);
        }
        public int GetIZ()
        {
            return (int)Math.Round(coordinates[2]);
        }
        public void MakePerspectiveTransformation(double d)
        {
           coordinates[0] = coordinates[0] * d / coordinates[2];
           coordinates[1] = coordinates[1] * d / coordinates[2];
        }
        public static UniformPoint operator -(UniformPoint a, UniformPoint b)
        {
            UniformPoint ret = new UniformPoint(0, 0, 0, 1);
            for (int i = 0; i < 3; i++)
                ret.coordinates[i] = a.coordinates[i] - b.coordinates[i];
            return ret;
        }
        public static double Sqr(double x)
        {
            return x * x;
        }
        public double Abs()
        {
            return Math.Sqrt(Sqr(coordinates[0]) + Sqr(coordinates[1]) + Sqr(coordinates[2]));
        }
        public static UniformPoint CrossProduct(UniformPoint a, UniformPoint b)
        {
            double x1 = a.coordinates[0];
            double y1 = a.coordinates[1];
            double z1 = a.coordinates[2];
            double x2 = b.coordinates[0];
            double y2 = b.coordinates[1];
            double z2 = b.coordinates[2];
            return new UniformPoint(y1 * z2 - y2 * z1, z1 * x2 - x1 * z2, x1 * y2 - y1 * x2, 1);
        }
        public void Normalize()
        {
            double abs = this.Abs();
            for (int i = 0; i < 3; i++)
                coordinates[i] /= abs;
        }
        public static double DotProduct(UniformPoint a, UniformPoint b)
        {
            double ret = 0;
            for (int i = 0; i < 3; i++)
                ret += a.coordinates[i] * b.coordinates[i];
            return ret;
        }
    }
}
