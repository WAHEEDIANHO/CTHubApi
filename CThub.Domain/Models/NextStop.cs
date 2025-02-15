using CThub.Domain.Abstractions;
using CThub.Domain.ValueObjects;

namespace CThub.Domain.Models;

public class NextStop: Entity
{
    // public Stop Stop { get; private set; } = default!;
    
    public StopId StopId { get; private set; } = default!;
    public StopId NextStopId { get; private set; } = default!;
    public StopName NextStopName { get; private set; } = default!;

    public static NextStop Create(StopId stopId, StopId nextStopId, StopName nextStopName)
    {
        ArgumentNullException.ThrowIfNull(stopId);
        ArgumentNullException.ThrowIfNull(nextStopId);
        ArgumentNullException.ThrowIfNull(nextStopName);
        

        return new NextStop()
        {
            StopId = stopId,
            NextStopId = nextStopId,
            NextStopName = nextStopName
            
        };
    }
}