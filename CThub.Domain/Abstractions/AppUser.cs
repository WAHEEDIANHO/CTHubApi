 using Microsoft.AspNetCore.Identity;

 namespace CThub.Domain.Abstractions;

public class AppUser: IdentityUser, IAggregate
{
 private readonly List<IDomainEvent> _domainEvents = new();
 public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
 
 
 public DateTime? CreatedAt { get; set; }
 public DateTime? ModifieldAt { get; set; }

 public void AddDomainEvent(IDomainEvent domainEvent)
 {
     _domainEvents.Add(domainEvent);
 }
 
 public IDomainEvent[] ClearDomainEvents()
 {
     var dequeEvent = _domainEvents.ToArray();
     _domainEvents.Clear();
     return dequeEvent;
 }
}