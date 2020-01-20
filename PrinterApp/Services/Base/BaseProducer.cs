using PrinterApp.Model;
using PrinterApp.Repositories;
using System.Collections.Generic;

namespace PrinterApp.Services.Base
{
    public class BaseProducer
    {
        public static Queue<QueueModel> QueuePrint = new QueueRepository().GetListQueues();
    }
}
