using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace spisky38
{
    class Parser
    {
        public static int[] Parse(string Input)
        {
            string[] Arr = Input.Replace("\r", "").Split('\n');
            int[] Out = new int[int.Parse(Arr[0])];
            for (int i = 0; i < Out.Length; i++)
                Out[i] = int.Parse(Arr[i + 1]);
            return Out;
        }
    }
    class Node     // Узел для списка, стека, очереди
    {
        public int inf;
        //public bool u = true;
        public Node next;
        public Node(int inf, Node next)            // Конструктор
        {
            this.inf = inf;
            this.next = next;
        }
    }

    class MyQueue    // Класс Очередь
    {
        Node head;                            // голова 
        Node tail;
        public int count;                       // число элементов
        public MyQueue()
        {
            head = null; tail = null; count = 0;
        }
        public bool QueueIsEmpty()              // проверка на пустоту
        {
            return head == null;
        }
        public void InQueue(int inf)            // положить в хвост очереди
        {
            Node p = new Node(inf, null);
            if (QueueIsEmpty())
            {
                head = p; tail = p;
            }
            else
            {
                tail.next = p; tail = p;
            }
            count++;
        }
        public int OutQueue()                   // взять из головы очереди
        {
            Node p = head;
            head = head.next;
            count--;
            return p.inf;
        }

        public string[] Printer()
        {
            int L = 0;
            string[] st = new string[0];
            Node p = head;
            while (p != null)
            {
                Array.Resize<string>(ref st, ++L);
                st[L - 1] = p.inf.ToString();
                p = p.next;
            }
            return st;
        }


        /*   public bool Check()
           {
               Node p = head;
               bool u = true;
               if (p != null)
                   do
                   {
                       if (p.inf > p.next.inf)
                           u = false;

                   } while (p != null);

                   return u;
           }*/
        public bool Check()    //ref u
        {   
            Node p = head;
            bool u = true;
            for (int i = 0; i < count; i++)
            {

                if (p != null)
                // do
                {
                    if ((p.inf > p.next.inf) && (u == true))
                    {
                        u = false;
                        head = head.next;
                        count--;
                    }
                    else
                    {
                        head = head.next;
                        count--;
                    }
                    //  } while (p != null);
                }
            }
            return u;
        }
        }
        }
