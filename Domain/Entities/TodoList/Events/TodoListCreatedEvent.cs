namespace Domain.Entities.TodoList.Events;

public class TodoListCreatedEvent : DomainEvent
{
    public TodoListCreatedEvent(TodoListEntity item)
    {
        Item = item;
    }

    public TodoListEntity Item { get; }

}