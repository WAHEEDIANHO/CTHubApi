using CThub.Application.DriverQueueImpl.Commands;
using CThub.Application.DriverQueueImpl.Dtos;
using CThub.Application.DriverQueueImpl.Queries;
using CThub.Application.DriverQueueImpl.Queries.GetQueueByDriverId;
using CThub.Contract.DriverQueue;
using CThub.Domain.Enums;
using CThub.Domain.Models;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CThub.Api.Controllers;

// public record DriverQueueRequest(
//         string DriverId,
//         string Latitude,
//         string Longitude,
//         Vehincle Vehincle
//     );

public record GetQueueRequest(
        string? DriverId,
        Vehincle? Vehincle
    );

public record GetQueueResult(
    IEnumerable<DriverQueueDto> result
);

public record GetQueueByIdResult(DriverQueueDto result, int Idx);
public class DriverQueueController(ISender sender): ApiController
{
    [HttpPost]
    public async Task<IActionResult> Enqueue([FromBody] DriverQueueRequest request)
    {
        var cmd = request.Adapt<DriverQueueCommand>();
        var resp =await sender.Send(cmd);

        return Ok(resp);
    }

    [HttpGet]
    public async Task<IActionResult> GetQueue([FromQuery] GetQueueRequest? request)
    {
        var query = new DriverQueueQuery(request.DriverId, request.Vehincle);
        var resp = await sender.Send(query);
    
        return Ok(new GetQueueResult(resp.Result));
    }
    
    [HttpGet("{driverId}")]
    public async Task<IActionResult> GetQueueByDriverId([FromRoute] string driverId)
    {
        var query = new GetDriverQueueByDriverIdQuery(driverId);
        var resp = await sender.Send(query);

        if (await sender.Send(query) is not DriverQueueByDriverIdQueryResponse) return Ok(new GetQueueByIdResult(null, 0));
        return Ok(new GetQueueByIdResult(resp.Result, resp.Idx));
    }
}