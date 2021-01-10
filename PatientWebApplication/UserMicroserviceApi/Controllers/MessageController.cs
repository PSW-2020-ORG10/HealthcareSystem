using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserMicroserviceApi.DbContextModel;
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
    }
}
