using System.Net;

namespace CThub.Domain.Exceptions;

public class DomainException(string message)
    : Exception(message), IException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotAcceptable;
    public string ErrorMessage { get; } = message;
}