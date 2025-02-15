using CThub.Application.Common.CQRS;
using CThub.Application.Extensions;
using CThub.Application.Pagination;
using CThub.Application.Scheduler.Dtos;
using CThub.Application.Scheduler.Repository;

namespace CThub.Application.Scheduler.Queries.GetSchedules;

public class GetScheduleQueryHandler(IScheduleRepository scheduleRepository): IQueryHandler<GetSchedulesQuery, GetSchedulesResult>
{
    public async Task<GetSchedulesResult> Handle(GetSchedulesQuery request, CancellationToken cancellationToken)
    {
        var rest = await scheduleRepository.GetSchedulesAsync(request.query);

        PaginationResult<ScheduleDto> schDto = new PaginationResult<ScheduleDto>(
            rest.PageIndex,
            rest.Size,
            rest.TotalCount,
            rest.Items.ScheduleToDto()
        );
        return new GetSchedulesResult(schDto);
    }
}