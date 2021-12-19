// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
namespace Domain.Entities
{
    public class TodoItem 
    {
        public int Id { get; private set; }
        public string? Title { get; private set; }
        public string? Note { get; private set; }
        public int Order { get; private set; }
        public bool IsCompleted { get; private set; }

        public TodoItem(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title is required");
            }
            
            Title = title;
            Order = 0;
        }

        public void SetNote(string? note)
        {
            Note = note;
        }

        public void MarkAsCompleted(bool isCompleted)
        {
            IsCompleted = isCompleted;
        }

        public bool UpdateOrder(TodoList list, int newOrder)
        {
            if (list.CanReorder(this, newOrder))
            {
                Order = newOrder;
                return true;
            }
            return false;
        }
    }
}
