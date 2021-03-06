using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Handlers.TodoItem.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<ActionResult>
    {
        public int ListId { get; set; }

        public string? Title { get; set; }
        public int Order { get; set; }
    }
}
