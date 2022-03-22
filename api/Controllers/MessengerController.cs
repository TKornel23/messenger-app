using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessengerController : ControllerBase
    {
        DataContext ctx;
        IHubContext<SignalRHub> hub;

        public MessengerController(IHubContext<SignalRHub> hub)
        {
            ctx = new DataContext();
            this.hub = hub;
        }

        [HttpPost]
        public void Create([FromBody] Message message)
        {
            ctx.Messages.Add(message);
            this.hub.Clients.All.SendAsync("MessageCreated", message);
        }

        [HttpGet]
        public IList<Message> GetAll()
        {
            return ctx.Messages;
        }
    }
}
