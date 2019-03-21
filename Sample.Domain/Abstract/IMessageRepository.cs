using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Domain.Abstract
{
    /// <summary>
    /// Describes the functionality of a Message Repository.
    /// </summary>
    public interface IMessageRepository
    {

        /// <summary>Asynchronously retrieves all messages.</summary>
        /// <returns>A task representing an enumerable of all messages.</returns>
        Task<IEnumerable<Message>> FindAllAsync();
    }
}
