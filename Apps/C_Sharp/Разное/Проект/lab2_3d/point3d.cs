using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class point3d
    {
        
        public point3d(float x, float y, float z)
        {
            this.x=x;
            this.y=y;
            this.z=z;


        }
        public float x, y, z;
    }
    class oldpoint3d
    {

        public oldpoint3d(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;


        }
        public float x, y, z;
    }

    class polygon
    {

        public Brush color;
        public point3d[] points;
        public oldpoint3d[] oldpoints;
        public int minz;
    }
}
