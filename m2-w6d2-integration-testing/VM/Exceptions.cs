using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    public class VendingMachineException : Exception
    {
        public VendingMachineException(string message) : base(message)
        {
        }
    }

    public class InvalidSlotIDException : VendingMachineException
    {
        public InvalidSlotIDException(string message) : base(message)
        {
        }
    }

    public class OutOfStockException : VendingMachineException
    {
        public OutOfStockException(string message) : base(message)
        {
        }
    }

    public class InsufficientFundsException : VendingMachineException
    {
        public InsufficientFundsException(string message) : base(message)
        {
        }
    }


}
