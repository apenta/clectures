using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    public class Change
    {
        //Private Variables
        private int quarters;
        private int dimes;
        private int nickels;

        //Properties
        public int Quarters
        {
            get { return quarters; }
        }

        public int Dimes
        {
            get { return dimes; }
        }

        public int Nickels
        {
            get { return nickels; }
        }
        
        /// <summary>
        /// CONSTRUCTOR: Creates a Change object.
        /// </summary>
        /// <param name="amountInCents">Represents the total amount in cents (e.g. $1.59 is 159)</param>
        public Change(decimal amount)
        {
            int tempAmount = (int)(amount * 100);

            while (tempAmount > 0)            
            {
                if (tempAmount >= 25)
                {
                    quarters++;
                    tempAmount = tempAmount - 25;
                }
                else if (tempAmount >= 10)
                {
                    dimes++;
                    tempAmount = tempAmount - 10;
                }
                else if (tempAmount >= 5)
                {
                    nickels++;
                    tempAmount = tempAmount - 5;
                }
            }
        }
    }
}
