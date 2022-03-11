using CoreAndFood.Hubs;
using CoreAndFood.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CoreAndFood.Controllers
{
    public class ServerController : Controller
    {
        private readonly IHubContext<ChatHub> _chatHub;
        public ServerController(IHubContext<ChatHub> chatHub)
        {
            _chatHub = chatHub;
        }
        public IActionResult Index()
        {
            ViewBag.connectedUserIds = ConnectedUser.htUsers_ConIds;
            return View();
        }

        [HttpGet("Server/SetSelectedUser/{selectedUserId}")]
        public IActionResult SetSelectedUser(string selectedUserId)
        {
            ConnectedUser.selectedUserId = selectedUserId;
            return RedirectToAction("Index");
        }
    }
}
