using Microsoft.Extensions.Configuration;
using PrinterApp.Services;
using System;
using System.IO;
using System.Timers;

namespace PrinterApp
{
    class Program
    {
        private static Timer _timer;
        private static IConfiguration _configuration;
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            SetConfiguration();
            Console.WriteLine("Ligando...");

            InicializeTimer();          

            _timer.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                var queue = new CircularQueue(Convert.ToInt32(_configuration["Capacity"]));

                new Producer("Producer1", queue);
                System.Threading.Thread.Sleep(2000);
                new Producer("Producer2", queue);

                if (queue.GetNumberOfJobs() > 0)
                {
                    new Printer(_configuration, "Printer", queue);
                }
            };

            Console.Read();
            DisposeServices();
        }

        private static void SetConfiguration()
        {
            _configuration = new ConfigurationBuilder()
                                               .SetBasePath(Directory.GetCurrentDirectory())
                                               .AddJsonFile("appSettings.json").Build();
        }

        private static void InicializeTimer()
        {
            _timer = new Timer
            {
                Interval = TimeSpan.FromSeconds(Convert.ToInt32(_configuration["IntervalSeconds"])).TotalMilliseconds,
                Enabled = true
            };
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }

    }
}
