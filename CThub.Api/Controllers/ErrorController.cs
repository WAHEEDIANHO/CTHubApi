using CThub.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CThub.Api.Controllers;
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController: ControllerBase
{
    [Route("/error")]
    public IActionResult ErrorHandler()
    {
        Exception? ex = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        
        var (statusCode, message) = ex switch
        {
            IException badRequest => ((int)badRequest.StatusCode, badRequest.ErrorMessage),
            _ => (500, "Internal Server Error")
        };
        
        return Problem(statusCode: statusCode, title: ex.Message, detail: message);
    }
    
}