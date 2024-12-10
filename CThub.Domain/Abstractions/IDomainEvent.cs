using MediatR;

namespace CThub.Domain.Abstractions;

public interface IDomainEvent: INotification
{
    Guid EventId => Guid.NewGuid();
    DateTime OccurrenOn => DateTime.Now;
    string EventType => GetType().AssemblyQualifiedName;
}