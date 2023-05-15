using Microsoft.AspNetCore.SignalR;

namespace SignalRExample.Hubs
{
    public class MyHub:Hub
    {
        public static List<string> Names { get; set; } = new List<string>();
        public static int CleintCount { get; set; } =0;
        public async Task SendName(string name)
        {
           await Clients.All.SendAsync("ReceiveName", name);
        }

        public async Task GetNames()
        {
            await Clients.All.SendAsync("ReceiveName", Names);
        }

        public override async Task OnConnectedAsync()
        {
            CleintCount++;
            await Clients.All.SendAsync("ReceiveClientCount", CleintCount);
            await base.OnConnectedAsync();
        }
        public async override Task OnDisconnectedAsync(Exception? exception)
        {
            CleintCount--;
            await Clients.All.SendAsync("ReceiveClientCount", CleintCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
