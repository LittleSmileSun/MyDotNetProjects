using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dz6Filtering
{
    public class NoRandomInstanceException : Exception
    {
        public NoRandomInstanceException()
        {
            Console.WriteLine("NoRandomInstanceException");
        }

        public NoRandomInstanceException(string message)
            : base(message)
        {
            Console.WriteLine("NoRandomInstanceException:" , message);
        }

        public NoRandomInstanceException(string message, Exception inner)
            : base(message, inner)
        {
            Console.WriteLine("NoRandomInstanceException:", message, inner.Message.Length);
        }
    }
}
