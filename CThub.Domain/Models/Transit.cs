using CThub.Domain.Abstractions;
using CThub.Domain.ValueObjects;

namespace CThub.Domain.Models;

public class Transit: Entity
{

    private readonly List<Driver> _driversOnQueue = new();
    public IReadOnlyList<Driver> DriversOnQueue => _driversOnQueue.AsReadOnly();
    
    public string Name { get; private set; }
    public Location Location { get; private set; }


    public Transit Create(string name, Location location)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(location);

        return new Transit()
        {
            Name = name,
            Location = location
        };
    }


    public void EnqueDriver(Driver driver)
    {
        _driversOnQueue.Add(driver);
    }

    public Driver? DequeDriver(string driverId)
    {
        if (_driversOnQueue.FirstOrDefault(d => d.UserId == driverId) is not Driver driver)
        {
            return null;
        }

        _driversOnQueue.Remove(driver);
        return driver;
    }
    
    
}