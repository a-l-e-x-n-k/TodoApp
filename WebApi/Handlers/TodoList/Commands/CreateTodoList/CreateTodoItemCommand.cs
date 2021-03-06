using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Handlers.TodoList.Commands.CreateTodoList
{
    public class CreateTodoListCommand : IRequest<ActionResult<int>>
    {
        public string? Title { get; set; }
    }
}
