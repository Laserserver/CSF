using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Графы
{
    class Working
    {
        public const string PATHINPUT = "input.txt";
        //Главный лист с узлами
        public List<Node> nodex { get; set; }

        public Working()
        {
            nodex = new List<Node>();
            FillNodex(PATHINPUT);
        }

        //Заполняем связный список
        private void FillNodex(String path)
        {
            //Матрица смежности
            int[,] matrix;
            int length;
            //инициализируем матрицу смежности
            using (StreamReader stream = new StreamReader(path))
            {
                length = stream.ReadLine().Trim().Split(' ').Length;
                matrix = new int[length, length];
            }

            //Заполняем матрицу значениями из текстового файла
            using (StreamReader stream = new StreamReader(path))
            {
                for (int i = 0; i < length; i++)
                {
                    String[] array = stream.ReadLine().Trim().Split(' ');
                    for (int j = 0; j < array.Length; j++)
                    {
                        matrix[i, j] = Convert.ToInt32(array[j]);
                    }
                }
            }

            //заполняем лист узлами
            for (int i = 0; i < length; i++)
            {
                nodex.Add(new Node(i));
            }

            //заполняем листы с указателями в узлах
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        nodex[j].addNode(nodex[i]);
                    }
                }
            }
        }
    }
}
