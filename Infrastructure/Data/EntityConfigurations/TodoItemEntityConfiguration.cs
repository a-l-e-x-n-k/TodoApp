using Domain.Entities.TodoItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfigurations
{
    public class TodoItemEntityConfiguration : IEntityTypeConfiguration<TodoItemEntity>
    {
        public void Configure(EntityTypeBuilder<TodoItemEntity> builder)
        {
            builder.ToTable("TodoItem");

            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();
            
            builder.Property(t => t.Note)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
