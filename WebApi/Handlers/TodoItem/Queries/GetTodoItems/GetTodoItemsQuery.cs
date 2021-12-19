using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Handlers.TodoItem.Queries.GetTodoItems
{
    public class GetTodoItemsQuery : IRequest<ActionResult<List<TodoItemBriefDto>>>
    {
        public int ListId { get; set; }
    }
}
