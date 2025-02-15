namespace CThub.Domain.ValueObjects;

public record RoleName
{
    public string Value { get; }

    private RoleName(string value) => Value = value;

    public static RoleName Of(string value)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(value);

        return new RoleName(value);
    }
};