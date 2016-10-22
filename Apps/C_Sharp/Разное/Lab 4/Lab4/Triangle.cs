using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    struct Triangle
    {
        int[] vertices;
        public Triangle(int i1, int i2, int i3)
        {
            vertices = new int[3];
            vertices[0] = i1;
            vertices[1] = i2;
            vertices[2] = i3;
            Array.Sort(vertices);
        }
        public static bool operator !=(Triangle a, Triangle b)
        {
            return !(a == b);
        }
        public static bool operator == (Triangle a, Triangle b)
        {
            for (int i = 0; i < 3; i++)
                if (a.vertices[i] != b.vertices[i])
                    return false;
            return true;
        }
        public int GetI(int i)
        {
            return vertices[i];
        }
    }
}
