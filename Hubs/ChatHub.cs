using CoreAndFood.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Collections;

namespace CoreAndFood.Hubs
{
    public class ChatHub : Hub
    {

        public override Task OnConnectedAsync()
        {
            string currentUserName = Context.User.Identity.Name;
            if (!ConnectedUser.htUsers_ConIds.ContainsKey(currentUserName))
            {
                ConnectedUser.htUsers_ConIds.Add(currentUserName, Context.ConnectionId);
            }
                
            //ConnectedUser.htUsers_ConIds[currentUserName] = Context.ConnectionId;
            //else
            //    ConnectedUser.htUsers_ConIds.Add(currentUserName, Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            ConnectedUser.Ids.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
        public async Task SendMessage()
        {
            //Client(ConnectedUser.selectedUserId)
            await Clients.Client(ConnectedUser.selectedUserId).SendAsync("ReceiveMessage");
        }
    }
}
