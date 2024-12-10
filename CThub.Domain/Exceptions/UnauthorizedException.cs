using System.Net;
using Microsoft.VisualBasic;

namespace CThub.Domain.Exceptions;

public class UnauthorizedException(string message): Exception, IException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
    public string ErrorMessage => message;
}