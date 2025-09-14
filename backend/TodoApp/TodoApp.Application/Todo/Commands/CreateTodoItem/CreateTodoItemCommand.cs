using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Todo.Dtos;

namespace TodoApp.Application.Todo.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<TodoItemDto>
    {
        public string Title { get; init; } = default!;
        public string? Description { get; init; }
        public DateTime? ReminderAt { get; init; }
        public Guid UserId { get; init; }
    }
}
