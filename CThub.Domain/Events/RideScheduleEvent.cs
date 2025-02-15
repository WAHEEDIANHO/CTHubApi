using CThub.Domain.Abstractions;
using MediatR;

namespace CThub.Domain.Events;

public record RideScheduleEvent(): IDomainEvent;