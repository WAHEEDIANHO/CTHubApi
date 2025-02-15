using CThub.Application.Common.CQRS;
using CThub.Application.Dtos;

namespace CThub.Application.Stop.Queries.GetStopById;

public record GetStopByIdQuery(
    Guid StopId
    ): IQuery<GetStopByIdResult>;


public record GetStopByIdResult(StopDto Stop);