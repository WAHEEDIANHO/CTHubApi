using CThub.Domain.Exceptions;

namespace CThub.Domain.ValueObjects;

public record ScheduleId
{
    public Guid Value { get; }
    
    private ScheduleId (Guid value) => Value = value;

    public static ScheduleId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        
        if (value == Guid.Empty) throw new DomainException("value can't be empty");


        return new ScheduleId(value);
    }
}