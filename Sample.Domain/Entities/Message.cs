using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Domain.Entities
{
    public struct Message
    {
        public string Text { get; }

        public Message(string text)
        {
            Text = text;
        }

        public Message(Message other)
            : this(other.Text)
        {            
        }
    }
}
