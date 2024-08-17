using Lesson_2_Part_2.Classes.Action;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Lesson_2_Part_2.Hubs;
using Lesson_2_Part_2.Interfaces;

namespace Lesson_2_Part_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly IHubContext<CompanyHub> _hubContext;
        private readonly IInputOutput _messageService;

        public CompanyController(IHubContext<CompanyHub> hubContext, IInputOutput messageService)
        {
            _hubContext = hubContext;
            _messageService = messageService;
            _messageService.onMessageReceived += async (message) =>
            {
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", "System", message);
            };
        }

        [HttpPost]
        public IActionResult PostMessage([FromBody] string message)
        {
            _messageService.ReceiveMessage(message);
            return Ok();
        }
    }
}
