namespace Evently.Modules.Events.Domain.Abstractions;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvens = [];
    
    protected  Entity()
    {}
    
    public IReadOnlyCollection<IDomainEvent> DomainEvens => _domainEvens.ToList();
    
    public void ClearDomainEvens()
    {
        _domainEvens.Clear();
    }

    protected void Raise(IDomainEvent domainEven)
    {
        _domainEvens.Add(domainEven);
    }
}
