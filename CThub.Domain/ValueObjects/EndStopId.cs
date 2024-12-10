using CThub.Domain.Exceptions;

namespace CThub.Domain.ValueObjects;

public record EndStopId
{
    public Guid Value { get; }

    private EndStopId(Guid value) => Value = value;

    public static EndStopId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty) throw new DomainException("value can't be empty");

        return new EndStopId(value);
    }
}