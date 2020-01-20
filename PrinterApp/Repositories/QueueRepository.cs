
using PrinterApp.Model;
using System.Collections.Generic;

namespace PrinterApp.Repositories
{
    public class QueueRepository
    {
        public Queue<QueueModel> GetListQueues()
        {
            var queueList = new Queue<Model.QueueModel>();
           
            queueList.Enqueue(new QueueModel() { NameQueue = "rocho.txt", PageQueue = 12 });
            queueList.Enqueue(new QueueModel() { NameQueue = "rosa.txt", PageQueue = 2 });
            queueList.Enqueue(new QueueModel() { NameQueue = "rosado.txt", PageQueue = 15 });
            queueList.Enqueue(new QueueModel() { NameQueue = "laranja.txt", PageQueue = 6 });
            queueList.Enqueue(new QueueModel() { NameQueue = "bege.txt", PageQueue = 15 });
            queueList.Enqueue(new QueueModel() { NameQueue = "preto.txt", PageQueue = 11 });
            queueList.Enqueue(new QueueModel() { NameQueue = "prata.txt", PageQueue = 19 });
            queueList.Enqueue(new QueueModel() { NameQueue = "dourado.txt", PageQueue = 7 });
            queueList.Enqueue(new QueueModel() { NameQueue = "vermelho.txt", PageQueue = 2 });
            queueList.Enqueue(new QueueModel() { NameQueue = "amarelo.txt", PageQueue = 3 });
            queueList.Enqueue(new QueueModel() { NameQueue = "verde.txt", PageQueue = 10 });
            queueList.Enqueue(new QueueModel() { NameQueue = "azul.txt", PageQueue = 14 });

            return queueList;
        }
    }
}
