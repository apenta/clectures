using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Tractor : ISingableItem, IRepairableItem  // implements the ISingableItem interface
    {
        public string Name { get; }

        public int Health => throw new NotImplementedException();

        public Tractor(string name)
        {
            this.Name = name;
        }


        public string MakeSoundOnce()
        {
            return "TOOT";
        }

        public string MakeSoundTwice()
        {
            return "TOOT TOOT!";
        }

        public void Repair()
        {
            throw new NotImplementedException();
        }
    }
}
