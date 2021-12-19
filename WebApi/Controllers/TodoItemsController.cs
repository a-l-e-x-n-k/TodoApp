using MediatR;
using WebApi.Dto;
using Microsoft.AspNetCore.Mvc;
using WebApi.Handlers.TodoItems.Commands.CreateTodoItem;
using WebApi.Handlers.TodoItems.Commands.DeleteTodoItem;
using WebApi.Handlers.TodoItems.Commands.UpdateTodoItem;
using WebApi.Handlers.TodoItems.Commands.UpdateTodoItemDetails;
using WebApi.Handlers.TodoItems.Queries.GetTodoItem;
using WebApi.Handlers.TodoItems.Queries.GetTodoItems;

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
            // return await _context.TodoItems
            //     .Select(x => ItemToDTO(x))
            //     .ToListAsync();
            return await _requestSender.Send(new GetTodoItemsQuery(){ListId = listId});
        }


        // GET: api/todo/1/items/5
        [HttpGet("{itemId}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem(int listId, int itemId)
        {
            // var todoItem = await _context.TodoItems.FindAsync(itemId);
            //
            // if (todoItem == null)
            // {
            //     return NotFound();
            // }
            //
            // return ItemToDTO(todoItem);
            return await _requestSender.Send(new GetTodoItemQuery() { ListId = listId, ItemId = itemId});
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

            //
            // var todoItem = await _context.TodoItems.FindAsync(itemId);
            // if (todoItem == null)
            // {
            //     return NotFound();
            // }
            //
            // todoItem.Title = todoItemDto.Title;
            // todoItem.IsComplete = todoItemDto.IsComplete;
            //
            // try
            // {
            //     await _context.SaveChangesAsync();
            // }
            // catch (DbUpdateConcurrencyException) when (!TodoItemExists(itemId))
            // {
            //     return NotFound();
            // }
            //
            // return NoContent();
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

            // var todoItem = new TodoItem
            // {
            //     IsComplete = todoItemDTO.IsComplete,
            //     Title = todoItemDTO.Name
            // };
            //
            // _context.TodoItems.Add(todoItem);
            // await _context.SaveChangesAsync();
            //
            // return CreatedAtAction(
            //     nameof(GetTodoItem),
            //     new { id = todoItem.Id },
            //     ItemToDTO(todoItem));
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
            // var todoItem = await _context.TodoItems.FindAsync(itemId);
            //
            // if (todoItem == null)
            // {
            //     return NotFound();
            // }
            //
            // _context.TodoItems.Remove(todoItem);
            // await _context.SaveChangesAsync();
            //
            // return NoContent();
        }

        // private bool TodoItemExists(long id)
        // {
        //     return _context.TodoItems.Any(e => e.Id == id);
        // }
        //
        // private static TodoItemDto ItemToDTO(TodoItem todoItem) =>
        //     new TodoItemDto
        //     {
        //         Id = todoItem.Id,
        //         Name = todoItem.Title,
        //         IsComplete = todoItem.IsComplete
        //     };
    }
}
