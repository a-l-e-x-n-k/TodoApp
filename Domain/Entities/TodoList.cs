namespace Domain.Entities
{
    public class TodoList
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        
        private readonly List<TodoItem> _items = new List<TodoItem>();
        public IReadOnlyCollection<TodoItem> Items => _items.AsReadOnly();

        public void AddItem()
        {

        }

        public bool CanReorder(TodoItem item, int newOrder)
        {
            if (Items.Any(todoItem => todoItem == item))
            {

            }
        }
    }
}
