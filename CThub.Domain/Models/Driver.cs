using System.ComponentModel.DataAnnotations.Schema;
using CThub.Domain.Abstractions;
using CThub.Domain.Events;
using CThub.Domain.ValueObjects;

namespace CThub.Domain.Models;

public class Driver: Entity
{
    // [NotMapped]
    public User User { get; private set; } = default!;
    public DriverNo DriverNo { get; private set; } = default!;
    public Vehincle Vehincle { get; private set; } = default!;
    public string UserId { get; private set; } = default!;

    public static Driver Create(DriverNo driverNo, Vehincle vehincle, string userId)
    {
        ArgumentNullException.ThrowIfNull(driverNo);
        ArgumentNullException.ThrowIfNull(vehincle);

        var driver = new Driver
        {
            UserId = userId,
            DriverNo = driverNo,
            Vehincle = vehincle,
        };
        
        // driver.AddDomainEvent(new DiverCreatedEvent(driver.Id, firstname, lastname,email));
        return driver;
    }

    public void SetDriverNo(int value)
    {
        DriverNo = DriverNo.Of(value);
    }
}