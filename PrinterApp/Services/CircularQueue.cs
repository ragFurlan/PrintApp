using PrinterApp.Interfaces;
using System.Threading;
using XPTeste.Util;

namespace PrinterApp.Services
{
    public class CircularQueue : Base.Base, IQueue
    {
        public CircularQueue(int capacity)
        {
            object _locker = 0;

            Thread thread = new Thread(() =>
            {
                lock (_locker)
                {
                    var numberOfJobs = GetNumberOfJobs();

                    if(numberOfJobs >= capacity)
                    {
                        throw new FullQueueException("The queue is full!");
                    }                  
                    
                }
            });

            thread.Start();           
        }

        public void AddBack(PrintJob job)
        {
            QueueList.Enqueue(job);
        }

        public int GetNumberOfJobs()
        {
            return QueueList.Count;
        }

        public bool IsEmpty()
        {
            return QueueList.Count == 0;
        }

        public PrintJob RemoveFront()
        {
            return QueueList.Dequeue();
        }
    }
}
