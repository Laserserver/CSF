using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Render
{
    public static class Matrix
    {
        public static double[,] ZoomMatrix(double[,]  points, double x, double y, double z)
        {
            double[,] zoomM = new double[3, 3]
            {
                {x, 0, 0},
                {0, y, 0},
                {0, 0, z},
                //{0, 0, 0, 1}
            };
            return Multiply(points, zoomM);
            
        }
        public static double[,] TurnMatrix(double[,] points, double angl, int x, int y, int z)
        {
            double[,] m = new double[3, 3];
            double cos = Math.Cos(angl);
            double sin = Math.Sin(angl);
            m[0, 0] = cos + (1 - cos) * x * x;
            m[0, 1] = (1 - cos) * x * y - (sin) * z;
            m[0, 2] = (1 - cos) * x * z + (sin) * y;
            m[1, 0] = (1 - cos) * y * x + sin * z;
            m[1, 1] = cos + (1 - cos) * y * y;
            m[1, 2] = (1 - cos) * y * z - sin * x;
            m[2, 0] = (1 - cos) * z * x - sin * y;
            m[2, 1] = (1 - cos) * z * y + sin * x;
            m[2, 2] = cos + (1 - cos) * z * z;
            return Multiply(points, m);
        }
        private static double[,] Multiply(double[,] a, double[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            double[,] r = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }
    }
}
