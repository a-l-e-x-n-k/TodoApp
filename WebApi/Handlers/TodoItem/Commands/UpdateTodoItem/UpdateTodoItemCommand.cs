using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Handlers.TodoItem.Commands.UpdateTodoItem
{
    public class UpdateTodoItemCommand : IRequest<ActionResult>
    {
        public int ListId { get; set; }
        public int ItemId { get; set; }
        public string? Title { get; set; }
        public int Order { get; set; }
        public bool IsCompleted { get; set; }
    }
}
