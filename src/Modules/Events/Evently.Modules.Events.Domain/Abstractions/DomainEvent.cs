namespace Evently.Modules.Events.Domain.Abstractions;

public abstract class DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
        Id = Guid.NewGuid();
        OcurredOnUtc = DateTime.UtcNow;
    }
    
    protected DomainEvent(Guid eventId, DateTime occurredOnUtc)
    {
        Id = eventId;
        OcurredOnUtc = occurredOnUtc;
    }
    
    public Guid Id { get; init;  }
    public DateTime OcurredOnUtc { get; init; }
}
