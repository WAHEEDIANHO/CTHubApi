using System.Collections.Concurrent;
using CThub.Application.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace CThub.Infrastructure.Hubs;

public sealed class NotificationHubClient: Hub<INotificationHubClient>, INotificationHubServer
{
    private static List<Location> _driverLocs = new();
    private static readonly ConcurrentDictionary<string, string> _userConnections = new();

    
    public override async Task OnConnectedAsync()
    {   
        Console.WriteLine("have already pass here", Context.ConnectionId);

        var httpContext = Context.GetHttpContext(); 
        var userId = httpContext.Request.Query["userId"];
        
        if (!string.IsNullOrEmpty(userId))
        {
            _userConnections[userId] = Context.ConnectionId;  // Map userId to ConnectionId
        }

        await Clients.Caller.ReceiveMessage("This is successful connection brodcast");
        await base.OnConnectedAsync();
        
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
       var userId =  _userConnections.FirstOrDefault(x => x.Value == Context.ConnectionId).Key;
       
       if(!string.IsNullOrEmpty(userId)) _userConnections.TryRemove(userId, out _);
        
        await base.OnDisconnectedAsync(exception);
    }

    // public async Task RideJoin(string route, string userId)
    // {
    //     await Task.CompletedTask;
    //     // Clients.Group(route);
    // }

    public Task EmitRideSchedule(string? message)
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetConnectionIdByUserId(string userId)
    {
        await Task.CompletedTask;
        return _userConnections.TryGetValue(userId, out var connectionId) ? connectionId : "Not Found";
    }

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

    public Task JoinWaiterGroup(string connectionId, string grpName)
    {
        return Groups.AddToGroupAsync(connectionId, grpName);
    }

    public void SendToGroup(string grpName, string? message)
    {
         Clients.Group(grpName).EmitRideSchedule(grpName);
    }
}