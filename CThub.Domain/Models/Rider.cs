using CThub.Domain.Abstractions;
using CThub.Domain.Events;
using CThub.Domain.ValueObjects;

namespace CThub.Domain.Models;

public class Rider: Entity
{
    private readonly List<Ride> _rides = new();
    
    public IReadOnlyList<Ride> Rides => _rides.AsReadOnly();
    public User User { get; private set; } = default!;
    public string UserId { get; private set; } = default!;

    public static Rider Create(string userId)
    {
        
        var rider = new Rider
        {
            // Id = RiderId.Of(Guid.NewGuid()),
            UserId = userId
        };
        
        return rider;
    }

}