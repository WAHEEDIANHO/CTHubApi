using CThub.Domain.Abstractions;
using CThub.Domain.ValueObjects;

namespace CThub.Domain.Models;

public class Stop: Aggregate<StopId>
{
    private readonly List<PrevStop> _prevStops = new();
    private readonly List<NextStop> _nextStops = new();
    
    public StopName StopName { get; private set;  }
    public IReadOnlyList<PrevStop> PrevStops => _prevStops.AsReadOnly();
    public IReadOnlyList<NextStop> NextStops => _nextStops.AsReadOnly();

    private Stop(StopId id, StopName stopName)
    {
        Id = id;
        StopName = stopName;
    }

    public static Stop Create(StopId id, StopName stopName)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(stopName);

        var stop = new Stop(id, stopName);
        return stop;
    }

    // public void AddNextStop(NextStop nextStop)
    // {
    //     _nextStops.Add(nextStop);
    //     nextStop.AddPrevStop(this);
    // }

    // public void RemoveStop(StopId stopId)
    // {
    //     var stop = _nextStops.FirstOrDefault(x => x.Id.Value == stopId.Value);
    //     if (stop is not null)
    //     {
    //         _nextStops.Remove(stop);
    //         // stop._prevStops.Remove(this);
    //     }
    // }

    // private void AddPrevStop(Stop prevStop)
    // {
    //     _prevStops.Add(prevStop);
    // }
}