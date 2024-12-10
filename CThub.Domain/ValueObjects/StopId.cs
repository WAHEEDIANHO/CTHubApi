using CThub.Domain.Exceptions;

namespace CThub.Domain.ValueObjects;

public record StopId
{
    public Guid Value { get; }

    //private constructor 
    private StopId(Guid value) => Value = value;

    public static StopId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty) throw new DomainException("BustopId can't be empty");

        return new StopId(value);
    }
}