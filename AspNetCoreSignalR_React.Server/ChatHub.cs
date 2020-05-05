using System;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AspNetCoreSignalR_React.Server
{
    public class ChatHub : Hub
    {
        private DateTime started;

        public ChatHub()
        {
            this.started = DateTime.Now;
        }

        public async Task SendToAll(string name, string message)
        {
            await Clients.All.SendAsync("sendToAll", name, message);
            string id = Context.ConnectionId;
            Console.WriteLine("Send by: " + id + " created at: " + started);
        }

        public async Task SendUpdate(DateTime dateTime)
        {
            await Clients.All.SendAsync("sendUpdate", dateTime);
        }

        public override Task OnConnectedAsync()
        {
            string id = Context.ConnectionId;
            System.Console.WriteLine("Connected..." + Context.ConnectionId + "..." +
                Context.UserIdentifier);

            // System.Threading.Timer timer = new System.Threading.Timer(
            //     (o) =>  {
            //         SendUpdate(DateTime.Now).Wait();
            //     },
            //      null, 5, 5000
            // );

            return base.OnConnectedAsync();
        }
    }
}