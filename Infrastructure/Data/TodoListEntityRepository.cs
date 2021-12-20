using Domain;

namespace Infrastructure.Data
{
	public class TodoListEntityRepository : ITodoListEntityRepository
	{
        private readonly TodoAppContext _context;

        public TodoListEntityRepository(TodoAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
	}
}
