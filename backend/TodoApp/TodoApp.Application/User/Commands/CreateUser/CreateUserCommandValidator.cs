using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Application.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Fullname)
                .NotEmpty().WithMessage("Fullname is required")
                .MaximumLength(100).WithMessage("Fullname must not exceed 100 characters.");
        }
    }
}
