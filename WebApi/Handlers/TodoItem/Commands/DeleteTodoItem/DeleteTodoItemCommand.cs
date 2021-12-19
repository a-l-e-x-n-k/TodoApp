using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Handlers.TodoItem.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommand : IRequest<ActionResult>
    {
        public int ListId { get; set; }
        public int ItemId { get; set; }
    }
}
