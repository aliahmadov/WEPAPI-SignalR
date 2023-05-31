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
         

        public async Task JoinRoom(string room,string user)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
            await Clients.OthersInGroup(room).SendAsync("ReceiveJoinInfo", user);
        }


        public async Task SendMessageRoom(string room,string message)
        {
            await Clients.OthersInGroup(room).SendAsync("ReceiveMessageRoom", message + "'s Offer : ", FileHelper.Read(room));
        }

        public async Task SendWinnerMessageRoom(string room,string message)
        {
            await Clients.OthersInGroup(room).SendAsync("ReceiveInfoRoom", message, FileHelper.Read(room));
        }
    }
}
