using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Domain.Abstract;
using Sample.Domain.Entities;
using Sample.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.API.Controllers
{

    /// <summary>
    /// The MessagesController class.
    /// Exposes a RESTful API to interact with a message repository.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;


        /// <summary>Initializes a new instance of the <see cref="MessagesController"/> class.</summary>
        /// <param name="messageRepository">The message repository.</param>
        /// <exception cref="ArgumentNullException">messageRepository</exception>
        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
        }

        /// <summary>
        /// Gets a list of all messages.
        /// </summary>
        /// <returns>A task representing the list of all messages.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> Get()
        {
            return Ok(await _messageRepository.FindAllAsync());
        }
    }
}
