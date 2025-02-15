using CThub.Application.Ride.Commands;
using CThub.Contract.Booking;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CThub.Api.Controllers;

public class RideController(ISender sender): ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookingRequest bookingRequest)
    {
        var cmd = bookingRequest.Adapt<CreateRideCommand>();
        var resp = await sender.Send(cmd);
        return Ok(resp.Adapt<BookingResponse>());
    }
}