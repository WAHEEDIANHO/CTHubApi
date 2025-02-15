namespace CThub.Application.Hubs;

public record Location
{
    public string UserId { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
};

public interface INotificationHubClient
{
    // Task SendLocation(Location location);
    // Task Queue();
    // Task SendBroadcast(string user, string message);
    Task ReceiveMessage(string message);
    Task DriverLocations(List<Location> _driverLocs);
    Task RideWaiter(string route, string riderId);
    Task RideJoin(string route, string riderId);
    // Task JoinWaiterGroup(string connectionId, string grpName);
    Task EmitRideSchedule(string? message);
}