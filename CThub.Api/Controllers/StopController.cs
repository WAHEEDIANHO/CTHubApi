using System.Net;
using CThub.Application.Dtos;
using CThub.Application.Pagination;
using CThub.Application.Stop.Commands.CreateStop;
using CThub.Application.Stop.Commands.StopConnection;
using CThub.Application.Stop.Queries.GetStopById;
using CThub.Application.Stop.Queries.GetStops;
using CThub.Application.Stop.Repository;
using CThub.Contract;
using CThub.Contract.Stop;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CThub.Api.Controllers;

public record GetStopByIdResponse(StopDto stop);
public record GetStopResponse(PaginationResult<StopDto> stops);
public class StopController(ISender sender): ApiController
{
    private readonly ILogger<StopController> _logger;
    [HttpGet("id")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var query = new GetStopByIdQuery(id);
        var result = await sender.Send(query);
        return Ok(new GetStopByIdResponse(result.Stop));
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var query = new GetStopQuery(request);
        var result = await sender.Send(query);
        
        return Ok(new GetStopResponse(result.Result));
    }

    [HttpPost]
    public async Task<ActionResult> CreateStop([FromBody] CreateStopRequest command)
    {
        var cmd = new CreateStopCommand(command.Name);
        var result = await sender.Send(cmd);
        return Ok(new CreateStopResponse(result.Id));
    }

    [HttpPost]
    public async Task<ActionResult> AddPreviousStop([FromBody] AddPreviousStopRequest request)
    {
        var cmd = new AddPreviousStopCommand(request.StopId, request.PreviousStopId);
        var result = await sender.Send(cmd);

        return Ok(new Response()
        {
            StatusCode = (int)HttpStatusCode.OK,
            Data = "Added successfully",
        });
    }
    // [HttpPut]
    // public 
}