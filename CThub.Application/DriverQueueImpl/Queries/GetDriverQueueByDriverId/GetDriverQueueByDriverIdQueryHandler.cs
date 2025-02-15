using CThub.Application.Common.CQRS;
using CThub.Application.DriverQueueImpl.Repository;
using CThub.Application.Extensions;

namespace CThub.Application.DriverQueueImpl.Queries.GetQueueByDriverId;

public class GetDriverQueueByDriverIdQueryHandler(IDriverQueueRepository repository): IQueryHandler<GetDriverQueueByDriverIdQuery, DriverQueueByDriverIdQueryResponse>
{
    public async Task<DriverQueueByDriverIdQueryResponse> Handle(GetDriverQueueByDriverIdQuery request, CancellationToken cancellationToken)
    {
        var d = await repository.GetByDriverId(request.DriverId);
        if (await repository.GetByDriverId(request.DriverId) is not DriverQueue driverQueue) return null;
        var idx  = repository.GetAll(null).GetAwaiter().GetResult().ToList().IndexOf(driverQueue) + 1;
        return new DriverQueueByDriverIdQueryResponse(driverQueue.ToDriverQueueDtos(), idx);
    }
}