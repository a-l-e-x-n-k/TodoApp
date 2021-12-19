using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Handlers.TodoList.Commands.DeleteTodoList
{
    public class DeleteTodoListCommand : IRequest<ActionResult>
    {
        public int Id { get; set; }
    }
}
