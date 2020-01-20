using Microsoft.Extensions.Configuration;
using System;
using System.Threading;

namespace PrinterApp.Services
{
    public class Printer
    {
        protected long MILLIS_PER_PAGE;      
        private static readonly object _locker = new object();
        private static bool _showMensagemImpressao = false;
        private bool _turnOff = false;

        public Printer(IConfiguration configuration, string name, CircularQueue queue)
        {
            MILLIS_PER_PAGE = Convert.ToInt64(configuration["IntervalPerPage"]);

            Thread thread = new Thread(() =>
            {
                lock (_locker)
                {
                    var numberOfJobs = queue.GetNumberOfJobs();                   

                    while (numberOfJobs != 0)
                    {
                        if (queue.GetNumberOfJobs() > 0)
                        {                           
                            var queueRemoved = queue.RemoveFront();
                            Console.WriteLine($"[{name}]: Imprimindo {queueRemoved.GetJobName()}...");
                            var timeOnSecond = (queueRemoved.GetNumberOfPages() * MILLIS_PER_PAGE) / 1000;
                            var count = 0;

                            while (count < timeOnSecond)
                            {
                                Thread.Sleep(1000);
                                count++;
                            }

                            _showMensagemImpressao = true;
                            Console.WriteLine($"[{name}]: {queueRemoved.GetJobName()} ok.");
                        }
                        else
                        {
                            if (_showMensagemImpressao)
                            {
                                Console.WriteLine("Esperando por trabalho de impressão...");
                                _showMensagemImpressao = false;
                            }
                        }

                        if (_turnOff)
                        {
                            Environment.Exit(0);
                        }
                    }
                }
            });

            thread.Start();
        }

        public void Halt()
        {
            _turnOff = true;
        }
    }
}
