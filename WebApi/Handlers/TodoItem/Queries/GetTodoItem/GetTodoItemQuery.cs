using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Handlers.TodoItem.Queries.GetTodoItem
{
    public class GetTodoItemQuery : IRequest<ActionResult<TodoItemDto>>
    {
        public int ListId { get; set; }
        public int ItemId { get; set; }
    }
}
