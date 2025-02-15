using CThub.Domain.Abstractions;
using CThub.Domain.Events;
using CThub.Domain.ValueObjects;

namespace CThub.Domain.Models;

public class Schedule: Aggregate<ScheduleId>
{
    private readonly List<User> _user = new();

    public IReadOnlyList<User> User => _user.AsReadOnly();
    
    public string Path { get; private set; }
    // public Enums.Ride RideType { get; private set; }
 
    // public string UserId { get; private set; }
    
    // private Sche? () {}

    public static Schedule Create(string path)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(path);

        return new Schedule()
        {
            Id = ScheduleId.Of(Guid.NewGuid()),
            Path = path
        };
    }

    public void AddUser(User user)
    {
        _user.Add(user);
        AddDomainEvent(new RideScheduleEvent());
    }

    public void AdjustPath(string path)
    {
        Path = path;
    }
 }