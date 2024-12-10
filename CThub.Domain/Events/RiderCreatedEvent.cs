using CThub.Domain.Abstractions;
using CThub.Domain.Models;
using CThub.Domain.ValueObjects;
using MediatR;

namespace CThub.Domain.Events;

public record RiderCreatedEvent(User user): IDomainEvent;