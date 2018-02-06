using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.Exceptions
{
    public class OverdraftException : Exception
    {

        public OverdraftException() : base() { }
        public OverdraftException(string message) : base(message) { }
        public OverdraftException(string message, Exception inner) : base(message, inner) { }
    }
}
