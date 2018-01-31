using Lecture.Farming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {

            //
            // OLD MACDONALD
            //

            //Applying Polymorphism, we're allowed to work in terms of 
            // generic types and not concrete classes. In this case
            // the list holds a collection of IFarmAnimal, meaning
            // any class that implements the IFarmAnimal interface is allowed 
            // to be in the list.

            Chicken chicken = new Chicken();
            Cow cow = new Cow();
            Duck duck = new Duck();
            Pig wilbur = new Pig();

            //List<FarmAnimal> army = new List<FarmAnimal>();
            List<ISingableItem> army = new List<ISingableItem>();
            Stack<ISingableItem> stack = new Stack<ISingableItem>();

            //ISingableItem item = new ISingableItem(); //<-- not allowed here

            army.Add(new Cow());
            army.Add(new Duck());
            army.Add(new Chicken());
            army.Add(new Pig());
            army.Add(new Chicken());
            army.Add(new Tractor("Lil Toot Toot"));

            // Get the first item back out
            //FarmAnimal firstAnimal = army[0];
            //Cow firstCow = (Cow)army[0]; // Retrieve first item and cast to cow
            //Console.WriteLine(army[0]);  // Print out type of first animal

            Console.WriteLine("Old MacDonald had a farm ee ay ee ay oh");

            foreach(ISingableItem animal in army)
            {                
                Console.WriteLine("And on his farm there was a " + animal.Name + " ee ay ee ay oh");
                Console.WriteLine("With a " + animal.MakeSoundTwice() + " here and a " + animal.MakeSoundTwice() + " there");
                Console.WriteLine("Here a " + animal.MakeSoundOnce() + ", there a " + animal.MakeSoundOnce() + " everywhere a " + animal.MakeSoundTwice());
                Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
                Console.WriteLine();
            }
            

            // ----- THIS IS GETTING REPETITIVE! 
            // We can do better
            // How can we use what we've learned about inheritance
            // to help us remove code duplication
            // 


        }
    }
}
