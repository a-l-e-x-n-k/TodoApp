// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

using Domain.Entities.TodoItem.Events;

namespace Domain.Entities.TodoItem
{
    public class TodoItemEntity : Entity
    {
        public string? Title { get; private set; }
        public string? Note { get; private set; }
        public int Order { get; private set; }
        public bool IsCompleted { get; private set; }

        private TodoItemEntity(string title)
        {
            UpdateTitle(title);
        }

        public static TodoItemEntity NewDraft(string title)
        {
            return new TodoItemEntity(title);
        }

        public void UpdateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title is required");
            }

            Title = title;
        }

        public void SetNote(string? note)
        {
            Note = note;
        }

        public void MarkAsCompleted(bool isCompleted)
        {
            if (isCompleted != IsCompleted)
            {
                IsCompleted = isCompleted;
                AddDomainEvent(new TodoItemStateChangedEvent(this));
            }
        }

        public void UpdateOrder(int order)
        {
            if (order < 0)
            {
                throw new ArgumentException($"Incorrect value for order {order}");
            }

            Order = order;
        }
    }
}
