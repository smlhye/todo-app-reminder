using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Todo.Dtos;
using TodoApp.Domain.Common;

namespace TodoApp.Application.Todo.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, TodoItemDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateTodoItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TodoItemDto> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = new Domain.Entities.TodoItem(
                    title: request.Title,
                    description: request.Description,
                    reminderAt: request.ReminderAt,
                    userId: request.UserId
                );
            await _unitOfWork.TodoItemRepository.AddAsync(todoItem);
            return _mapper.Map<TodoItemDto>(todoItem);
        }
    }
}
