using FluentValidation;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        private readonly ApplicationDbContext _context;
        public CreateTodoItemCommandValidator(ApplicationDbContext context)
        {
            _context = context;

            

            RuleFor(x => x.Id).NotNull().NotEmpty()
                .Must(id =>
                {
                     return !_context.TodoItems
                    .AsNoTracking().Where(x => x.Id == id).ToList().Any();
                })
                .WithErrorCode("AlreadyExists")
                .WithMessage($"The Todo Item already exists.");
            RuleFor(x => x.Title).NotNull().NotEmpty().MinimumLength(5).MaximumLength(20);
            RuleFor(x => x.Description).NotNull().NotEmpty().MinimumLength(10).MaximumLength(200);
        }
    }
}
