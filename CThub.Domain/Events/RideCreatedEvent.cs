using CThub.Domain.Abstractions;
using CThub.Domain.Models;

namespace CThub.Domain.Events;

public record RideCreatedEvent(Ride ride): IDomainEvent;