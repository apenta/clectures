using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.ConsoleApp.CLIs
{
    public class MainMenuCLI
    {
        public void Display()
        {
            PrintHeader();
            
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("1] >> Option 1");
                Console.WriteLine("2] >> Submenu 1");
                Console.WriteLine("Q] >> Quit");

                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Performing menu option 1");
                }
                else if (input == "2")
                {
                    Submenu1CLI submenu = new Submenu1CLI();
                    submenu.Display();
                }               
                else if (input == "Q")
                {
                    Console.WriteLine("Quitting");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }
            }
        }

        private void PrintHeader()
        {

            Console.WriteLine("WELCOME!!!!");
        }
    }
}
