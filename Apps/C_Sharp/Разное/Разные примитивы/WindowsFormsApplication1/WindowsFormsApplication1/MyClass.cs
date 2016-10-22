using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    class MyClass
    {
        private Bitmap/*Image*/ theImage;

        public MyClass()
        {
            theImage = new Bitmap("Star.bmp");
        }

        public void Draw(Graphics g)
        {

           
            /*int w = 1000;//размеры клиентской области       // клетка 
            int h = 1000;//размеры клиентской области

            int widthLines = 25;//Ширина клетки
            int heightLines = 25;//Высота клетки
            for (int i = 0; i < w; i += widthLines)
            {
                //Вертикальные линии
                g.DrawLine(new Pen(Brushes.BlueViolet), new Point(i + widthLines, 0), new Point(i + widthLines, h));
                //Горизонтальные линии
                g.DrawLine(new Pen(Brushes.BlueViolet), new Point(0, i + heightLines), new Point(w, i + heightLines));
            }*/


          

            Pen p = new Pen(Brushes.Black, 1); //Pens.Black;                //надписи 
            p.Color = Color.FromArgb(0xFF, 0x00, 0x00);
            

            p.Width = 2;
            p.Color = Color.Blue;

            
            Rectangle rect = new Rectangle(10, 10, 190, 30);                //надпись 1
            g.DrawRectangle(p, rect);

            Font myFont = new Font(FontFamily.GenericSansSerif, 12);
            g.DrawString("Работа", myFont, Brushes.Purple, rect);
      
            Rectangle rect1 = new Rectangle(10, 50, 390, 30);               //надпись 2
            g.DrawRectangle(p, rect1);

            Font myFont1 = new Font(FontFamily.GenericSansSerif, 12);
            g.DrawString("Лоскутовой Анны", myFont1, Brushes.Purple, rect1);
      
            Rectangle rect2 = new Rectangle(10, 90, 200, 30);               //надпись 2
            g.DrawRectangle(p, rect2);

            Font myFont2 = new Font(FontFamily.GenericSansSerif, 12);
            g.DrawString("Дата: 13 сентября 2016", myFont2, Brushes.Purple, rect2);
      
            Pen penBrown = new Pen(Color.Brown, 4);                          //коробка
            g.DrawRectangle(penBrown, new Rectangle(200, 200, 300, 200));
      
            Pen myPen = new Pen(Color.Red, 5);                               //крыша  
             g.DrawLine(myPen, 500, 200, 350, 100);

            Pen myPen1 = new Pen(Color.Red, 5);                              //крыша 
            g.DrawLine(myPen1, 200, 200, 350, 100);
      
            Pen pen2 = new Pen(Color.Green, 2);
            g.DrawEllipse(pen2, new Rectangle(325, 140, 50, 50));            // окошко верхнее


            Pen penBrown1 = new Pen(Color.Green, 2);                          //окно 1 
            g.DrawRectangle(penBrown1, new Rectangle(250, 250, 50, 50));
            Pen myPenW = new Pen(Color.Green, 2);                              
            g.DrawLine(myPenW, 250, 275, 300, 275);
            Pen myPenWi = new Pen(Color.Green, 2);
            g.DrawLine(myPenWi, 275, 275, 275, 300);

            Pen penBrown2 = new Pen(Color.Green, 2);                          //окно 2 
            g.DrawRectangle(penBrown2, new Rectangle(400, 250, 50, 50));
            Pen myPenW1 = new Pen(Color.Green, 2);
            g.DrawLine(myPenW1, 400, 275, 450, 275);
            Pen myPenWi1 = new Pen(Color.Green, 2);
            g.DrawLine(myPenWi1, 425, 275, 425, 300);


            Pen myPenF = new Pen(Color.Black, 2);                              //фундамент
            g.DrawLine(myPenF, 200, 375, 500, 375);


        }
    }
}
