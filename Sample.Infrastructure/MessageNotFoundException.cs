using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure
{
    public class MessageNotFoundException : Exception
    {
        public MessageNotFoundException()
        {

        }

        public MessageNotFoundException(string message) 
            : base(message)
        {

        }

        public MessageNotFoundException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
