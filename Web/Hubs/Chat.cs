using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Hubs
{
    public class Chat : Hub
    {
        public static List<SocketUser> AcitveUsers { get; set; }
        public Chat()
        {
            //AcitveUsers = new List<SocketUser>();
        }

        public override Task OnConnectedAsync()
        {
            ClaimsIdentity identity = Context.User.Identity as ClaimsIdentity;
            string userID = identity.Claims.First(x => x.Type == "UserID").Value;
            string fullName = identity.Claims.First(x => x.Type == "FullName").Value;
            AcitveUsers.Add(new SocketUser() { ConID = Context.ConnectionId, UserID = userID, FullName = fullName });

            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (AcitveUsers.Any(x => x.ConID == Context.ConnectionId))
                AcitveUsers.Remove(AcitveUsers.First(x => x.ConID == Context.ConnectionId));

            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string userID, string message)
        {
            await Clients.User(userID).SendAsync("receiveMessage", message);
        }

    }
}
