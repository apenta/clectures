using CLI.ConsoleApp.CLIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenuCLI mainmenu = new MainMenuCLI();
            mainmenu.Display();
        }
    }
}
