using CThub.Application.Pagination;
using CThub.Application.Scheduler.Dtos;
using CThub.Application.Scheduler.Queries.GetSchedules;
using CThub.Application.Scheduler.Queries.GetUserSchedule;
using CThub.Domain.Enums;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CThub.Api.Controllers;

public record GetUserScheduleReponse(
        IEnumerable<ScheduleDto> Result
    );

public record GetUserScheduleRequest(
   string RiderId,
   Vehincle Vehincle
);


public record GetScheduleResponse(PaginationResult<ScheduleDto> Result);

public class ScheduleController(ISender sender): ApiController
{
    [HttpGet]
    public async Task<IActionResult> Create([FromQuery] PaginationRequest? request)
    {
        var query = new GetSchedulesQuery(request);
        var result = await sender.Send(query);

        return Ok(new GetScheduleResponse(result.Result));
    }

    [HttpGet]
    public async Task<IActionResult> GetUserSchedule([FromQuery] GetUserScheduleRequest request)
    {
        var query = request.Adapt<GetUserScheduleQuery>();
        var res = await sender.Send(query);
        return Ok(res.Adapt<GetUserScheduleReponse>());
    }
 
}