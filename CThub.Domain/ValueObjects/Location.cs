namespace CThub.Domain.ValueObjects;

public record Location
{
    public string Latitude { get; } = default!;
    public string Longitude { get; } = default!;
}