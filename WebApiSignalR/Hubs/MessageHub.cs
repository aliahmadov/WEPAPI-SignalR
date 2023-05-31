using Microsoft.AspNetCore.SignalR;

namespace WebApiSignalR.Hubs
{
    public class MessageHub:Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        
        public async Task SendMessage(string message)
        {
            await Clients.Others.SendAsync("ReceiveMessage",message+"'s Offer : ",FileHelper.Read());
        }

        public async Task SendWinnerMessage(string message)
        {
            await Clients.Others.SendAsync("ReceiveInfo", message, FileHelper.Read());
        }

    }
}
