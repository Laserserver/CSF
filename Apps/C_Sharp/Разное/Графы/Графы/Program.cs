using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Графы
{
    class Program
    {
        //Ссылка на главный лист с узлами
        private static List<Node> nodex;
        private static Queue<Node> nodeQueue;
        
        private static int counterB = 0;
        private static int counterD = 0;
        //массив с метками - проходили ли мы узел или нет
        private static bool[] mark;
        static void Main(string[] args)
        {
            Working working = new Working();
            nodex = working.nodex;
            mark = new bool[nodex.Count];

            nodeQueue = new Queue<Node>();
            
            //Вызываем обход в ширину (начинаем с первого узла)
            BFS(nodex[0]);

            for (int i = 0; i < mark.Length; i++)
            {
                mark[i] = false;
            }

            //Вызываем обход в глубину (начинаем с первого узла)
            DFSec(nodex[0]);

            //Выводим количество посещений для обхода в ширину и в глубину
            Console.WriteLine("Breadth : " + counterB + " - - - Depth : " + counterD);
            Console.ReadKey();
        }

        //Обход в ширину
        private static void BFS(Node currentNode)
        {
            nodeQueue.Enqueue(currentNode);
            Console.WriteLine("Breadth -> " + nodex.IndexOf(currentNode));
            while (nodeQueue.Count != 0)
            {
                Node node = nodeQueue.Dequeue();
                Console.WriteLine("Breadth -> " + nodex.IndexOf(node));
                if (!mark[nodex.IndexOf(node)])
                {
                    mark[nodex.IndexOf(node)] = true;
                    counterB++;
                    foreach (Node snode in nodex[nodex.IndexOf(node)].indices)
                    {
                        nodeQueue.Enqueue(snode);
                    }
                }
            }
        }

        //Обход в глубину
        private static void DFSec(Node currentNode)
        {
            mark[nodex.IndexOf(currentNode)] = true;
            counterD++;
            foreach (Node next in nodex[nodex.IndexOf(currentNode)].indices)
            {
                if (!mark[nodex.IndexOf(next)])
                {
                    counterD++;
                    DFSec(next);
                }
            }
        }

    }
}
