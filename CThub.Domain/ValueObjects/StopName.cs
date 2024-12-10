namespace CThub.Domain.ValueObjects;

public record StopName
{
    public string Value { get; }

    private StopName (string value) => Value = value;

    public static StopName Of(string value)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
        return new StopName(value);
    }
};