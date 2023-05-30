using Microsoft.AspNetCore.SignalR;

namespace WebApiSignalR.Hubs
{
    public class MessageHub:Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        
        public async Task SendMessage(double message)
        {
            await Clients.All.SendAsync("ReceiveMessage",message);
        }
    }
}
