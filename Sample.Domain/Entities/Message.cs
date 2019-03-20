using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Domain.Entities
{
    public struct Message
    {
        public Guid Id { get; }
        public string Text { get; }

        public Message(Guid? id, string text)
        {
            Id = id ?? Guid.NewGuid();
            Text = string.Copy(text);
        }

        public Message(string text)
            : this(null, text)
        {

        }

        public Message(Message other)
            : this(other.Id, other.Text)
        {
        }
    }
}
