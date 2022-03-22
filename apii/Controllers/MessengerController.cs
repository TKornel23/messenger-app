using apii.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apii.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessengerController : ControllerBase
    {
        DataContext ctx;
        IHubContext<SignalRHub> hub;

        public MessengerController(IHubContext<SignalRHub> hub, DataContext _ctx)
        {
            this.hub = hub;
            this.ctx = _ctx;
        }

        [HttpPost]
        public void Create([FromBody] Message message)
        {
            ctx.Messages.Add(message);
            this.hub.Clients.All.SendAsync("MessageCreated", message);
        }

        [HttpGet]
        public IEnumerable<Message> GetAll()
        {
            return ctx.Messages;
        }
    }
}
