using System.Collections.Concurrent;
using CThub.Application.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace CThub.Infrastructure.Hubs;

public class NotificationHubServer(IHubContext<NotificationHubClient, INotificationHubClient> _hubContext): INotificationHubServer
{
    private static List<Location> _driverLocs = new();
    private static readonly ConcurrentDictionary<string, string> _userConnections = new();

    public void MapUserWithId(string userId, string connectionId)
    {
        if (!string.IsNullOrEmpty(userId))
        {
            _userConnections[userId] = connectionId;  // Map userId to ConnectionId
        }
    }

    public void RemoveUserWithConnectionId(string connectionId)
    {
        if (!string.IsNullOrEmpty(connectionId))
        {
            var userId =  _userConnections.FirstOrDefault(x => x.Value == connectionId).Key;
            if(!string.IsNullOrEmpty(userId)) _userConnections.TryRemove(userId, out _);
        }
    }

    public async Task<string> GetConnectionIdByUserId(string userId)
    {
        await Task.CompletedTask;
        return _userConnections.TryGetValue(userId, out var connectionId) ? connectionId : "Not Found";
    }

    public void SendToGroup(string grpName, string? message)
    {
        _hubContext.Clients.Group(grpName).EmitRideSchedule(message);
    }

    public Task EmitRideSchedule(string? message)
    {
        throw new NotImplementedException();
    }

    public Task JoinWaiterGroup(string connectionId, string grpName)
    {
        Console.WriteLine(grpName);
        Console.WriteLine(connectionId);
        Console.WriteLine("a" + "b");
        Console.WriteLine(grpName + connectionId);
        // SendToGroup("test", "hello");
        // return Task.CompletedTask;
        if (!string.IsNullOrEmpty(connectionId) && !string.IsNullOrEmpty(grpName))
        {
            return _hubContext.Groups.AddToGroupAsync("connectionId", "grpName");
        }
        else
        {
            throw new ArgumentNullException("connectionId or grpName is null or empty");
        }
    }
}