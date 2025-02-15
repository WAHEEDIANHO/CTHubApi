using CThub.Application.Common.CQRS;
using CThub.Application.Scheduler.Dtos;
using CThub.Domain.Enums;

namespace CThub.Application.Scheduler.Queries.GetUserSchedule;

public record GetUserScheduleQueryResponse(IEnumerable<ScheduleDto> Result);

public record GetUserScheduleQuery(
        string RiderId,
        Vehincle Vehincle
    ): IQuery<GetUserScheduleQueryResponse>;