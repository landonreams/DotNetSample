using Sample.Domain.Abstract;
using Sample.Domain.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Infrastructure
{
    public class InMemoryMessageRepository : IMessageRepository
    {
        private readonly ConcurrentBag<Message> _messages;

        /// <summary>Initializes a new instance of the <see cref="InMemoryMessageRepository"/> class.</summary>
        /// <param name="messages">The messages.</param>
        public InMemoryMessageRepository(IEnumerable<Message> messages)
        {
            // Clone the messages to prevent potential string manipulation via unmanaged code
            _messages = new ConcurrentBag<Message>(messages.Select(m => new Message(m)));
        }

        /// <summary>Finds all messages asynchronously.</summary>
        /// <returns>A task that represents the entire collection.</returns>
        public Task<IEnumerable<Message>> FindAllAsync()
        {
            return Task.FromResult(_messages.AsEnumerable());
        }
        
        public Task<Message> CreateAsync(Message entity) => throw new NotSupportedException();
        public Task<Message> DeleteAsync(Message entity) => throw new NotSupportedException();
        public Task<Message> UpdateAsync(Message entity) => throw new NotSupportedException();
    }
}
