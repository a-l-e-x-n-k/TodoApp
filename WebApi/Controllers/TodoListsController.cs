using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Handlers.TodoLists.Commands.CreateTodoList;
using WebApi.Handlers.TodoLists.Commands.DeleteTodoList;
using WebApi.Handlers.TodoLists.Commands.UpdateTodoList;
using WebApi.Handlers.TodoLists.Queries.GetTodoList;
using WebApi.Handlers.TodoLists.Queries.GetTodoLists;

namespace WebApi.Controllers
{
    [Route("api/todo/lists")]
    public class TodoListsController : ApiControllerBase
    {
        private readonly ISender _requestSender;

        public TodoListsController(ISender requestSender)
        {
            _requestSender = requestSender;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoListBriefDto>>> GetAll()
        {
            return await _requestSender.Send(new GetTodoListsQuery());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoListDto>> Get(int id)
        {
            return await _requestSender.Send(new GetTodoListQuery(){Id = id});
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTodoListCommand command)
        {
            return await _requestSender.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTodoListModel model)
        {
            return await _requestSender.Send(new UpdateTodoListCommand(){Id = id, Title = model.Title});

            // return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await _requestSender.Send(new DeleteTodoListCommand { Id = id });

            // return NoContent();
        }
    }
}
