using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    public class FigureQueen:Figure
    {
        private Pen _tempPen = Pens.Black;
        private List<Point> _points;

        public FigureQueen()
        {
            DirType=FigureDirectionType.Queeen;
            _points = new List<Point>();

            int Size = Game.Singletone.WidthHeightField.Width;

            for (int i = 0; i < Size; i++)
            {
                    Point tempPoint2 =new Point(i, i);
                    _points.Add(tempPoint2);
                    tempPoint2 = new Point(Size-i, i);
                    _points.Add(tempPoint2);
                    tempPoint2 = new Point(-i, -i);
                    _points.Add(tempPoint2);
                    tempPoint2 = new Point(-Size + i, -i);
                    _points.Add(tempPoint2);
                
            }

//            Point tempPoint = Position - new Size(1, 1);
//            _points.Add(tempPoint);
//
//            tempPoint = Position - new Size(-1, 1);
//            _points.Add(tempPoint);
//
//            tempPoint = Position + new Size(-1, -1);
//            _points.Add(tempPoint);
//
//            tempPoint = Position + new Size(1, -1);
//            _points.Add(tempPoint);
        }

        public override FigureType GetFigureType()
        {
            return FigureType.Queen;
        }

        public override List<Point> GetPossibleMovePoints()
        {
            var points2 = new List<Point>();
            for (int i = 0; i < 8; i+=1)
            {
                Point tempPoint2 = new Point(i, i);
                points2.Add(tempPoint2);
                tempPoint2 = new Point(-i, i);
                points2.Add(tempPoint2);
                tempPoint2 = new Point(-i, -i);
                points2.Add(tempPoint2);
                tempPoint2 = new Point(i, -i);
                points2.Add(tempPoint2);
            }
            return points2;
        }

        public override void Draw(Graphics gr, Rectangle rect, Color color)
        {
            Rectangle tempRect = new Rectangle(rect.X + (int) (rect.Width*0.1), rect.Y + (int) (rect.Height*0.1), rect.Width - (int) (rect.Width*0.2), rect.Height - (int) (rect.Height*0.2));
            SolidBrush bt = new SolidBrush(color);
            gr.FillEllipse(bt, tempRect);
            gr.DrawEllipse(_tempPen, tempRect);
           
            
            gr.DrawImage(Properties.Resources.Korona,tempRect);

            if (bt != null)
            {
                bt.Dispose();
            }
        }
    }
}
