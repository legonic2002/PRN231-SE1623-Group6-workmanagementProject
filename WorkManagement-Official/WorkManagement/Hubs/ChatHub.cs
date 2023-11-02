using Microsoft.AspNetCore.SignalR;

namespace WorkManagement.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            //only call await Clients.All.SendAsync("ReceiveMessage", user, message); 1 time
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
