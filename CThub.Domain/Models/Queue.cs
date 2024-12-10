using CThub.Domain.ValueObjects;
using Microsoft.VisualBasic;

namespace CThub.Domain.Models;

public class DriverQueue
{
    
    public DriverId DriverId { get; set; } = default!;
    public Time Time { get; set; } = default!;
    public StopId StopId { get; set; } = default!;
    // public Location Location { get; set; } = default!;


    public static DriverQueue Create(DriverId driverId, Time time, StopId stopId) 
    {
        ArgumentNullException.ThrowIfNull(driverId);
        ArgumentNullException.ThrowIfNull(time);
        ArgumentNullException.ThrowIfNull(stopId);

        return new DriverQueue
        {
            Time = time,
            StopId = stopId,
            DriverId = driverId
        };
    }
}