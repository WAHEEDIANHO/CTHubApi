namespace CThub.Domain.ValueObjects;

public record DriverNo
{
    public int Value { get; }

    private DriverNo(int value) => Value = value;

    public static DriverNo Of(int value)
    {
        return new DriverNo(value);
    }
}