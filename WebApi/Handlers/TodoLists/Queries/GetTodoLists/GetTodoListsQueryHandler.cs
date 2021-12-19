using Application.UseCases.TodoLists.GetTodoList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Handlers.TodoLists.Queries.GetTodoLists;

public class GetTodoListsQueryHandler : IRequestHandler<GetTodoListsQuery, ActionResult<List<TodoListBriefDto>>>
{
    private readonly IGetTodoListsUseCase _useCase;

    public GetTodoListsQueryHandler(IGetTodoListsUseCase useCase)
    {
        _useCase = useCase;
    }

    public async Task<ActionResult<List<TodoListBriefDto>>> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
    {
        var result = _useCase.Execute();
    }
}