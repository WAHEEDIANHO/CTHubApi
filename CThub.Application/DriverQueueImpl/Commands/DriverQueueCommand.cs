using CThub.Application.Common.CQRS;
using CThub.Domain.Enums;

namespace CThub.Application.DriverQueueImpl.Commands;

public record DriverQueueCommandResponse(
    Guid Id,
    int Count
    );

public record DriverQueueCommand(
        string DriverId,
        string Latitude,
        string Longitude,
        Vehincle Vehincle,
        string Token
    ): ICommand<DriverQueueCommandResponse>;