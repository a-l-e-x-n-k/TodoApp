namespace Domain.Entities.Common;

public abstract class Entity
{
    public bool IsTransient()
    {
        return Id == default;
    }

    public int Id { get; protected set; }

    private readonly DomainEvents _domainEvents = new DomainEvents();

    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents!;

    protected void AddDomainEvent(DomainEvent eventItem)
    {
        _domainEvents.AddDomainEvent(eventItem);
    }
    
}