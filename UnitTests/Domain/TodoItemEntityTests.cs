using System;
using System.Linq;
using Domain.Entities.Common;
using Domain.Entities.TodoItem;
using Domain.Entities.TodoItem.Events;
using Xunit;

namespace UnitTests.Domain
{
    public class TodoItemEntityTests
    {
        private readonly Random _rnd = new Random();

        [Fact]
        public void NewDraft_WithTitle_CreatesTransientTodoItemWithDefaultValuesAndFilledTitle()
        {
            //Arrange
            //Act
            var result = TodoItemEntity.NewDraft("test");

            //Assert
            Assert.NotNull(result);
            Assert.Equal("test", result.Title);
            Assert.False(result.IsCompleted);
            Assert.Null(result.Note);
            Assert.Equal(0, result.Order);
            Assert.True(result.IsTransient());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NewDraft_WithEmptyTitle_ThrowsArgumentException(string title)
        {
            //Arrange
            //Act
            //Assert
            var exception = Assert.Throws<ArgumentException>(() => TodoItemEntity.NewDraft(title));

            Assert.NotNull(exception);
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MarkAsCompleted_WhenStateIsChanged_IsCompletedFieldIsUpdatedAndEventIsRaised(bool isCompleted)
        {
            //Arrange
            var result = TodoItemEntity.NewDraft("test");
            result.MarkAsCompleted(!isCompleted);
            (result.DomainEvents as DomainEvents)?.ClearDomainEvents();

            //Act
            result.MarkAsCompleted(isCompleted);

            //Assert
            Assert.Equal(isCompleted, result.IsCompleted);
            Assert.Single(result.DomainEvents.OfType<TodoItemStateChangedEvent>());
        }
        
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MarkAsCompleted_WhenStateIsNotChanged_IsCompletedFieldIsNotUpdatedAndEventIsNotRaised(bool isCompleted)
        {
            //Arrange
            var result = TodoItemEntity.NewDraft("test");
            result.MarkAsCompleted(isCompleted);
            (result.DomainEvents as DomainEvents)?.ClearDomainEvents();

            //Act
            result.MarkAsCompleted(isCompleted);

            //Assert
            Assert.Equal(isCompleted, result.IsCompleted);
            Assert.Empty(result.DomainEvents.OfType<TodoItemStateChangedEvent>());
        }


        [Fact]
        public void UpdateNoted_WithValue_NoteIsUpdated()
        {
            //Arrange
            var result = TodoItemEntity.NewDraft("test");
            var note = Guid.NewGuid().ToString();

            //Act
            result.UpdateNote(note);

            //Assert
            Assert.Equal(note, result.Note);
        }
        
        [Fact]
        public void UpdateOrder_WithPositiveValue_OrderIsUpdated()
        {
            //Arrange
            var result = TodoItemEntity.NewDraft("test");
            var order = _rnd.Next(0, 999);

            //Act
            result.UpdateOrder(order);

            //Assert
            Assert.Equal(order, result.Order);
        }

        [Fact]
        public void UpdateOrder_WithNegativeValue_ThrowsArgumentException()
        {
            //Arrange
            var result = TodoItemEntity.NewDraft("test");
            var order = _rnd.Next(1, 999);

            //Act
            var exception = Assert.Throws<ArgumentException>(() => result.UpdateOrder(-order));

            //Assert
            Assert.NotNull(exception);
        }
    }
}