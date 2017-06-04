using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Task3_test.NewComponent
{
    public class Coordinates
    {
        public Coordinates(int x1, int y1, int x2, int y2)
        {
            BorderLeft.X = x1;
            BorderLeft.Y = y1;
            BorderRight.X = x2;
            BorderRight.Y = y2;
        }
        public Point BorderLeft, BorderRight;//левые и правые границы 
    }
}
