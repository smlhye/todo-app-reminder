using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Application.Todo.Queries
{
    public class GetAllByUserIdQueryValidator : AbstractValidator<GetAllByUserIdQuery>
    {
        public GetAllByUserIdQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User Id is required");
            RuleFor(x => x.PageNumber).GreaterThan(0).WithMessage("Page number is greater than 0");
            RuleFor(x => x.PageSize).InclusiveBetween(1, 100).WithMessage("Page size must be between 1 and 100");
        }
    }
}
