using Microsoft.AspNetCore.SignalR;

namespace CoreAndFood.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage");
        }
    }
}
