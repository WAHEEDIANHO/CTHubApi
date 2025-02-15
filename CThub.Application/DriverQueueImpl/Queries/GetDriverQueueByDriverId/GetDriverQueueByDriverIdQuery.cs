using CThub.Application.Common.CQRS;
using CThub.Application.DriverQueueImpl.Dtos;

namespace CThub.Application.DriverQueueImpl.Queries.GetQueueByDriverId;

public record DriverQueueByDriverIdQueryResponse(
    DriverQueueDto Result,
    int Idx
    );

public record GetDriverQueueByDriverIdQuery(
        string DriverId
    ): IQuery<DriverQueueByDriverIdQueryResponse>;