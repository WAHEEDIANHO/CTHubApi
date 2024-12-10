namespace CThub.Domain.ValueObjects;

public record Time
{
    public int Hour { get; } = default!;
    public int Minute { get; } = default!;

    private Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
    }

    public static Time Of(int hour, int minute)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(hour, 24);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(minute, 60);

        return new Time(hour, minute);
    }
}