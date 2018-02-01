using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class FarmAnimal : ISingableItem
    {
        public string Name { get; protected set; }

        public virtual string MakeSoundOnce()
        {
            return "";
        }

        public virtual string MakeSoundTwice()
        {
            return "";
        }


    }
}
