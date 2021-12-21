using MediatR;
using WebApi.Dto;
using Microsoft.AspNetCore.Mvc;
using WebApi.Handlers.TodoItem.Commands.CreateTodoItem;
using WebApi.Handlers.TodoItem.Commands.DeleteTodoItem;
using WebApi.Handlers.TodoItem.Commands.UpdateTodoItem;
using WebApi.Handlers.TodoItem.Commands.UpdateTodoItemDetails;
using WebApi.Handlers.TodoItem.Queries.GetTodoItem;
using WebApi.Handlers.TodoItem.Queries.GetTodoItems;

namespace WebApi.Controllers
{
    [Route("api/todo/lists/{listId}/items")]
    public class TodoItemsController : ApiControllerBase
    {
        private readonly ISender _requestSender;

        public TodoItemsController(ISender requestSender)
        {
            _requestSender = requestSender;
        }

        // GET: api/todo/1/items
        [HttpGet()]
        public async Task<ActionResult<List<TodoItemBriefDto>>> GetTodoItems(int listId)
        {
            return await _requestSender.Send(new GetTodoItemsQuery() { ListId = listId });
        }


        // GET: api/todo/1/items/5
        [HttpGet("{itemId}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem(int listId, int itemId)
        {
            return await _requestSender.Send(new GetTodoItemQuery() { ListId = listId, ItemId = itemId });
        }

        // PUT: api/todo/1/items/5
        [HttpPut("{itemId}")]
        public async Task<IActionResult> UpdateTodoItem(int listId, int itemId, UpdateTodoItemModel updateModel)
        {
            return await _requestSender.Send(new UpdateTodoItemCommand()
            {
                ListId = listId,
                ItemId = itemId,
                Title = updateModel.Title,
                IsCompleted = updateModel.IsCompleted,
                Order = updateModel.Order
            });
        }

        [HttpPut("{itemId}/details")]
        public async Task<IActionResult> UpdateTodoItemDetails(int listId, int itemId, UpdateTodoItemDetailsModel updateModel)
        {
            return await _requestSender.Send(new UpdateTodoItemDetailsCommand()
            {
                ListId = listId,
                ItemId = itemId,
                Note = updateModel.Note
            });
        }

        // POST: api/todo/1/items
        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> CreateTodoItem(int listId, CreateTodoItemModel createItemModel)
        {
            return await _requestSender.Send(new CreateTodoItemCommand()
            {
                ListId = listId,
                Order = createItemModel.Order,
                Title = createItemModel.Title
            });
        }

        // DELETE: api/todo/1/items/5
        [HttpDelete("{itemId}")]
        public async Task<IActionResult> DeleteTodoItem(int listId, int itemId)
        {
            return await _requestSender.Send(new DeleteTodoItemCommand()
            {
                ListId = listId,
                ItemId = itemId
            });
        }
    }
}
