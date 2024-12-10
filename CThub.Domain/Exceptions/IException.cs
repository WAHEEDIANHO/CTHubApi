using System.Net;

namespace CThub.Domain.Exceptions;

public interface IException 
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}