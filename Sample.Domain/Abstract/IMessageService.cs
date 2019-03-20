using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Abstract
{
    public interface IMessageService
    {
        Task<Message> FindByIdAsync(Guid id);
        Task<IEnumerable<Message>> FindAllAsync();
    }
}
