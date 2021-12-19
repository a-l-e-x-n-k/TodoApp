namespace Domain.Entities.TodoItem.Events;

public class TodoItemCreatedEvent : DomainEvent
{
    public TodoItemCreatedEvent(TodoItemEntity item)
    {
        Item = item;
    }

    public TodoItemEntity Item { get; }

}