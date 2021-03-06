using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Handlers.TodoList.Commands.UpdateTodoList
{
    public class UpdateTodoListCommand : IRequest<ActionResult>
    {
        public int Id { get; set; }

        public string? Title { get; set; }
    }
}
