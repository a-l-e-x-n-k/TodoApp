using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Handlers.TodoLists.Queries.GetTodoLists
{
    public class GetTodoListsQuery : IRequest<ActionResult<List<TodoListBriefDto>>>
    {
    }
}
