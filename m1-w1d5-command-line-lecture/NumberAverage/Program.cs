using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.Write("Hello, what is your name?: ");
            string name = Console.ReadLine();

            //Console.WriteLine("Hello " + name); 
            Console.WriteLine($"Hello {name}");

            Console.Write($"Ok {name}, how many numbers do you want to average?: ");

            // Prompt the user for a number
            string input = Console.ReadLine();
            int number = int.Parse(input);

            // int number = int.Parse(Console.ReadLine());

            int sum = 0;

            for(int i = 1; i <= number; i++)
            {
                Console.Write($"Enter number {i} ");

                input = Console.ReadLine();
                sum += int.Parse(input);

                
            }

            double average = (double)sum / number;
            Console.WriteLine($"The average is {average}");
        }
    }
}
