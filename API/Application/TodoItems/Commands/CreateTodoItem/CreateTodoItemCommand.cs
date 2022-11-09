using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand:IRequest
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }

    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand>
    {
        private readonly ApplicationDbContext _context;

        public CreateTodoItemCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItem
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
            };

            _context.TodoItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
