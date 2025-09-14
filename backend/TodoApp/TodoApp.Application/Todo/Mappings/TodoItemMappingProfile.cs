using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Todo.Dtos;

namespace TodoApp.Application.Todo.Mappings
{
    public class TodoItemMappingProfile : Profile
    {
        public TodoItemMappingProfile()
        {
            CreateMap<Domain.Entities.TodoItem, TodoItemDto>();
        }
    }
}
