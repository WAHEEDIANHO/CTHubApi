using CThub.Application.Common.CQRS;
using CThub.Application.Dtos;
using CThub.Application.Pagination;

namespace CThub.Application.Stop.Queries.GetStops;


public record GetStopResult(PaginationResult<StopDto> Result);

public record GetStopQuery(PaginationRequest PaginationRequest): IQuery<GetStopResult>;