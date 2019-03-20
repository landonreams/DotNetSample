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
        private readonly ConcurrentDictionary<Guid, Message> _messages;

        /// <summary>Initializes a new instance of the <see cref="InMemoryMessageRepository"/> class.</summary>
        /// <param name="messages">The messages.</param>
        public InMemoryMessageRepository(IEnumerable<Message> messages)
        {
            _messages = new ConcurrentDictionary<Guid, Message>(messages.ToDictionary(m => m.Id, m => new Message(m)));
        }

        /// <summary>Finds all messages asynchronously.</summary>
        /// <returns>A task .</returns>
        public Task<IEnumerable<Message>> FindAllAsync()
        {
            return Task.FromResult(_messages.Values.AsEnumerable());
        }

        /// <summary>Asynchronously finds a message by an ID.</summary>
        /// <param name="id">The message ID.</param>
        /// <returns></returns>
        /// <exception cref="MessageNotFoundException"></exception>
        public Task<Message> FindByIdAsync(Guid id)
        {
            if (_messages.TryGetValue(id, out var value))
            {
                return Task.FromResult(value);
            }
            throw new MessageNotFoundException();
        }

        public Task<Message> CreateAsync(Message entity) => throw new NotSupportedException();
        public Task<Message> DeleteAsync(Message entity) => throw new NotSupportedException();
        public Task<Message> UpdateAsync(Message entity) => throw new NotSupportedException();
    }
}
