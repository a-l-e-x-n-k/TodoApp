namespace Domain.Entities;

public abstract class Entity
{
    public bool IsTransient()
    {
        return Id == default;
    }

    public int Id { get; protected set; }

    private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly()!;

    public void AddDomainEvent(DomainEvent eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(DomainEvent eventItem)
    {
        _domainEvents.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}