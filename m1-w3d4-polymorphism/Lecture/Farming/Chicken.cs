
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Chicken
    {        
        public string NameOfAnimal
        {
            get
            {
                return "Chicken";
            }
        }      

        public string MakeSoundOnce()
        {
            return "Cluck";
        }

        public string MakeSoundTwice()
        {
            return "Cluck Cluck";
        }

        // Kind of a neat trick you may see the above written like this below
        // http://bit.ly/2nui9HV
        // This is called "Expression-Bodied Members" and its new in C# (2015).
        // You can write a single expression in place of the return code.
        /*
        public string NameOfAnimal
        {
            get => "Chicken";
        }
        public string MakeSoundOnce() => "Cluck";
        public string MakeSoundTwice() => "Cluck Cluck";
        */

    }
}
