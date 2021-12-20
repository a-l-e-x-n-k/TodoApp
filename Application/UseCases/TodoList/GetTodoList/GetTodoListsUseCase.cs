using Domain;
using Domain.Entities.TodoList;

namespace Application.UseCases.TodoList.GetTodoList;

public class GetTodoListsUseCase : IGetTodoListsUseCase
{
    private readonly ITodoListsRepository _repository;

    public GetTodoListsUseCase(ITodoListsRepository repository)
    {
        _repository = repository;
    }

	public async Task<IReadOnlyCollection<TodoListEntity>> Execute()
	{
        throw new NotImplementedException();
	}
}