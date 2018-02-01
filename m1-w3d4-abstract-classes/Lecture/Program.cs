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


            List<ISingableItem> army = new List<ISingableItem>();

            army.Add(new Cow());
            army.Add(new Duck());
            army.Add(new Chicken());
            army.Add(new Pig());
            army.Add(new Chicken());
            army.Add(new Tractor("Lil Toot Toot"));


            Console.WriteLine("Old MacDonald had a farm ee ay ee ay oh");

            foreach(ISingableItem animal in army)
            {                
                Console.WriteLine("And on his farm there was a " + animal.Name + " ee ay ee ay oh");
                Console.WriteLine("With a " + animal.MakeSoundTwice() + " here and a " + animal.MakeSoundTwice() + " there");
                Console.WriteLine("Here a " + animal.MakeSoundOnce() + ", there a " + animal.MakeSoundOnce() + " everywhere a " + animal.MakeSoundTwice());
                Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
                Console.WriteLine();
            }
            



        }
    }
}
