using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.MessageRepository;

namespace RealEstate_Dapper_Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase {
        private readonly IMessageRepository _messageRepository;

        public MessageController(IMessageRepository messageRepository) {
            _messageRepository = messageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetInboxLast3MessageListByReciever(int id) {
            var values = await _messageRepository.GetInboxLast3MessageListByReciever(id);
            return Ok(values);
        }
    }
}
