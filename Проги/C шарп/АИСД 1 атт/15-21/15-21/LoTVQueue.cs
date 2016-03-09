using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15_21
{
    class LoTVQueueNode
    {
        public int NodeQueueValue;
        public LoTVQueueNode NextNode;

        public LoTVQueueNode(int Info, LoTVQueueNode Node)
        {
            NodeQueueValue = Info;
            NextNode = Node;
        }
    }

    class LoTVQueue
    {
        public LoTVQueueNode QueueHead;
        public LoTVQueueNode QueueTail;
        public int count;

        public LoTVQueue()
        {
            QueueHead = null;
            QueueTail = null;
        }

        public bool QueueIsEmpty()
        {
            return QueueHead == null;
        }

        public void InQueue(int inf)            // положить в хвост очереди
        {
            LoTVQueueNode p = new LoTVQueueNode(inf, null);
            if (QueueIsEmpty())
            {
                QueueHead = p;
                QueueTail = p;
            }
            else
            {
                QueueTail.NextNode = p;
                QueueTail = p;
            }
            count++;
        }

        public int OutQueue()                   // взять из головы очереди
        {
            LoTVQueueNode p = QueueHead;
            QueueHead = QueueHead.NextNode;
            count--;
            return p.NodeQueueValue;
        }
    }

    class Thing
    {
        public static LoTVQueue CutQueue(int SacredValue, LoTVQueue OldQueue)
        {
            LoTVQueue NewQueue = new LoTVQueue();

            if (!OldQueue.QueueIsEmpty())
            {
                NewQueue.InQueue(OldQueue.OutQueue());
                do
                {
                    if (NewQueue.QueueTail.NodeQueueValue != SacredValue)
                        NewQueue.InQueue(OldQueue.OutQueue());
                    else
                    {
                        do
                            OldQueue.OutQueue();
                        while (!OldQueue.QueueIsEmpty() && OldQueue.QueueHead.NodeQueueValue == SacredValue);
                        if (!OldQueue.QueueIsEmpty())
                            NewQueue.InQueue(OldQueue.OutQueue());
                    }
                }
                while (!OldQueue.QueueIsEmpty());
            }
            return NewQueue;
        }
    }
}
