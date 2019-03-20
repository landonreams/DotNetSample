using Sample.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Domain.Abstract
{
    public interface IMessageRepository : IRepository<Message>
    {
    }
}
