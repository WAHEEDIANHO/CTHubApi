namespace CThub.Application.Hubs;

public interface INotificationHubServer
{
    Task<string> GetConnectionIdByUserId(string userId);

    void SendToGroup(string grpName, string? message);

    Task EmitRideSchedule(string? message);
    Task SendLocation(Location location);
    Task JoinWaiterGroup(string connectionId, string route);
}