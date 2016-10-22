using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGraph3
{
    class polygons : ICloneable
    {
        public Brush color;
        public point3d[] points;
        public polygon(Brush color, point3d[] points)
        {
            this.color = color;
            this.points = points;
        }
        public float MiddleZ()
        {
            float result = 0;
            for (int i = 0; i < points.Length; i++)
                result += points[i].z;
            return result / points.Length;
        }

        public object Clone()
        {
            point3d[] points = new point3d[this.points.Length];
            for (int i = 0; i < this.points.Length; i++)
                points[i] = this.points[i];
            return new polygons((Brush)this.color.Clone(), points);
        }
    }
}
