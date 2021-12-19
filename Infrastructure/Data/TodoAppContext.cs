using Domain.Entities;
using Domain.Entities.TodoItem;
using Domain.Entities.TodoList;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TodoAppContext : DbContext
    {
        public TodoAppContext(DbContextOptions<TodoAppContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItemEntity> TodoItems { get; set; } = null!;
        public DbSet<TodoListEntity> TodoLists { get; set; } = null!;
    }
}
