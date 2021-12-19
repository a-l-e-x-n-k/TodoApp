using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Handlers.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommand : IRequest<ActionResult>
    {
        public int ListId { get; set; }
        public int ItemId { get; set; }
    }
}
