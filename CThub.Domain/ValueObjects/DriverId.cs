using CThub.Domain.Exceptions;

namespace CThub.Domain.ValueObjects;

public record DriverId
{
    public Guid Value { get; }

    private DriverId(Guid value) => Value = value;

    public static DriverId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty) throw new DomainException("value can't be empty");

        return new DriverId(value);
    }
}