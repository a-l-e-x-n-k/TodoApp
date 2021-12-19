using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Handlers.TodoLists.Queries.GetTodoList
{
    public class GetTodoListQuery : IRequest<ActionResult<TodoListDto>>
    {
        public int Id { get; set; }
    }
}
