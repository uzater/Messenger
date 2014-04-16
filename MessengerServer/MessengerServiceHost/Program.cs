using System;
using System.ServiceModel;
using MessengerServiceLib;

namespace MessengerServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Messenger Server in running...");

            using (ServiceHost serviceHost = new ServiceHost(typeof(MessengerService)))
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
