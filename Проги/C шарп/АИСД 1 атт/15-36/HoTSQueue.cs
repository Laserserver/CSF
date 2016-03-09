namespace _15_36
{
    class HoTSQueueNode
    {
        public int NodeQueueValue;
        public HoTSQueueNode NextNode;

        public HoTSQueueNode(int Info, HoTSQueueNode Node)
        {
            NodeQueueValue = Info;
            NextNode = Node;
        }
    }

    class HoTSQueue
    {
        public HoTSQueueNode QueueHead;
        public HoTSQueueNode QueueTail;
        public int count;

        public HoTSQueue()
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
            HoTSQueueNode p = new HoTSQueueNode(inf, null);
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
            HoTSQueueNode p = QueueHead;
            QueueHead = QueueHead.NextNode;
            count--;
            return p.NodeQueueValue;
        }
    }

    class Logic
    {
        public static int FindMax(HoTSQueue OldQueue)
        {
            int Max = int.MinValue;
            HoTSQueue NewQueue = new HoTSQueue();

            if (!OldQueue.QueueIsEmpty())
                do
                {
                    NewQueue.InQueue(OldQueue.OutQueue());
                    if (NewQueue.QueueTail.NodeQueueValue > Max)
                        Max = NewQueue.QueueTail.NodeQueueValue;
                }
                while (!OldQueue.QueueIsEmpty());
            return Max;
        }

        public static int FindMaxCount(HoTSQueue OldQueue)
        {
            int Count = 0;
            HoTSQueue NewQueue = new HoTSQueue();
            int Max = FindMax(OldQueue);
            if (!OldQueue.QueueIsEmpty())
                do
                {
                    NewQueue.InQueue(OldQueue.OutQueue());
                    if (NewQueue.QueueTail.NodeQueueValue == Max)
                        Count++;
                }
                while (!OldQueue.QueueIsEmpty());
            return Count;
        }
    }

}
