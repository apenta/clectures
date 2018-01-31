using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Pig : FarmAnimal
    {
        public Pig()
        {
            Name = "Pig";
        }

        public override string MakeSoundOnce()
        {
            return "OINK!";
        }

        public override string MakeSoundTwice()
        {
            return "OINK OINK!";
        }
    }
}
