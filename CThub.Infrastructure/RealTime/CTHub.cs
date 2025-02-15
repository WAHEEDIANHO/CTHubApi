using Microsoft.AspNetCore.SignalR;

namespace CThub.Infrastructure.RealTime;

public class CTHub: Hub
{
    public override async Task OnConnectedAsync()
    {
        Console.WriteLine("connect a user");
        await Clients.All.SendAsync("Connection", $"{Context.ConnectionId} has joined");
    }

    public async Task TestMe(string message)
    {
        await Clients.All.SendAsync($"Hello somebody");
    }
    
    public async Task SendNotification(string content)
    {
        await Clients.All.SendAsync("ReceiveNotification", content);
    }
}