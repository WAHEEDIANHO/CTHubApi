using System.Reflection.PortableExecutable;
using CThub.Domain.Abstractions;
using CThub.Domain.Events;
using CThub.Domain.ValueObjects;

namespace CThub.Domain.Models;

public class Ride: Aggregate<RideId>
{
    // public Stop Start { get; private set; } = default!;
    // public Stop End { get; private set; } = default!;

    public StartStopId StartStopId { get; private set; } = default!;
    public EndStopId EndStopId { get; private set; } = default!;
    public RiderId RiderId { get; private set; } = default!;

    internal Ride(StartStopId startStopId, EndStopId endStopId, RiderId riderId)
    {
        Id = RideId.Of(Guid.NewGuid());
        StartStopId = startStopId;
        EndStopId = endStopId;
        RiderId = riderId;
    }


    // public static Ride Create(StartStopId startStopId, EndStopId endStopId, RiderId riderId)
    // {
    //     ArgumentNullException.ThrowIfNull(startStopId);
    //     ArgumentNullException.ThrowIfNull(endStopId);
    //     ArgumentNullException.ThrowIfNull(riderId);
    //
    //     var ride = new Ride()
    //     {
    //         RiderId = riderId,
    //         StartStopId = startStopId,
    //         EndStopId = endStopId
    //     };
    //     
    //     ride.AddDomainEvent(new RideCreatedEvent(ride));
    //     return ride;
    // }
}