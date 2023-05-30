using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApiSignalR.Hubs;

namespace WebApiSignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private IHubContext<MessageHub> messageHub;

        public OfferController(IHubContext<MessageHub> messageHub)
        {
            this.messageHub = messageHub;
            if (!System.IO.File.Exists("data.txt"))
            {
                FileHelper.Write(1000);
            }
        }

        [HttpGet]
        public double Get()
        {
            //messageHub.Clients.All.SendOffersToUser(data);
            return FileHelper.Read();
        }

        [HttpGet("/Increase")]
        public async void Get(double number)
        {
            var data = FileHelper.Read() + number;
            FileHelper.Write(data);
        }
    }
}
