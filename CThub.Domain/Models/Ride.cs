using System.Reflection.PortableExecutable;
using CThub.Domain.Abstractions;
using CThub.Domain.Events;
using CThub.Domain.ValueObjects;
using Vehincle = CThub.Domain.Enums.Vehincle;

namespace CThub.Domain.Models;

public class Ride: Aggregate<RideId>
{
    // public Stop Start { get; private set; } = default!;
    // public Stop End { get; private set; } = default!;

    public StopId StartStopId { get; private set; } = default!;
    public StopId EndStopId { get; private set; } = default!;
    public string RiderId { get; set; } = default!;
    public Enums.Ride RideType { get; private set; }
    public Vehincle VehincleType { get; private set; }

    // internal Ride(StopId startStopId, StopId endStopId, Guid riderId)
    // {
    //     Id = RideId.Of(Guid.NewGuid());
    //     StartStopId = startStopId;
    //     EndStopId = endStopId;
    //     RiderId = riderId;
    //     
    // }
    
    


    public static Ride Create(StopId startStopId, StopId endStopId, string riderId, Vehincle vehincleType, Enums.Ride rideType)
    {
        ArgumentNullException.ThrowIfNull(startStopId);
        ArgumentNullException.ThrowIfNull(endStopId);
        ArgumentNullException.ThrowIfNull(riderId);
    
        var ride = new Ride()
        {
            Id = RideId.Of(Guid.NewGuid()),
            RiderId = riderId,
            StartStopId = startStopId,
            EndStopId = endStopId,
            RideType = rideType,
            VehincleType = vehincleType,
        };
        
        ride.AddDomainEvent(new RideCreatedEvent(ride));
        return ride;
    }
}