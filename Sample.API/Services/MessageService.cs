using Sample.Domain.Abstract;
using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.API.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository 
                ?? throw new ArgumentNullException(nameof(messageRepository));
        }
        
        public async Task<IEnumerable<Message>> FindAllAsync()
        {
            return await _messageRepository.FindAllAsync();
        }
        
        public async Task<Message> FindByIdAsync(Guid id)
        {
            return (await _messageRepository.FindByIdAsync(id));
        }
    }
}
