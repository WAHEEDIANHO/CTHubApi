using CThub.Application.Common.CQRS;
using CThub.Application.Dtos;
using CThub.Application.Pagination;
using CThub.Application.Scheduler.Dtos;

namespace CThub.Application.Scheduler.Queries.GetSchedules;



public record GetSchedulesQuery(
        PaginationRequest query
    ): IQuery<GetSchedulesResult>;
public record GetSchedulesResult(
        PaginationResult<ScheduleDto> Result       
    );