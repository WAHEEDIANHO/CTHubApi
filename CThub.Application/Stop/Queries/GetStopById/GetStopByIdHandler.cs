using CThub.Application.Common.CQRS;
using CThub.Application.Extensions;
using CThub.Application.Stop.Repository;
using CThub.Domain.ValueObjects;

namespace CThub.Application.Stop.Queries.GetStopById;

public class GetStopByIdHandler(IStopRepository stopRepository): IQueryHandler<GetStopByIdQuery, GetStopByIdResult>
{
    public async Task<GetStopByIdResult> Handle(GetStopByIdQuery query, CancellationToken cancellationToken)
    {
        var stopId = StopId.Of(query.StopId);
        var resp = await stopRepository.GetStopByIdAsync(stopId);
        return new GetStopByIdResult(resp.ToStopDto());
        // return new GetStopByIdResult();
    }
}