using System.Net;

namespace CThub.Domain.Exceptions;

public class UserException(string msg): Exception(), IException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => msg;
}