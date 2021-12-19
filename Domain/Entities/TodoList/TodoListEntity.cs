using Domain.Entities.TodoItem;
using Domain.Entities.TodoItem.Events;
using Domain.Entities.TodoList.Events;

namespace Domain.Entities.TodoList
{
    public class TodoListEntity : Entity
    {
        public string? Title { get; set; }
        
        private readonly List<TodoItemEntity> _items = new List<TodoItemEntity>();
        public IReadOnlyCollection<TodoItemEntity> Items => _items.AsReadOnly();

        public static TodoListEntity NewDraft(string title)
        {
            var newList =  new TodoListEntity(title);
            newList.AddDomainEvent(new TodoListCreatedEvent(newList));
            return newList;
        }

        private TodoListEntity(string title)
        {
            UpdateTitle(title);
        }

        public TodoItemEntity AddItem(string title)
        {
            var item  = TodoItemEntity.NewDraft(title);
            item.AddDomainEvent(new TodoItemCreatedEvent(item));
            _items.Add(item);
            return item;
        }
        
        public void RemoveItem(int id)
        {
            var item = _items.FirstOrDefault(entity => entity.Id == id);
            if (item == null)
            {
                return;
            }
            _items.Remove(item);
            item.AddDomainEvent(new TodoItemDeletedEvent(item));
        }
        
        public void UpdateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title is required");
            }

            Title = title;
        }
        
    }
}
