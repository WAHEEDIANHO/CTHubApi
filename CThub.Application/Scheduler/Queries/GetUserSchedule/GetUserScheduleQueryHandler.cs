using CThub.Application.Common.CQRS;
using CThub.Application.Extensions;
using CThub.Application.Scheduler.Repository;

namespace CThub.Application.Scheduler.Queries.GetUserSchedule;

public class GetUserScheduleQueryHandler(IScheduleRepository repository): IQueryHandler<GetUserScheduleQuery, GetUserScheduleQueryResponse>
{
    public async Task<GetUserScheduleQueryResponse> Handle(GetUserScheduleQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var result = repository.GetUserScheduleAsync(request.RiderId);
        return new GetUserScheduleQueryResponse(result.DtoUserSpecSchedule(request.Vehincle));
    }
}