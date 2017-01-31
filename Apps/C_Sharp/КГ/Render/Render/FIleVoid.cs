using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Render
{
    class FIleVoid
    {
        
       public  Model currModel;
       
        public void Parse0(string name, string textureName)
        {
            currModel = new Model();
            string ans = "";
            FileStream f = new FileStream(name, FileMode.Open);
            StreamReader fa = new StreamReader(f);
            ans = fa.ReadToEnd();
            fa.Close();
            f.Close();
            Parse(ans);
            //currModel.Print();
            currModel.texture = new Bitmap(textureName);
        }
        
        private void Parse(string str)
        {
            string[] arr = str.Split('\n'/*new string[] { Environment.NewLine }, StringSplitOptions.None*/);
            int L = arr.Length;
            string[] line;
            for (int i = 0; i < L-1; i++)
            {
                if (arr[i] != "" && arr[i][0]!= '\r' && arr[i][0] != '\n')
                switch (arr[i].Substring(0, 2))
                {
                    case "v ":
                            if (arr[i][2] == ' ')
                            {
                                arr[i] = arr[i].Substring(3, arr[i].Length - 3);
                                line = arr[i].Split(' ');
                                currModel.PushPoint(line[0], line[1], line[2]);
                            }
                            else
                            {
                                line = arr[i].Split(' ');
                                currModel.PushPoint(line[1], line[2], line[3]);
                            }
                        break;
                        case "f ":
                            line = arr[i].Split(' ');
                            int[] Dot = new int[0];
                            List<int> textureDot = new List<int>();
                            for (int j = 1; j < line.Length; j++)
                            {
                                int s = 0;
                                string sr = "";
                                string vtDot = "";
                                while (s < line[j].Length && line[j]!= "" &&line[j][s] != '\r' && line[j][s] != '\n' && line[j][s] != '/')
                                {
                                    sr += line[j][s];
                                    s++;
                                }
                                s++;
                                while (s < line[j].Length && line[j] != "" && line[j][s] != '\r' && line[j][s] != '\n' && line[j][s] != '/')
                                {
                                    vtDot += line[j][s];
                                    s++;
                                }
                                if (sr != "")
                                {
                                    Array.Resize<int>(ref Dot, Dot.Length + 1);
                                    Dot[Dot.Length - 1] = int.Parse(sr);
                                }   
                                if (vtDot != "")
                                {
                                    textureDot.Add(int.Parse(vtDot) - 1);
                                }
                            }
                            currModel.PushPolygon(Dot, textureDot);
                            break;
                        case "vt":
                            line = arr[i].Split(new char[] {' ' }, StringSplitOptions.RemoveEmptyEntries);
                            currModel.tPoints.Add(new Model.TextureP(double.Parse(line[1], System.Globalization.CultureInfo.InvariantCulture), double.Parse(line[2], System.Globalization.CultureInfo.InvariantCulture)));
                            break;

                            
                    }

            }
            currModel.CalculateCenter();
            currModel.PushNormal();

        }
        //private void Parse(string all)
        //{
        //    string x = "";
        //    string y = "";
        //    string z = "";

        //    int i = 0;

        //    //while (i < all.Length)
        //    //{

        //    //    if (all[i] == '\n')
        //    //        if (all[i + 1] == 'v' && all[i+2] == ' ')
        //    //        {
        //    //            i = i + 3;
        //    //            while (all[i] != ' ')
        //    //            {
        //    //                if (all[i] == '.')
        //    //                    x += ',';
        //    //                else
        //    //                    x += all[i];
        //    //                i++;
        //    //            }
        //    //            i++;
        //    //            while (all[i] != ' ')
        //    //            {
        //    //                if (all[i] == '.')
        //    //                    y += ',';
        //    //                else
        //    //                    y += all[i];
        //    //                i++;
        //    //            }
        //    //            while (all[i] != '\n')
        //    //            {
        //    //                if (all[i] == '.')
        //    //                    z += ',';
        //    //                else
        //    //                    z += all[i];
        //    //                i++;
        //    //            }
        //    //            currModel.Push(x, y, z);
        //    //            x = "";
        //    //            y = "";
        //    //            z = "";
        //    //        }
        //    //    i += 10;
        //    //}
        //}
    }
}
