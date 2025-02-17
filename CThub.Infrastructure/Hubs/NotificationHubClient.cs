using System.Collections.Concurrent;
using CThub.Application.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace CThub.Infrastructure.Hubs;

public sealed class NotificationHubClient(INotificationHubServer _hubServer): Hub<INotificationHubClient>
{
    private static List<Location> _driverLocs = new();
    // private static readonly ConcurrentDictionary<string, string> _userConnections = new();

    
    public override async Task OnConnectedAsync()
    {   
        Console.WriteLine("have already pass here", Context.ConnectionId);

        var httpContext = Context.GetHttpContext(); 
        var userId = httpContext.Request.Query["userId"];
        
        // if (!string.IsNullOrEmpty(userId))
        // {
        //     _userConnections[userId] = Context.ConnectionId;  // Map userId to ConnectionId
        // }

        _hubServer.MapUserWithId(userId, Context.ConnectionId);
        await Clients.Caller.ReceiveMessage("This is successful connection brodcast");
        // await Groups.AddToGroupAsync(Context.ConnectionId, "appUser");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        _hubServer.RemoveUserWithConnectionId(Context.ConnectionId);
       // var userId =  _userConnections.FirstOrDefault(x => x.Value == Context.ConnectionId).Key;
       // if(!string.IsNullOrEmpty(userId)) _userConnections.TryRemove(userId, out _);
        
        await base.OnDisconnectedAsync(exception);
    }

    // public async Task RideJoin(string route, string userId)
    // {
    //     await Task.CompletedTask;
    //     // Clients.Group(route);
    // }
    

    // public async Task SendBroadcast(string user, string message)
    // {
    //    await Clients.All.ReceiveMessage("This is something to test");
    // }

    public async Task SendLocation(Location location)
    {
        if (_driverLocs.FirstOrDefault(x => x.UserId == location.UserId) is not Location loc)
        {
            _driverLocs.Add(location);
        }
        else
        {
            loc.Latitude = location.Latitude;
            loc.Longitude = location.Longitude;
        }
        await Clients.Others.DriverLocations(_driverLocs);
    }

    public async Task Queue()
    {
        Console.WriteLine("Add Driver to queue");
    }
    

    public Task DriverLocations(List<Location> _driverLocs)
    {
        throw new NotImplementedException();
    }

    public async Task RideWaiter(string route, string riderId)
    {
        Console.WriteLine(route, riderId);
        // Clients.Groups(route);
        Console.WriteLine($"Joined Group {route}");
    }
    

    public void SendToGroup(string grpName, string? message)
    {
         Clients.Group(grpName).EmitRideSchedule(grpName);
    }
}