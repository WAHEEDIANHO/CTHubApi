using System.Net;

namespace CThub.Domain.Exceptions;

public class NotFoundException(string message): Exception(), IException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string ErrorMessage => message;
}