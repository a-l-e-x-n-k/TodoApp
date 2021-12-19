using Domain;
using Domain.Entities;

namespace Application.UseCases.TodoLists.GetTodoList;

public class GetTodoListsUseCase : IGetTodoListsUseCase
{
    public GetTodoListsUseCase(ITodoListsRepository repository)
    {
        
    }

	public IReadOnlyCollection<TodoList> Execute()
	{
		throw new NotImplementedException();
	}
}