using CThub.Domain.Abstractions;
using CThub.Domain.Models;
using CThub.Domain.ValueObjects;

namespace CThub.Domain.Events;

public record DiverCreatedEvent(
    User user,
    Vehincle vehincle): IDomainEvent;