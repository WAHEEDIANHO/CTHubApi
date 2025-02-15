using System.ComponentModel.DataAnnotations.Schema;
using CThub.Domain.Abstractions;
using CThub.Domain.Enums;
using CThub.Domain.Events;
using CThub.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Vehincle = CThub.Domain.ValueObjects.Vehincle;

namespace CThub.Domain.Models;

public class User : AppUser
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public UserRole UserRole { get; private set; } = default!;
    // [NotMapped]
    // public ScheduleId ScheduleId { get; private set; } = default!;
    


    public static User CreateUser(
        string firstname, 
        string lastname, 
        string email
    )
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstname);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastname);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
    
        var user = new User()
        {
            Email = email,
            FirstName = firstname,
            LastName = lastname,
            UserRole = UserRole.Rider
        };

        user.AddDomainEvent(new RiderCreatedEvent(user));
        return user;
    }
    
    public static User CreateUser(string firstname,
        string lastname,
        string email,
        Vehincle vehincle)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstname);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastname);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        // ArgumentNullException.ThrowIfNull(driverNo);
        ArgumentNullException.ThrowIfNull(vehincle);
    
       var user = new User()
        {
            Email = email,
            FirstName = firstname,
            LastName = lastname,
            UserRole = UserRole.Driver
        };
        user.AddDomainEvent(new DiverCreatedEvent(user,  vehincle!));
        return user;
    }
    
}