using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Media3D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icosaedr
{
    public static class ModelStorage
    {
        public static List<Vector3D> vlist;
        public static List<List<int>> flist;

        public static void ParseFile(string filename)
        {
          vlist = new List<Vector3D>();
            flist = new List<List<int>>();
            StreamReader file = new StreamReader(filename);
            while(!file.EndOfStream)
            {
                string line = file.ReadLine();
                line=line.Replace('.', ',');
                string[] parsed = line.Split(' ');
                if (parsed[0]=="v")
                {
                    Vector3D vector = new Vector3D();
                    vector.X = Convert.ToDouble(parsed[1]);
                    vector.Y = Convert.ToDouble(parsed[2]);
                    vector.Z = Convert.ToDouble(parsed[3]);
                    vlist.Add(vector);
                }
                else if(parsed[0] == "f")
                {
                    List<int> list = new List<int>();
                    for(int i=1; i<parsed.Length;i++)
                    {
                        list.Add(Convert.ToInt32(parsed[i]));
                    }
                    flist.Add(list);
                }
            }
            file.Close();
        }
        public static void RotateFigure(double angle, bool X, bool Y, bool Z)
        {
            for (int i = 0; i < vlist.Count; i++)
            {
                if (X) vlist[i]=AffineTransforms.RotateX(angle, vlist[i]);
                if (Y) vlist[i]=AffineTransforms.RotateY(angle, vlist[i]);
                if (Z) vlist[i]=AffineTransforms.RotateZ(angle, vlist[i]);
            }
        }

    }
}
