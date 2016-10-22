using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class pointpr
    {

        public pointpr(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

        }
        public float x, y, z;
    }

    class pointproec
    {
        public pointpr[] points;
    }
}
