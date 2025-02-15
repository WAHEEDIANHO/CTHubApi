using CThub.Application.Common.CQRS;
using CThub.Application.Dtos;
using CThub.Application.Extensions;
using CThub.Application.Pagination;
using CThub.Application.Stop.Repository;

namespace CThub.Application.Stop.Queries.GetStops;

public class GetStopQueryHandler(IStopRepository stopRepository): IQueryHandler<GetStopQuery, GetStopResult>
{
    public async Task<GetStopResult> Handle(GetStopQuery query, CancellationToken cancellationToken)
    {
        var stops = await stopRepository.GetStopsAsync(query.PaginationRequest);
        return new GetStopResult(
            new PaginationResult<StopDto>(
                stops.PageIndex,
                stops.Size,
                stops.TotalCount,
                stops.Items.ToStopDtos()
            )
        );
    }
}