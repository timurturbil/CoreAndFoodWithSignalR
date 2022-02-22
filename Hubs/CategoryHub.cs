using CoreAndFood.Models;
using Microsoft.AspNetCore.SignalR;

namespace CoreAndFood.Hubs
{
    public class CategoryHub : Hub
    {
        public async Task SendCategory()
        {
            await Clients.All.SendAsync("ReceiveCategory");
        }
    }
}
