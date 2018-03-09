using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Lecture.DeliveryProviders
{
    public class ConsoleDeliveryService : IDeliveryService
    {

        public void Send(string recipient, string message)
        {
            Console.WriteLine($"MESSAGE FOR > {recipient}");
            Console.WriteLine($"MESSAGE > {message}");
        }

    }
}
