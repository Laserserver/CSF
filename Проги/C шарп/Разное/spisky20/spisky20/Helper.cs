using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spisky20
{
    class Node     // Узел для списка, стека, очереди
    {
        public int inf;
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

      /*  public void createTheQ(int n)
        {


            Random r = new Random();

            Node q = new Node(r.Next(-50, 50), null);
            head = q;
            tail = q;
            Node p = head;
            count++;

            for (int i = 0; i < n; i++)
            {
                q = new Node(r.Next(-50, 50), null);
                p.next = q;
                p = p.next;
                count++;
            }*/

            /* public string[] DelBt()
             {
                 Node p = head;
                 for (int i = 0; i < (count + 1); i++)
                 {
                     head = head.next;

                 }

                 return ;
             }*/
        }
}
