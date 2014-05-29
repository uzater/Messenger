using System;
using System.ServiceModel;
using MessengerServiceLib;
using MessengerServiceLib.DataBase;

namespace MessengerServiceHost
{
    internal class Program
    {
        private static void Main()
        {
            #region Data Base configuration

            DataBaseConnection.DBName = "Messenger";
            DataBaseConnection.DBHost = "localhost";
            DataBaseConnection.DBUser = "root";
            DataBaseConnection.DBPass = "pass";

            #endregion

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