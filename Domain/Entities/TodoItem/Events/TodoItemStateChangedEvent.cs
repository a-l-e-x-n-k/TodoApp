namespace Domain.Entities.TodoItem.Events
{
    public class TodoItemStateChangedEvent : DomainEvent
    {
        public TodoItemStateChangedEvent(TodoItemEntity item)
        {
            Item = item;
        }

        public TodoItemEntity Item { get; }
    }
}
