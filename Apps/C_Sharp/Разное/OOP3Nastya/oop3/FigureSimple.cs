using System.Collections.Generic;
using System.Drawing;

namespace OOP3
{
    public class FigureSimple : Figure
    {
        private Pen _tempPen = Pens.Black;
        private List<Point> _points;


        public FigureSimple()
        {
            _points = new List<Point>();

            Point tempPoint = new Point(1, 1);
            _points.Add(tempPoint);

            tempPoint = new Point(-1, 1);
            _points.Add(tempPoint);

            tempPoint = new Point(-1, -1);
            _points.Add(tempPoint);

            tempPoint = new Point(1, -1);
            _points.Add(tempPoint);
        }

        public override FigureType GetFigureType()
        {
            return FigureType.Simple;
        }

        public override List<Point> GetPossibleMovePoints()
        {
            return _points;
        }

        public override void Draw(Graphics gr, Rectangle rect, Color color)
        {
            Rectangle tempRect = new Rectangle(rect.X + (int) (rect.Width*0.1), rect.Y + (int) (rect.Height*0.1), rect.Width - (int) (rect.Width*0.2), rect.Height - (int) (rect.Height*0.2));
            SolidBrush bt = new SolidBrush(color);
            gr.FillEllipse(bt, tempRect);
            gr.DrawEllipse(_tempPen, tempRect);

            if (bt != null)
            {
                bt.Dispose();
            }
        }
    }
}
