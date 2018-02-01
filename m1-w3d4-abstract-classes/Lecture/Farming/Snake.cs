using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Snake : FarmAnimal
    {
        public Snake(bool isAwake) : base(isAwake)
        {
            Name = "SNAKE";
        }

        protected override string MakeAwakeSoundOnce()
        {
            throw new NotImplementedException();
        }

        //protected override string MakeAwakeSoundOnce()
        //{
        //    return "SSSS";
        //}

        protected override string MakeAwakeSoundTwice()
        {
            return "SSSS SSSS";
        }
    }
}
