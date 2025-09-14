using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Common;

namespace TodoApp.Application.Todo.Events
{
    public interface IDomainEventNotification<out TDomainEvent> : INotification where TDomainEvent : IDomainEvent
    {
        TDomainEvent DomainEvent { get; }
    }
}
