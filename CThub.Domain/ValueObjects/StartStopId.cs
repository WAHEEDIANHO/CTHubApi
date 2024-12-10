using CThub.Domain.Exceptions;

namespace CThub.Domain.ValueObjects;

public record StartStopId
{
    public Guid Value { get; }

    private StartStopId(Guid value) => Value = value;

    public static StartStopId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty) throw new DomainException("value can't be empty");

        return new StartStopId(value);
    }
}