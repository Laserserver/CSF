using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuncProc24
{
    class Changer
    {
        public static int[,] Change(int[,] Matrix, bool FromFirst, bool ToFirst)
        {
            if (FromFirst)
                return (ToFirst ? First(Matrix, true) : First(Matrix, false));
            else
                return (ToFirst ? Last(Matrix, true) : Last(Matrix, false));
        }

        public static int[] NewFirst(int[,] Arr, bool IsFirst)
        {
            int[] Sorted = new int[Arr.GetLength(0)];
            for (int k = 0; k < Arr.GetLength(0) - 1; k++)
                if (IsFirst)
                    Sorted[k] = Arr[k, 0];
                else
                    Sorted[k] = Arr[k, Arr.GetLength(0) - 1];
            return Sorted;
        }

        public static int[] Second(int[,] Matrix, bool IsNotLast, ref int Mark)
        {
            int[] Reserve = new int[Matrix.GetLength(0)];
            bool flag = true;
            if (IsNotLast)
            {
                for (int i = Mark; i < Matrix.GetLength(1) - 1; i++)
                    if (flag)
                    for (int k = 0; k < Matrix.GetLength(0) - 1; k++)
                        if (Matrix[k, i] < 0)
                            break;                        
                        else
                            if (Matrix[Matrix.GetLength(0) - 1, i] > 0)
                            {
                                Mark = i;
                                flag = false;
                                break;
                            }
                for (int k = 0; k < Reserve.Length; k++)
                    Reserve[k] = Matrix[k, Mark];
                return Reserve;
            }
            else
            {
                for (int i = Matrix.GetLength(1) - 1; i >= 0; i--)
                    if (flag)
                    for (int k = 0; k < Matrix.GetLength(0) - 1; k++)
                        if (Matrix[k, i] < 0)
                        {
                            flag = false;
                            break;
                        }
                        else
                            if (Matrix[Matrix.GetLength(0) - 1, i] > 0)
                            {
                                Mark = i;
                                flag = false;
                                break;
                            }
                for (int k = 0; k < Reserve.Length; k++)
                Reserve[k] = Matrix[k, Mark];
                return Reserve;
            }
        }


        public static int[,] First(int[,] Matrix, bool ToFirst)
        {
            int Mark = 1; 
            int[] NewAr2 = (ToFirst ? Second(Matrix, true, ref Mark) : Second(Matrix, false, ref Mark));
            int[] NewArr = NewFirst(Matrix, true);
            
                for (int i = 0; i < Matrix.GetLength(0); i++)
                {
                    Matrix[i, Mark] = Matrix[i, 0];
                    Matrix[i, 0] = NewAr2[i];           
                }
            return Matrix;                        
        }
        public static int[,] Last(int[,] Matrix, bool ToFirst)
        {
            int Mark = 0;
            int[] NewAr2 = (ToFirst ? Second(Matrix, true, ref Mark) : Second(Matrix, false, ref Mark));
            int[] NewArr = NewFirst(Matrix, true);
                     
                for (int i = 0; i < Matrix.GetLength(0); i++)
                {
                    Matrix[i, Mark] = Matrix[i, Matrix.GetLength(1) - 1];
                    Matrix[i, Matrix.GetLength(1) - 1] = NewAr2[i];  //Перезапись последнего столбца матрицы            
                }           
            return Matrix;
        }
    }
}
