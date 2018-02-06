using Lecture.Aids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example Code, located in Aids folder
            //ReadingInFiles.ReadACharacterFile();
            //ReadingCSVFiles.ReadFile();
            //SummingUpNumbers.ReadFile();         

            // Let's read in a file
            //
            //  ABC-1234|Shadow|Lab|Black|12/2/2016
            //  DEF-5678|Sprinkles|Yorkshire Terrier|Brown|6/5/2015
            //  GHI-9012|Neo|Golden Retriever|Red|6/1/2013
            Dictionary<string, Dog> database = BuildAnimalDatabase();

            Console.WriteLine("Printing license numbers:");
            foreach(string licenseNumber in database.Keys)
            {
                Console.WriteLine(licenseNumber);
            }

            Console.WriteLine("Which dog do you want to see: ");
            string license = Console.ReadLine();

            if (database.ContainsKey(license))
            {
                Console.WriteLine(database[license].Name);
                Console.WriteLine(database[license].Breed);
                Console.WriteLine(database[license].Color);            
                Console.WriteLine(database[license].DOB);
            }
            else
            {
                Console.WriteLine("Dog does not exist.");
            }

        }

        private static Dictionary<string, Dog> BuildAnimalDatabase()
        {
            Dictionary<string, Dog> database = new Dictionary<string, Dog>();

            try
            {
                using (StreamReader sr = new StreamReader("dogs.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        //string[] fields = line.Split('|');
                        Dog dog = GetDogFromLine(line);
                        //database.Add(dog.License, dog);
                        database[dog.License] = dog;

                        //Console.WriteLine(line);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Something went wrong opening the file.");
                Console.WriteLine(ex.Message);
            }

            return database;
        }



        private static Dog GetDogFromLine(string line)
        {
            Dog dog = new Dog();

            string[] fields = line.Split('|');

            dog.License = fields[0];
            dog.Name = fields[1];
            dog.Breed = fields[2];
            dog.Color = fields[3];
            dog.DOB = DateTime.Parse(fields[4]);

            return dog;
        }
    }
}
