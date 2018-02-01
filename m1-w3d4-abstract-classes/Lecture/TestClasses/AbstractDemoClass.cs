using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.TestClasses
{
    public abstract class AbstractDemoClass
    {
        // Inheritance benefit
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        // Interface benefit
        public abstract string SubclassSpecialMethod();

    }
}
