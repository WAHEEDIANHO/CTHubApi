using CThub.Application.Authentication;
using CThub.Application.Authentication.Commands.Driver;
using CThub.Application.Authentication.Commands.Rider;
using CThub.Application.Authentication.Queries;
using CThub.Contract.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AuthResponse = CThub.Contract.Authentication.AuthResponse;

namespace CThub.Api.Controllers;


[Route("auth")]
public class AuthenticationController(ISender sender): ApiController
{
    [HttpPost("register/rider")]
    public async Task<IActionResult> RegisterRider(RegisterRequest command)
    {
        var cmd = new RiderRegisterCommand(
            command.Email, 
            command.Password, 
            command.FirstName, 
            command.LastName
            );
        var resp = await sender.Send(cmd);
        return Ok(resp);
    }
    
    [HttpPost("register/driver")]
    public async Task<IActionResult> RegisterDriver(DriverRegisterRequest command)
    {
        var cmd = new DriverRegisterCommand(
            command.Email, 
            command.Password, 
            command.FirstName, 
            command.LastName,
            command.VehincleName,
            command.VehincleType,
            command.VehincleModel,
            command.VehincleCapacity
        );
        var resp = await sender.Send(cmd);
        return Ok(resp);
    }
    
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        // var resp = _authenticationService.Login(request.Email, request.Password);
        var cmd = new LoginQuery(request.Email, request.Password);
        var resp = await sender.Send(cmd);
        return Ok(resp);
    }
    
}