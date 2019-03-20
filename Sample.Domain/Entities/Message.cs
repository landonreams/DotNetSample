using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Domain.Entities
{
    public class Message
    {
        public uint Id { get; }
        public string Text { get; }

        public Message(uint id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
