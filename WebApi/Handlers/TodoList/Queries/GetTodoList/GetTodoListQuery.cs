using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Handlers.TodoList.Queries.GetTodoList
{
    public class GetTodoListQuery : IRequest<ActionResult<TodoListDto>>
    {
        public int Id { get; set; }
    }
}
