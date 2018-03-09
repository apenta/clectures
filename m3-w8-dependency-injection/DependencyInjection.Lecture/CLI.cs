using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjection.Lecture.DeliveryProviders;

namespace DependencyInjection.Lecture
{
    public class CLI
    {
        private IDeliveryService deliveryService;

        public CLI(IDeliveryService deliveryService)
        {
            this.deliveryService = deliveryService;
        }


        public void Run()
        {

            string recipient = CLIHelper.GetString("Who is the recipient >");
            string message = CLIHelper.GetString("What message should we send them >");


            this.deliveryService.Send(recipient, message);

            #region Old Code
            //ConsoleDeliveryService deliveryService = new ConsoleDeliveryService();
            //deliveryService.Send(recipient, message);

            //FileDeliveryService deliveryService = new FileDeliveryService();
            //deliveryService.Send(recipient, message);

            //EmailDeliveryService deliveryService = new EmailDeliveryService();
            //deliveryService.Send(recipient, message);
            #endregion

            Console.ReadLine();
        }

    }
}
