using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Handlers.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommand : IRequest<ActionResult<int>>
    {
        public string? Title { get; set; }
    }
}
