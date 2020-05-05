using System;
using System.Threading;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreSignalR_React.Server
{
    public class MyBackgroundService : IHostedService, IDisposable
    {
        public static IHubContext<ChatHub> HubContext;

        public MyBackgroundService(IHubContext<ChatHub> hubContext)
        {
            HubContext = hubContext;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //TODO: your start logic, some timers, singletons, etc
            Timer t = new Timer( async (o) => {
                await HubContext.Clients.All.SendAsync("sendUpdate", DateTime.Now);
                }, null, 0, 5000
            );
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //TODO: your stop logic
            return Task.CompletedTask;
        }

        public void Dispose()
        {
        }
    }
}