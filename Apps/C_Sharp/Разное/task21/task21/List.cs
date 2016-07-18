using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task21
{
    /*Считалочка. 
     N ребят расположены по кругу. (Каждому присвоен  номер по порядку). 
     Начав отсчёт от первого, удаляют каждого k-ого, смыкая при этом круг. 
     Определить номер последнего, оставшегося  в круге.(k <=N)
     Указание: для решения задачи использовать очередь, в которой ссылочное 
     поле последнего элемента содержит адрес первого элемента.*/
    class Node
    {
        public int inf;
        public Node next;
        public Node(int inf, Node next)
        {
            this.inf = inf;
            this.next = next;
        }
    }
    class MyList
    {
        public Node head;
        public Node tail;
        public int count;
        public MyList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool ListIsEmpty()
        {
            return head == null;
        }

        public void InList(int inf)
        {
            Node p = new Node(inf, head);
            if (ListIsEmpty())
            {
                head = p;
                tail = p;
            }
            else
            {
                tail.next = p;
                tail = p;
                tail.next = head;
            }
            count++;
        }

        public void Delete(int index)
        {
            if (index != 0)
            {
                Node p = head;
                for (int i = 0; i < index - 1; i++)
                    p = p.next;
                if (p.next != null)
                    p.next = p.next.next;
            }

            else
            {
                head = head.next;
                tail.next = head;
            }
            count--;
        }

        public int ReturnHead()
        {
            Node p = head;
            return p.inf;
        }
    }
}
