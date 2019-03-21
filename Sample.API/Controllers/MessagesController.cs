﻿using Microsoft.AspNetCore.Http;
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
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

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
