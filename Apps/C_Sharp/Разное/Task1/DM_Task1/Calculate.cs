using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DM_Task1
{
    class Calculate
    {
        public double Det(ref int[,] matrix, int n)
        {
            double det = 0;
            int[,] mat = matrix;

            if (n != 1)
            {
                if (n == 2)
                {
                    det = mat[0, 0] * mat[1, 1] - mat[0, 1] * mat[1, 0];
                }
                else
                {       //вычисляем по первой строке и вызываем рекурсию на остаточные матрицы
                    for (int i = 0; i < n; i++)
                    {
                        int[,] matOst = new int[n - 1, n - 1]; //остаточная матрица
                        for (int x = 0; x < n - 1; x++)
                        {
                            int j = 0;
                            for (int y = 0; y < n; y++)
                            {
                                if (y != i)
                                {
                                    matOst[x, j] = mat[x + 1, y];
                                    j++;
                                }
                            }
                        }
                        det += mat[0, i] * Det(ref matOst, n - 1) * Math.Pow(-1, 2 + i); //рекурсивно передаем остаточную матрицу
                    }
                    n--;
                }
            }
            else
            {
                det = mat[0, 0];
            }
            return det;
        }
    }
}
