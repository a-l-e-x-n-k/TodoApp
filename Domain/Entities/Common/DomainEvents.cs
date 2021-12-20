using System.Collections;

namespace Domain.Entities.Common
{
    public class DomainEvents : IReadOnlyCollection<DomainEvent>
    {
        private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();
        
        public void AddDomainEvent(DomainEvent eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public IEnumerator<DomainEvent> GetEnumerator()
        {
            return _domainEvents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _domainEvents.Count;
    }
}
