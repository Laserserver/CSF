using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    class Matrix
    {
        public static double[] VectorMatrixMlp(double[] vector, double[][] matrix, int n)
        {
            double[] ret = new double[n];
            for (int i = 0; i < n; i++)
            {
                ret[i] = 0;
                for (int j = 0; j < n; j++)
                    ret[i] += vector[j] * matrix[j][i];
            }
            return ret;
        }
        public static void MatrixMatrixMlp(double[][] matrix1, double[][] matrix2, int n, double[][] ret)
        {
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    ret[i][j] = 0;
                    for (int k = 0; k < n; k++)
                        ret[i][j] += matrix1[i][k] * matrix2[k][j];
                }
            }
        }
        public static void Make3DRotationZ(double cos, double sin, double[][] ret)
        {
            ret[0][0] = cos;
            ret[0][1] = sin;
            ret[0][2] = ret[0][3] = 0;
            ret[1][0] = -ret[0][1];
            ret[1][1] = ret[0][0];
            ret[1][2] = ret[1][3] = 0;
            ret[2][0] = ret[2][1] = ret[2][3] = 0;
            ret[2][2] = ret[3][3] = 1;
            ret[3][0] = ret[3][1] = ret[3][2] = 0;
        }
        public static void Make3DRotationY(double cos, double sin, double[][] ret)
        {
            ret[0][0] = cos;
            ret[0][1] = 0;
            ret[0][2] = -sin;
            ret[0][3] = 0;
            ret[1][0] = 0;
            ret[1][1] = 1;
            ret[1][2] = 0;
            ret[1][3] = 0;
            ret[2][0] = -ret[0][2];
            ret[2][1] = 0;
            ret[2][2] = ret[0][0];
            ret[2][3] = 0;
            ret[3][0] = ret[3][1] = ret[3][2] = 0;
            ret[3][3] = 1;
        }
        public static void Make3DScaling(double sx, double sy, double sz, double[][] ret)
        {
            ret[0][0] = sx;
            ret[1][1] = sy;
            ret[2][2] = sz;
            ret[0][1] = ret[0][2] = ret[0][3] = 0;
            ret[1][0] = ret[1][2] = ret[1][3] = 0;            
            ret[2][0] = ret[2][1] = ret[2][3] = 0;
            ret[3][3] = 1;
        }
        public static void Make3DTranslation(double dx, double dy, double dz, double[][] ret)
        {
            ret[0][0] = ret[1][1] = ret[2][2] = ret[3][3] = 1;
            ret[0][1] = ret[0][2] = ret[0][3] = 0;
            ret[1][0] = ret[1][2] = ret[1][3] = 0;
            ret[2][0] = ret[2][1] = ret[2][3] = 0;
            ret[3][0] = dx;
            ret[3][1] = dy;
            ret[3][2] = dz;
        }
    }
}
