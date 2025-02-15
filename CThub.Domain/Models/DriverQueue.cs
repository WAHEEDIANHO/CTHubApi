using CThub.Domain.Abstractions;
using CThub.Domain.ValueObjects;
using Microsoft.VisualBasic;
using Vehincle = CThub.Domain.Enums.Vehincle;

namespace CThub.Domain.Models;

public class DriverQueue: Entity<Guid>
{
    public Driver Driver { get; private set; } = default!;
    public string DriverId { get; set; } = default!;
    public string Token { get; set; } = default!;
    public DateTime QueueTime { get; set; } = default!;
    public Location Location { get; private set; } = default!;
    
    public Vehincle Vehincle { get; private set; }

    public static DriverQueue Create(string driverId, DateTime time, Location location, Vehincle vehicle, string token) 
    {
        ArgumentNullException.ThrowIfNull(driverId);
        ArgumentNullException.ThrowIfNull(time);
        ArgumentNullException.ThrowIfNull(vehicle);
        
        //Check if location match available location for booking

        return new DriverQueue
        {
            QueueTime = time,
            DriverId = driverId,
            Location = location,
            Vehincle = vehicle,
            Token = token
        };
    }
}