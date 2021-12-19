namespace WebApi.Dto
{
    public class TodoListDto
    {
        public TodoListDto()
        {
            Items = new List<TodoItemDto>();
        }

        public int Id { get; set; }

        public string? Title { get; set; }

        public List<TodoItemDto> Items { get; set; }
    }
}
