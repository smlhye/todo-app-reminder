using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Todo.Dtos;

namespace TodoApp.Application.Todo.Queries
{
    public class GetAllByUserIdQuery : IRequest<List<TodoItemDto>>
    {
        public Guid UserId { get; set; } = default!;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
