using CThub.Domain.Abstractions;
using CThub.Domain.Enums;

namespace CThub.Domain.Events;

public record GetDriverEvent(
        string route,
        List<string> users,
        Ride? rideType = Ride.SHARE
    ): IDomainEvent;