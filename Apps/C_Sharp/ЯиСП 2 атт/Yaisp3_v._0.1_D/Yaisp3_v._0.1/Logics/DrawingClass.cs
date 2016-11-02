using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3_v._0._1.Logics
{
    static class DrawingClass
    {
        public static int 
            I1 = 0,
            I2 = 0,
            J1 = 0,
            J2 = 0;
        public static double
        x1p = -588,
        y1p = -306,
        x2p = 588,
        y2p = 306;
        public static double Scale = 1.00;
        public const double
         x1old = -588,
         y1old = -306,
         x2old = 588,
         y2old = 306; //Константные координаты для получения конечного масштаба   
        public void Reset()
        {
            x1p = x1old;
            x2p = x2old;
            y1p = y1old;
            y2p = y2old;
            Scale = 1.00;
        } 
        int II(double x)          //Перевод бумажного Х в экранный
        {
            return I1 + (int)((x - x1p) * (I2 - I1) / (x2p - x1p));
        }
        int JJ(double y)       //Перевод бумажного Y в экранный
        {
            return J1 + (int)((y - y1p) * (J1 - J2) / (y1p - y2p));
        }
        public double XX(int I)          //Перевод Х коры мыши в кору бумаги
        {
            return x1p + (I - I1) * (x2p - x1p) / (I2 - I1);
        }
        public double YY(int J)          //Перевод Ыгрыка мыши в кору бумаги
        {
            return y1p + (J - J1) * (y2p - y1p) / (J2 - J1);
        }
        public void Redo(int MouseX, int MouseY, int OldCoordsX, int OldCoordsY)    //Движение изображения
        {
            double dx = XX(MouseX) - XX(OldCoordsX);
            double dy = YY(MouseY) - YY(OldCoordsY);

            x1p -= dx;
            y1p -= dy;
            x2p -= dx;
            y2p -= dy;
        }
    }
}
