using System.Net;

namespace CThub.Contract;

public record Response
{
    public Object? Data { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; }
};