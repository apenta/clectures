using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Cow : FarmAnimal
    {

        public Cow(bool isAwake) : base(isAwake)
        {
            Name = "Cow";
        }


        //public override string MakeSoundOnce()
        //{
        //    if (IsAwake)
        //    {
        //        return "Moo";
        //    }
        //    else
        //    {
        //        return "ZZZ";
        //    }
        //}

        //public override string MakeSoundTwice()
        //{
        //    if (IsAwake)
        //    {
        //        return "Moo Moo";
        //    }
        //    else
        //    {
        //        return "ZZZ ZZZ";
        //    }
        //}

        


        public void Graze()
        {
            /// The cow grazes
        }

        protected override string MakeAwakeSoundOnce()
        {
            return "MOO";
        }

        protected override string MakeAwakeSoundTwice()
        {
            return "MOO MOO";
        }
    }
}
