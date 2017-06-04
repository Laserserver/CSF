using System.Collections.Generic;
using System.Drawing;

namespace OOP3
{
    public class Figure
    {
        public int OwnerID;
        public Point Position;
        public bool IsVisible = true;
        public FigureDirectionType DirType; 

        
        public virtual FigureType GetFigureType()
        {
            return FigureType.Simple;
        }

        public virtual List<Point> GetPossibleMovePoints()
        {
            return new List<Point>();
        }

        public virtual void Draw(Graphics gr, Rectangle rect, Color color)
        {
            
        }

        public enum FigureDirectionType
        {
            OnlyDown,
            OnlyUp,
            Queeen
        }

        public enum FigureType
        {
            Simple,
            Queen
        }
    }
}
