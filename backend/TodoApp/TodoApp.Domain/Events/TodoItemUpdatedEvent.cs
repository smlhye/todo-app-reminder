using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Common;

namespace TodoApp.Domain.Events
{
    public class TodoItemUpdatedEvent : IDomainEvent
    {
        public Guid TodoItemId { get; }
        public string Title { get; } = default!;
        public DateTime OccurredOn { get; }
        public TodoItemUpdatedEvent(Guid todoItemId, string title)
        {
            TodoItemId = todoItemId;
            Title = title;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
