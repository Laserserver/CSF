using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Icosaedr
{
    public static class AffineTransforms
    {
        public static Vector3D RotateX(double angle,  Vector3D vector)
        {
            double[,] matrix = new double[3, 3] { { 1, 0, 0 }, { 0, Math.Cos(ToRadian(angle)), -Math.Sin(ToRadian(angle)) }, { 0, Math.Sin(ToRadian(angle)), Math.Cos(ToRadian(angle)) } };
            MultiplyVectorByMatrix(ref vector, matrix);
            return vector;
        }
        public static Vector3D RotateY(double angle,  Vector3D vector)
        {
            double[,] matrix = new double[3, 3] { { Math.Cos(ToRadian(angle)), 0, Math.Sin(ToRadian(angle)) }, { 0, 1, 0 }, { -Math.Sin(ToRadian(angle)), 0, Math.Cos(ToRadian(angle)) } };
            MultiplyVectorByMatrix(ref vector, matrix);
            return vector;
        }
        public static Vector3D RotateZ(double angle,  Vector3D vector)
        {
            double[,] matrix = new double[3, 3] { { Math.Cos(ToRadian(angle)), -Math.Sin(ToRadian(angle)), 0 }, { Math.Sin(ToRadian(angle)), Math.Cos(ToRadian(angle)),0 }, { 0, 0, 1 } };
            MultiplyVectorByMatrix(ref vector, matrix);
            return vector;
        }
        public static Vector3D RotateXYZ(double x, double y, double z, Vector3D vector)
        {
            vector = RotateZ(z, vector);
            vector = RotateX(x, vector);
            vector = RotateY(y, vector);
            
            return vector;
        }
        private static double ToRadian(double angle)
        {
            return angle* Math.PI/ 180;
        }
        private static void MultiplyVectorByMatrix(ref Vector3D vec, double[,] matr)
        {
            double X, Y, Z;
            X = vec.X * matr[0, 0] + vec.Y * matr[0, 1] + vec.Z * matr[0, 2];
            Y = vec.X * matr[1, 0] + vec.Y * matr[1, 1] + vec.Z * matr[1, 2];
            Z = vec.X * matr[2, 0] + vec.Y * matr[2, 1] + vec.Z * matr[2, 2];
            vec.X = X;
            vec.Y = Y;
            vec.Z = Z;
        }
    }
}
