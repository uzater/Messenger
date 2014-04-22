using System;
using System.ServiceModel;
using MessengerServiceLib;
using System.Timers;

namespace MessengerServiceHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Messenger Server in running...");

            using (var serviceHost = new ServiceHost(typeof (MessengerService)))
            {
                serviceHost.Open();

                Console.WriteLine();
                Console.WriteLine("Messenger service is ready.");
                Console.WriteLine("Press <Enter> to exit.");
                Console.ReadLine();
            }
        }
    }
}