using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Domain.Abstract
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> FindAllAsync();
    }
}
