using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Web.Hubs;

namespace Web.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IHubContext<Chat> _chatHub;
        public ChatController(IHubContext<Chat> chatHub)
        {
            _chatHub = chatHub;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetActiveUsers()
        {
            return Ok(Chat.AcitveUsers);
        }
    }
}
