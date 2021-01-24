using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserMicroserviceApi.Adapters;
using UserMicroserviceApi.DbContextModel;
using UserMicroserviceApi.Dtos;
using UserMicroserviceApi.Model;
using UserMicroserviceApi.Repository;
using UserMicroserviceApi.Service;

namespace UserMicroserviceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private MessageService messageService;
        private MyDbContext dbContext;

        public MessageController(MyDbContext dbContext)
        {
            messageService = new MessageService(new MessageRepository(dbContext));
            this.dbContext = dbContext;    
        }

        /// <summary> This method is calling <c>MessageService</c> to get list of all messages. </summary>
        /// <returns> 200 Ok with list of all messages. </returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(messageService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(MessageDto dto)
        {
            Message message = messageService.Create(dto);

            if (message == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(MessageAdapter.MessageDTOtoMessage(dto));
            }
        }
    }
}
