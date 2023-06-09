﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRExample.Hubs;

namespace SignalRExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<MyHub> _hubContext;

        public NotificationController(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }


        [HttpGet("{teamCount}")]
        public async Task<IActionResult> Index(int teamCount)
        {
            await _hubContext.Clients.All.SendAsync("Notify", $"ardaşlar takımlar {teamCount} kadar olacaktır.");
            return Ok();
        }

    }
}
