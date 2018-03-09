
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjection.Lecture.DeliveryProviders;

namespace DependencyInjection.Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to our delivery service program.");
                Console.WriteLine("Please choose one of the following delivery options.");
                Console.WriteLine("1 - Console Delivery");
                Console.WriteLine("2 - File Delivery");
                Console.WriteLine("3 - Email Delivery");
                Console.WriteLine("4 - SMS Delivery");
                Console.WriteLine();

                string choice = CLIHelper.GetString("Make a choice > ");


                IDeliveryService ds = null;
                switch (choice)
                {
                    case "1":
                        ds = new ConsoleDeliveryService();
                        break;

                    case "2":
                        ds = new FileDeliveryService();
                        break;

                    case "3":
                        ds = new EmailDeliveryService();                        
                        break;

                    case "4":
                        ds = new SMSDeliveryService();
                        break;
                }
                CLI cli = new CLI(ds);
                cli.Run();


                string sendAgain = CLIHelper.GetString("Type Y to send another message >");
                if(sendAgain != "Y")
                {
                    return;
                }
            }

           
        }
    }
}

