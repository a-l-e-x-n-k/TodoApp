using Domain.Entities.Common;

namespace Domain.Entities.TodoItem.Events;

public class TodoItemDeletedEvent : DomainEvent
{
    public TodoItemDeletedEvent(TodoItemEntity item)
    {
        Item = item;
    }

    public TodoItemEntity Item { get; }
}