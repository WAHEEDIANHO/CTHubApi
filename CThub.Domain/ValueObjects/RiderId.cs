using CThub.Domain.Exceptions;

namespace CThub.Domain.ValueObjects;

public record RiderId
{
    public Guid Value { get; }

    private RiderId(Guid value) => Value = value;

    public static RiderId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty) throw new DomainException("value can't be enpty");

        return new RiderId(value);
    }
}