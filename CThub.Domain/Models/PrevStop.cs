using CThub.Domain.Abstractions;
using CThub.Domain.Events;
using CThub.Domain.ValueObjects;

namespace CThub.Domain.Models;

public class PrevStop: Aggregate
{
    // public Stop Stop { get; private set; } = default!;
    
    public StopId StopId { get; private set; } = default!; //Ownner of the relationship
    public StopId PrevStopId { get; private set; } = default!;
    public StopName PrevStopName { get; private set; } = default!;


    public static PrevStop Create(Stop stop, StopId prevStopId, StopName prevStopName)
    {
        ArgumentNullException.ThrowIfNull(stop);
        ArgumentNullException.ThrowIfNull(prevStopId);
        ArgumentNullException.ThrowIfNull(prevStopName);
        
        
        var prevStop = new PrevStop { StopId = stop.Id, PrevStopId = prevStopId, PrevStopName = prevStopName};
        prevStop.AddDomainEvent(new PrevStopAddEvent(prevStopId, stop));
        return prevStop;
    }
    
}