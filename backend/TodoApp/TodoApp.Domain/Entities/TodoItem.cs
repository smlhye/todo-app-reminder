using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Common;
using TodoApp.Domain.Events;
using TodoApp.Domain.ValueObjects;

namespace TodoApp.Domain.Entities
{
    public class TodoItem : AggregateRoot<Guid>
    {
        public Title Title { get; private set; } = default!;
        public string? Description { get; private set; }
        public DateTime? ReminderAt { get; private set; }
        public bool IsCompleted { get; private set; } = false;
        public Guid UserId { get; private set; }
        private TodoItem() { }
        public TodoItem(Title title, string? description, DateTime? reminderAt, Guid userId)
        {
            Id = Guid.NewGuid();
            Title = title ?? throw new ArgumentNullException(nameof(title), "Title is required");
            Description = description;
            ReminderAt = reminderAt;
            IsCompleted = false;
            UserId = userId;
            SetCreated(userId.ToString());
            AddDomainEvent(new TodoItemCreatedEvent(Id, Title));
        }
        public void Update(Title title, string? description, DateTime? reminderAt)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title), "Title is required");
            Description = description;
            ReminderAt = reminderAt;
            SetUpdated(UserId.ToString());
            AddDomainEvent(new TodoItemUpdatedEvent(Id, Title));
        }
        public void MarkCompleted()
        {
            IsCompleted = true;
            SetUpdated(UserId.ToString());
            AddDomainEvent(new TodoItemCompletedEvent(Id, Title));
        }
    }
}
