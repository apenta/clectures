using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public partial class LectureExample
    {

        /*
        7. This method uses an if to check to make sure that one is equal to one.
            Make sure it returns TRUE when one equals one.
            TOPIC: Boolean Expression & Conditional Logic
        */
        public bool ReturnTrueWhenOneEqualsOne()
        {
            int a = 1;
            int b = 1;

            if (a == b)
            {
                return true;
            }

            return false;
        }

    }
}
