using CThub.Application.Common.CQRS;
using CThub.Application.DriverQueueImpl.Repository;
using CThub.Application.Extensions;

namespace CThub.Application.DriverQueueImpl.Queries;

public class DriverQueueQueryHandler(IDriverQueueRepository repository): IQueryHandler<DriverQueueQuery, DriverQueueQueryResponse>
{
    public async Task<DriverQueueQueryResponse> Handle(DriverQueueQuery request, CancellationToken cancellationToken)
    {
        var query = new Dictionary<string, object>();
        if(request.DriverId != null) query.Add("DriverId", request.DriverId);
        if(request.Vehincle != null) query.Add("Vehincle", request.Vehincle);
        var resp = await repository.GetAll(query);
        return new DriverQueueQueryResponse(resp.ToDriverQueueDtos());
    }
}