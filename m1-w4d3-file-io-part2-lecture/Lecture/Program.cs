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
            BinaryFileWriter.WritePrimitiveValues();
            BinaryImageManipulator.ReadFileIn();
            
            
            //string appdatapath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //Console.WriteLine(appdatapath);


            //Dictionary<string, string> hometowns = new Dictionary<string, string>()
            //{
            //    {"Josh", "Brunswick" },
            //    {"Craig", "Bainbridge" },
            //    {"JohnK", "Euclid" }
            //};

            //SaveDictionaryToFile(hometowns);
        }

        private static void SaveDictionaryToFile(Dictionary<string, string> hometowns)
        {
            if (!Directory.Exists("output"))
            {
                Directory.CreateDirectory("output");
            }

            

            try
            {
                // Open up a writer to save a new file
                using (StreamWriter sw = new StreamWriter(@"output\hometowns.txt", true))
                {
                    foreach(var kvp in hometowns) //loop thru dictionary
                    {
                        sw.WriteLine($"{kvp.Key} drove from {kvp.Value}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("There was an error saving the file.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
