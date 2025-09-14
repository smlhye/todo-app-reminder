using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Events;

namespace TodoApp.Application.Todo.Events.Handlers
{
    public class TodoItemCreatedEventHandler : INotificationHandler<DomainEventNotification<TodoItemCreatedEvent>>
    {
        private readonly ILogger<TodoItemCreatedEventHandler> _logger;
        public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger) { _logger = logger; }


        public Task Handle(DomainEventNotification<TodoItemCreatedEvent> notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"📌 TodoItem created with ID: {notification.DomainEvent.TodoItemId}, Title: {notification.DomainEvent.Title}");
            return Task.CompletedTask;
        }
    }
}
