namespace CThub.Domain.ValueObjects;

public record RideId
{
    public Guid Value { get; private set; }

    private RideId (Guid value) => Value = value;

    public static RideId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        return new RideId(value);
    }
}