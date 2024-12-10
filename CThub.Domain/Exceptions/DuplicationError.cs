using System.Net;

namespace CThub.Domain.Exceptions;

public class DuplicationError(string message):
    Exception(), IException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => message;
}