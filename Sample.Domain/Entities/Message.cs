using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Domain.Entities
{
    /// <summary>The Message structure.</summary>
    public struct Message
    {
        /// <summary>
        /// The Message's text.
        /// </summary>
        public string Text { get; }

        public Message(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Clones another <see cref="Message"/> struct into this one.
        /// </summary>
        /// <param name="other">The source Message.</param>
        public Message(Message other)
            : this(other.Text)
        {            
        }
    }
}
