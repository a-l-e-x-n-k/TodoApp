using Domain.Entities.TodoList;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfigurations;

public class TodoListEntityConfiguration : IEntityTypeConfiguration<TodoListEntity>
{
    public void Configure(EntityTypeBuilder<TodoListEntity> configuration)
    {
        configuration.ToTable("TodoList");

        configuration.Ignore(e => e.DomainEvents);

        configuration.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        configuration.HasMany(b => b.Items)
            .WithOne()
            .HasForeignKey("TodoListId")
            .OnDelete(DeleteBehavior.Cascade);

        var navigation = configuration.Metadata.FindNavigation(nameof(TodoListEntity.Items));

        navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}