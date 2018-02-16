using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
           

            while (true)
            {
                Console.WriteLine("MENU\n");


                Console.WriteLine("1. Get Male Dogs");
                Console.WriteLine("2. Get Female Dogs");
                Console.WriteLine("3. Get Dogs By Breed");
                Console.WriteLine(" ---- LINQ WAY ---- ");
                Console.WriteLine("4. Get Male Dogs");
                Console.WriteLine("5. Get Female Dogs");
                Console.WriteLine("6. Get Dogs By Breed");
                Console.WriteLine("7. Name of youngest golden retriever.");
                Console.WriteLine("8. Names of all dogs");

                Console.Write("PICK AN OPTION: ");
                string input = Console.ReadLine();

                Console.Clear();

                var pack = Dog.GetAllDogs();

                switch (input)
                {
                    case "1":
                        var maleDogs = GetMaleDogs(pack);
                        PrintToScreen("MALE DOGS:", maleDogs);
                        break;

                    case "2":
                        var femaleDogs = GetFemaleDogs(pack);
                        PrintToScreen("FEMALE DOGS: ", femaleDogs);
                        break;

                    case "3":
                        Console.Write("TYPE A BREED: ");
                        input = Console.ReadLine();
                        var breedDogs = GetDogsByBreed(pack, input);
                        PrintToScreen("DOGS BY BREED: ", breedDogs);
                        break;

                    // LINQ

                    case "4":
                        var maleDogsResult = pack.Where(dog => dog.IsMale);
                        PrintToScreen("MALE DOGS THE LINQ WAY: ", maleDogsResult);
                        break;

                    case "5":
                        var femaleDogsResult = pack.Where(dog => !dog.IsMale);
                        PrintToScreen("FEMALE DOGS THE LINQ WAY: ", femaleDogsResult);
                        break;

                    case "6":
                        Console.Write("TYPE A BREED: ");
                        input = Console.ReadLine();

                        var dogsByBreed = pack.Count(dog => dog.Breed == input);
                        Console.WriteLine($"There are {dogsByBreed} {input}s");
                        break;

                    case "7":
                        //var firstLab = pack.First(d => d.Breed == "Lab");
                        var nameOfYoungestGoldenRetriever = pack.Where(dog => dog.Breed == "Golden Retriever")
                            .Where(dog => dog.DateOfBirth < new DateTime(2000, 1, 1))
                            .Where(dog => dog.Weight > 20)
                            .OrderByDescending(dog => dog.DateOfBirth)
                            .First()
                            .Name;

                        Console.WriteLine("The name of the youngest golden retriever is: " + nameOfYoungestGoldenRetriever);

                        break;

                    case "8":
                        pack.ToList().ForEach(dog =>
                        {
                            dog.Name = dog.Name.ToUpper();
                        });
                        var namesOfDogs = pack.Select(d => d.Name).ToList();
                        namesOfDogs.ForEach(s => Console.WriteLine(s));
                        break;
                }



                Console.ReadLine();
                Console.Clear();
            }

        }

        private static bool DogIsSpecial(Dog d)
        {
            return d.Breed == "Golden Retriever" && d.Weight > 20 && d.DateOfBirth < new DateTime(2000, 1, 1);
        }


        private static IList<Dog> GetMaleDogs(IList<Dog> dogs)
        {
            List<Dog> result = new List<Dog>();

            foreach (var dog in dogs)
            {
                if (dog.IsMale)
                {
                    result.Add(dog);
                }
            }

            return result;
        }

        private static IList<Dog> GetFemaleDogs(IList<Dog> dogs)
        {
            List<Dog> result = new List<Dog>();

            foreach (var dog in dogs)
            {
                if (!dog.IsMale)
                {
                    result.Add(dog);
                }
            }

            return result;
        }

        private static IList<Dog> GetDogsByBreed(IList<Dog> dogs, string breed)
        {
            List<Dog> result = new List<Dog>();

            foreach (var dog in dogs)
            {
                if (dog.Breed == breed)
                {
                    result.Add(dog);
                }
            }

            return result;
        }

        private static Dog GetYoungestDog(IList<Dog> dogs)
        {
            Dog youngestDog = null;


            return youngestDog;
        }


        #region Helper Code
        private static void PrintToScreen(string message, IEnumerable<Dog> dogs)
        {
            Console.WriteLine(message);
            Console.WriteLine();
            foreach (var dog in dogs)
            {
                Console.WriteLine(dog);
            }
        }
        #endregion

    }
}
