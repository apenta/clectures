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
            Dictionary<string, int> database = new Dictionary<string, int>()
            {
                {"Josh", 70 },
                {"Bob", 72 },
                {"John", 75 },
                {"Jack", 73 }
            };

            while (input == "yes" || input == "y")
            {
                Console.Write("What is the person's name?: ");
                string name = Console.ReadLine();

                Console.Write("What is the person's height (in inches)?: ");
                int height = int.Parse(Console.ReadLine());

                // 2. Check to see if that name is in the dictionary
                //      bool exists = dictionaryVariable.ContainsKey(key)
                bool exists = database.ContainsKey(name);    // <-- change this

                if (!exists)
                {
                    Console.WriteLine($"Adding {name} with new value.");
                    // 3. Put the name and height into the dictionary
                    //      dictionaryVariable[key] = value;
                    //      OR dictionaryVariable.Add(key, value);

                    database[name] = height;

                }
                else
                {
                    Console.WriteLine($"Overwriting {name} with new value.");
                    // 4. Overwrite the current key with a new value
                    //      dictionaryVariable[key] = value;
                    database[name] = height;

                }


                Console.WriteLine();
                Console.Write("Would you like to enter another person (yes/no)? ");
                input = Console.ReadLine().ToLower();
            }

            Console.Write("Type \"all\" to print all names OR \"search\" to print out single name: ");
            input = Console.ReadLine().ToLower();

            if (input == "search")
            {
                Console.Write("Which name are you looking for? ");
                input = Console.ReadLine();

                //5. Let's get a specific name from the dictionary
                if (database.ContainsKey(input))
                {
                    int height = database[input]; //<-- get the value out of the dictionary
                    Console.WriteLine($"{input} is {height} inches tall.");
                }
                else
                {
                    Console.WriteLine($"{input} does not exist.");
                }

            }
            else if (input == "all")
            {
                Console.WriteLine();
                Console.WriteLine(".... printing ...");

                //6. Let's print each item in the dictionary
                PrintDictionary(database);
            }

            Console.WriteLine();
            Console.WriteLine("Done...");

            //7. Let's get the average height of the people in the dictionary
            double averageHeight = GetAverageHeight(database);
            Console.WriteLine($"The average height is {averageHeight}");
        }

        static void PrintDictionary(Dictionary<string, int> dictionary)
        {
            // Looping through a dictionary involves using a foreach loop
            // to look at each item, which is a key-value pair
            foreach(var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} is {kvp.Value} inches tall.");
            }
        }


        static double GetAverageHeight(Dictionary<string, int> dictionary)
        {
            int sum = 0;

            foreach(var kvp in dictionary)
            {
                sum += kvp.Value;
            }

            return sum / (double)dictionary.Count;
        }

    }
}
