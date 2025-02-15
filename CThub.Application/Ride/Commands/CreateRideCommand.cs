using CThub.Application.Common.CQRS;
using CThub.Domain.ValueObjects;
using Vehincle = CThub.Domain.Enums.Vehincle;

namespace CThub.Application.Ride.Commands;

public record CreateRideResult(Guid Id);

public record CreateRideCommand(
        Guid RiderId,
        Guid StartStopId,
        Guid EndStopId,
        Vehincle VehincleType,
        Domain.Enums.Ride RideType
    ): ICommand<CreateRideResult>;