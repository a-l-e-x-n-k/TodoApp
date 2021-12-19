using Domain.Entities.TodoList;

namespace Application.UseCases.TodoList.GetTodoList;

public interface IGetTodoListsUseCase : IUseCase
{
    Task<IReadOnlyCollection<TodoListEntity>> Execute();
}