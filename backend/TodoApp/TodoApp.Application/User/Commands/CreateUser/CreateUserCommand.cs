using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.User.Dtos;

namespace TodoApp.Application.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string Fullname { get; init; } = default!;
    }
}
