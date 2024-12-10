using CThub.Domain.Abstractions;
using CThub.Domain.ValueObjects;

namespace CThub.Domain.Models;

public class PrevStop: Entity
{
    public Stop Stop { get; private set; } = default!;
    
    public StopId StopId { get; private set; } = default!;
    public StopId PrevStopId { get; private set; } = default!;
    
    
}