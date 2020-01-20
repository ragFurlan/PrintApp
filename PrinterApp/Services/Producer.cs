using PrinterApp.Interfaces;
using System;
using System.Threading;

namespace PrinterApp.Services
{
    public class Producer : Base.BaseProducer
    {
        private readonly IQueue _queue;

        public Producer(string nome, CircularQueue queue)
        {
            _queue = queue;

            Random numbeRandom = new Random();

            Thread thread = new Thread(() =>
            {  
                if (QueuePrint.Count == 0) return;

                var queuePrint = QueuePrint.Dequeue();

                if (queuePrint != null)
                {
                    Console.WriteLine($"#{nome}#: produzindo arquivo '{queuePrint.NameQueue}', número de páginas {queuePrint.PageQueue}.");
                    var print = new PrintJob(queuePrint.NameQueue, queuePrint.PageQueue);
                    _queue.AddBack(print);                    
                }

                int numberOfSeconds = numbeRandom.Next(1, 5);
                var count = 0;

                while (count < numberOfSeconds)
                {
                    Thread.Sleep(1000);
                    count++;
                }
            });

            thread.Start();
        }
    }
}
