namespace CThub.Domain.ValueObjects;

public record Location
{
    public string Latitude { get; } = default!;
    public string Longitude { get; } = default!;

    private Location(string latitude, string longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Location Of(string latitude, string longitude)
    {
        return new Location(latitude, longitude);
    }
}