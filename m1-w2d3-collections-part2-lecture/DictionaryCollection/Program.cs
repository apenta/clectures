using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Person / Height Database");
            Console.WriteLine();

            Console.Write("Would you like to enter another person (yes/no)? ");
            string input = Console.ReadLine().ToLower();

            // 1. Let's create a new Dictionary that could hold string, ints
            //      | "Josh"    | 70 |
            //      | "Bob"     | 72 |
            //      | "John"    | 75 |
            //      | "Jack"    | 73 |

            while (input == "yes" || input == "y")
            {
                Console.Write("What is the person's name?: ");
                string name = Console.ReadLine();

                Console.Write("What is the person's height?: ");
                int height = int.Parse(Console.ReadLine());

                // 2. Put the name and height into the dictionary
                //      dictionaryVariable[key] = value;
                //      OR dictionaryVariable.Add(key, value);


                Console.Write("Would you like to enter another person (yes/no)? ");
                input = Console.ReadLine().ToLower();
            }

            Console.Write("Type \"all\" to print all names OR \"search\" to print out single name: ");
            input = Console.ReadLine().ToLower();

            if (input == "search")
            {
                Console.Write("Which name are you looking for? ");
                input = Console.ReadLine();

                //3. Let's print a specific name from the dictionary


            }
            else if (input == "all")
            {                
                Console.WriteLine();
                Console.WriteLine(".... printing ...");

                //4. Let's print each item in the dictionary


            }
        }

        static void PrintDictionary(Dictionary<string, int> dictionary)
        {
            // Looping through a dictionary involves using a foreach loop
            // to look at each item, which is a key-value pair
        }
    }
}
