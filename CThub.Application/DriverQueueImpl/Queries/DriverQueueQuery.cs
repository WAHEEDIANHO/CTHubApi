using CThub.Application.Common.CQRS;
using CThub.Application.DriverQueueImpl.Dtos;
using CThub.Domain.Enums;

namespace CThub.Application.DriverQueueImpl.Queries;

public record DriverQueueQueryResponse(IEnumerable<DriverQueueDto> Result);

public record DriverQueueQuery(
        string? DriverId,
        Vehincle? Vehincle
    ): IQuery<DriverQueueQueryResponse>;