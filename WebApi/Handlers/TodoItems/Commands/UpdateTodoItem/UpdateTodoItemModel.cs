namespace WebApi.Handlers.TodoItems.Commands.UpdateTodoItem
{
    public class UpdateTodoItemModel
    {
        public string? Title { get; set; }
        public int Order { get; set; }
        public bool IsCompleted { get; set; }
    }
}
