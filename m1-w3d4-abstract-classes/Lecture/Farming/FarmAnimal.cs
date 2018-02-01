using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    
    //public class FarmAnimal : ISingableItem <-- this can be instantiated
    public abstract class FarmAnimal : ISingableItem
    {
        public string Name { get; protected set; }

        public bool IsAwake { get; }

        public FarmAnimal(bool isAwake)
        {
            this.IsAwake = isAwake;
        }

        // we dont want this to be overridden
        public string MakeSoundOnce()
        {
            if (IsAwake)
            {
                // this is where i want the animal to make its sound
                return MakeAwakeSoundOnce();
            }
            else
            {
                return "ZZZ";
            }
        }

        protected abstract string MakeAwakeSoundOnce();
        protected abstract string MakeAwakeSoundTwice();


        public string MakeSoundTwice()
        {
            if (IsAwake)
            {
                // this is where i want the animal to make two of its sounds
                return MakeAwakeSoundTwice();
            }
            else
            {
                return "ZZZ ZZZ";
            }
        }

    }
}
