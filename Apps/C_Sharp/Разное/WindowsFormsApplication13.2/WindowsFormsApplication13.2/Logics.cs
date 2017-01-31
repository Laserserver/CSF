using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication13._2
{
    class Logics
    {
        public string FindValues(string Path)
        {
            int CountMin = 0;
            int CountMax = 0;
            double prev, mid, next;
            FileStream a = new FileStream(Path, FileMode.Open);
            BinaryReader r = new BinaryReader(a);
            if (r.BaseStream.Length < 32)
            {
                switch (r.BaseStream.Length)
                {
                    case 8:
                        prev = r.ReadDouble();
                        CountMax = CountMin = 1;
                        break;
                    case 16:
                        prev = r.ReadDouble();
                        mid = r.ReadDouble();
                        if (prev == mid)
                            CountMin = CountMax = 0;
                        else
                            CountMax = CountMin = 1;
                        break;
                    case 24:
                        prev = r.ReadDouble();
                        mid = r.ReadDouble();
                        next = r.ReadDouble();
                        if (prev > mid && mid < next)
                        {
                            CountMin = 1;
                            CountMax = 2;
                        }
                        else
                            if (prev < mid && mid > next)
                        {
                            CountMin = 2;
                            CountMax = 1;
                        }
                        else
                        {
                            if (prev == mid && mid == next)
                                CountMax = CountMin = 0;
                            else
                            {
                                CountMin = 1;
                                CountMax = 1;
                            }
                        }
                        break;
                }
            }
            else
            {
                long a0 = 16;
                while (r.BaseStream.Position != r.BaseStream.Length)
                {
                    r.BaseStream.Position = a0 - 16;
                    prev = r.ReadDouble();
                    r.BaseStream.Position = a0 - 8;
                    mid = r.ReadDouble();
                    r.BaseStream.Position = a0;
                    next = r.ReadDouble();
                    if (prev > mid && mid < next)
                        CountMin++;
                    if (prev < mid && mid > next)
                        CountMax++;
                    a0 += 8;
                }
            }
            return "Максимумы: " + CountMax + ", Минимумы: " + CountMin + ", Экстремумы: " + (CountMin + CountMax) + '.';
        }

        public double[] ParseArray(string[] Arr)
        {
            int Count = Arr.Length;
            double[] Out = new double[Count];
            for (int i = 0; i < Count; i++)
                Out[i] = double.Parse(Arr[i].Replace('.', ','));
            return Out;
        }

        public void Save(string Path, double[] Arr)
        {
            FileStream a = new FileStream(Path, FileMode.OpenOrCreate);
            BinaryWriter Writer = new BinaryWriter(a);
            int Count = Arr.Length;
            for (int i = 0; i < Count; i++)
                Writer.Write(Arr[i]);
            a.Close();
            Writer.Close();
        }
    }
}