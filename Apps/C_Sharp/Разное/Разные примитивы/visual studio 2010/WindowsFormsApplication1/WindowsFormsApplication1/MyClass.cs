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
            
            Pen myPen1 = new Pen(Color.Red, 3);
            g.PageUnit = GraphicsUnit.Pixel;
            g.DrawEllipse(myPen1, 10, 10, 200, 100);

            g.PageUnit = GraphicsUnit.Display;
            //g.DrawEllipse(Pens.Black, 10, 10, 200, 100);

            g.PageUnit = GraphicsUnit.Point;
            //g.DrawEllipse(Pens.Black, 10, 10, 200, 100);

            g.PageUnit = GraphicsUnit.Millimeter;
            //g.DrawEllipse(Pens.Black, 10, 10, 20, 10);

            g.PageUnit = GraphicsUnit.Document;
            //g.DrawEllipse(Pens.Black, 10, 10, 200, 100);

            Pen myPen = new Pen(Color.Black, 0.05F);
            g.PageUnit = GraphicsUnit.Inch;
            //g.DrawEllipse(myPen, 1, 1, 2, 1);
            
            //Font Brush Pen

            int w = 1000;//размеры клиентской области
            int h = 1000;//размеры клиентской области

            int widthLines = 25;//Ширина клетки
            int heightLines = 25;//Высота клетки
            for (int i = 0; i < w; i += widthLines)
            {
                //Вертикальные линии
                g.DrawLine(new Pen(Brushes.BlueViolet), new Point(i + widthLines, 0), new Point(i + widthLines, h));
                //Горизонтальные линии
                g.DrawLine(new Pen(Brushes.BlueViolet), new Point(0, i + heightLines), new Point(w, i + heightLines));
            }


            g.DrawClosedCurve(Pens.Black, new Point[] { 
                new Point (110,10),
                new Point (150,10),
                new Point (160,40),
                new Point (120,20),
                new Point (120,60),}, 1, FillMode.Winding); 
            
            g.DrawArc(Pens.Black, new Rectangle(120, 120, 20, 20), 0, 90);
            g.DrawBezier(Pens.Black, new Point(110, 10),
                new Point(150, 10),
                new Point(160, 40),
                new Point(120, 20));
            g.DrawClosedCurve(Pens.Black, new Point[] { 
                new Point (110,10),
                new Point (150,10),
                new Point (160,40),
                new Point (120,20),
                new Point (120,60),}, 5, FillMode.Winding); //.Alternate);

            g.DrawCurve(Pens.Black, new Point[] { 
                new Point (110,10),
                new Point (150,10),
                new Point (160,40),
                new Point (120,20),
                new Point (120,60)});
            
            
            g.DrawEllipse(Pens.Black, new Rectangle(120, 120, 20, 20));
            
            Rectangle r = new Rectangle(0, 0, 200, 200);
            //g.DrawImage(theImage, r);
            //theImage.Dispose();

            int k = 0xFF;
            Color col = Color.FromArgb(12);
            int y = 0;

            Pen p = new Pen(Brushes.Black, 1); //Pens.Black;
            p.Color = Color.FromArgb(0xFF, 0x00, 0x00);
            Pen q = new Pen(Color.Black, 1);
            q.Color = Color.FromArgb(0xFF, 0x00, 0x00);

            p.Width = 2;
            //p.Color = Color.
            Rectangle rect = new Rectangle(10, 10, 400, 30);
            g.DrawRectangle(p, rect);

            Font myFont = new Font(FontFamily.GenericSansSerif, 12);
            g.DrawString("Выравнивание слева", myFont, Brushes.Black, rect);
            
            /*
            g.FillRectangle(Brushes.White, r);
            g.FillRectangle(Brushes.Red, new Rectangle(10, 10, 50, 50));
            Brush linearGradientBrush = new LinearGradientBrush(
                new Rectangle(10, 60, 50, 50), Color.Blue, Color.White, 45);
            g.FillRectangle(linearGradientBrush, new Rectangle(10, 60, 50, 50));
            // Вызов метода Dispose() вручную. 
            linearGradientBrush.Dispose();
            g.FillEllipse(Brushes.Aquamarine, new Rectangle(60, 20, 50, 30));
            g.FillPie(Brushes.Chartreuse, new Rectangle(60, 60, 50, 50), 90, 210);
            g.FillPolygon(Brushes.BlueViolet, new Point[] { 
                new Point (110,10),
                new Point (150,10),
                new Point (160,40),
                new Point (120,20),
                new Point (120,60),
            });
            */

        }
    }
}
