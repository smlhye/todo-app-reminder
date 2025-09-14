using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Todo.Dtos;
using TodoApp.Domain.Common;

namespace TodoApp.Application.Todo.Queries
{
    public class GetAllByUserIdQueryHandler : IRequestHandler<GetAllByUserIdQuery, List<TodoItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<TodoItemDto>> Handle(GetAllByUserIdQuery request, CancellationToken cancellationToken)
        {
            var todoItems = await _unitOfWork.TodoItemRepository.GetAllByUserIdAsync(request.UserId);
            var todoItemDtos = todoItems.Select(_mapper.Map<TodoItemDto>).ToList();
            return todoItemDtos;
        }
    }
}
