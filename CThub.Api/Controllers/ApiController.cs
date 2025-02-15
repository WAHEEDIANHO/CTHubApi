using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace CThub.Api.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public abstract class ApiController: ControllerBase
{
    
}