using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Handlers.TodoList.Queries.GetTodoLists
{
    public class GetTodoListsQuery : IRequest<ActionResult<List<TodoListBriefDto>>>
    {
    }
}
