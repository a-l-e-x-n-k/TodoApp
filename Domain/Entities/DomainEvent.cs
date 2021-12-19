namespace Domain.Entities
{
    public abstract class DomainEvent
    {
        protected DomainEvent()
        {
            DateOccurred = DateTimeOffset.UtcNow;
        }
        public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
