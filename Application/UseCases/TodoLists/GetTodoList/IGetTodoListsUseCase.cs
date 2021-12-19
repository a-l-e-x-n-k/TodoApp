using Domain.Entities;

namespace Application.UseCases.TodoLists.GetTodoList;

public interface IGetTodoListsUseCase : IUseCase
{
    IReadOnlyCollection<TodoList> Execute();
}