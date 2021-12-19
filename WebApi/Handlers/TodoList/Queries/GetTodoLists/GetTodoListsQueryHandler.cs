using Application.UseCases.TodoList.GetTodoList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Handlers.TodoList.Queries.GetTodoLists;

public class GetTodoListsQueryHandler : IRequestHandler<GetTodoListsQuery, ActionResult<List<TodoListBriefDto>>>
{
    private readonly IGetTodoListsUseCase _useCase;
    private readonly IMapper _mapper;

    public GetTodoListsQueryHandler(IGetTodoListsUseCase useCase, IMapper mapper)
    {
        _useCase = useCase;
        _mapper = mapper;
    }

    public async Task<ActionResult<List<TodoListBriefDto>>> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
    {
        var result = await _useCase.Execute();
        return _mapper.Map<List<TodoListBriefDto>>(result);
    }
}