using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Render
{
  public static class Matrices
  {
    public class Matrix
    {
      public double[,] MatrixArr;
    }
    public class MatrixProjection : Matrix
    {
      public MatrixProjection()
      {
        MatrixArr = new double[4, 4]
    {
          {1,0,0  ,0 },
          {0,1,0  ,0 },
          {0,0,0.5,-1},
          {0,0,1  ,0 }
    };

        /*switch (Axis)
        {
          case 1:
            MatrixArr = new double[4, 4]
        {
          {0,0,0,0 },
          {0,1,0,0 },
          {0,0,1,0 },
          {0,0,0,1 }
        };
            break;
          case 2:
            MatrixArr = new double[4, 4]
        {
          {1,0,0,0 },
          {0,0,0,0 },
          {0,0,1,0 },
          {0,0,0,1 }
        };
            break;
          case 3:
            MatrixArr = new double[4, 4]
        {
          {1,0,0,0 },
          {0,1,0,0 },
          {0,0,0,0 },
          {0,0,0,1 }
        };
            break;
        }*/
      }
    }
    public class MatrixRotation : Matrix
    {
      public MatrixRotation(double Angle, int Type)
      {
        double sin = Math.Sin(Angle);
        double cos = Math.Cos(Angle);

        switch (Type)
        {   //1 - по Х, 2 - по У, 3 - по Z
          case 1:
            MatrixArr = new double[4, 4]
        {
          {1,   0,  0,0 },
          {0, cos,sin,0 },
          {0,-sin,cos,0 },
          {0,   0,  0,1 }
        };
            break;
          case 2:
            MatrixArr = new double[4, 4]
        {
          {cos, 0,-sin,0 },
          {  0, 1,   0,0 },
          {sin, 0, cos,0 },
          {  0, 0,   0,1 }
        };
            break;
          case 3:
            MatrixArr = new double[4, 4]
        {
          { cos, sin, 0,0 },
          {-sin, cos, 0,0 },
          {   0,   0, 1,0 },
          {   0,   0, 0,1 }
        };
            break;
        }
      }
    }
    public class MatrixTranslation : Matrix
    {
      public MatrixTranslation(double x, double y, double z)
      {
        MatrixArr = new double[4, 4]
        {
          {1,0,0,0 },
          {0,1,0,0 },
          {0,0,1,0 },
          {x,y,z,1 }
        };
      }
    }
    public class MatrixSquashing : Matrix
    {
      public MatrixSquashing(double sx, double sy, double sz)
      {
        MatrixArr = new double[4, 4]
        {
          {sx, 0, 0,0 },
          { 0,sy, 0,0 },
          { 0, 0,sz,0 },
          { 0, 0, 0,1 }
        };
      }
      public MatrixSquashing(double allS)
      {
        MatrixArr = new double[4, 4]
        {
          {1,0,0,   0 },
          {0,1,0,   0 },
          {0,0,1,   0 },
          {0,0,0,allS }
        };
      }
    }
    public class MatrixReflection : Matrix
    {
      public MatrixReflection(int Type)
      {
        switch (Type)
        {
          case 1:
            MatrixArr = new double[4, 4]
        {
          {-1,0,0,0 },
          { 0,1,0,0 },
          { 0,0,1,0 },
          { 0,0,0,1 }
        };
            break;
          case 2:
            MatrixArr = new double[4, 4]
        {
          {1, 0,0,0 },
          {0,-1,0,0 },
          {0, 0,1,0 },
          {0, 0,0,1 }
        };
            break;
          case 3:
            MatrixArr = new double[4, 4]
        {
          {1,0, 0,0 },
          {0,1, 0,0 },
          {0,0,-1,0 },
          {0,0, 0,1 }
        };
            break;
        }
      }
    }
    public class MatrixResizing : Matrix
    {
      public MatrixResizing(bool IsReverse, double X, double Y, double Z)
      {
        if (IsReverse)
        {
          MatrixArr = new double[4, 4]
        {
          {1/X,  0,  0,0 },
          {  0,1/Y,  0,0 },
          {  0,  0,1/Z,0 },
          {  0,  0,  0,1 }
        };
        }
        else
        {
          MatrixArr = new double[4, 4]
        {
          {X,0,0,0 },
          {0,Y,0,0 },
          {0,0,Z,0 },
          {0,0,0,1 }
        };
        }
      }
    }
  }
}
