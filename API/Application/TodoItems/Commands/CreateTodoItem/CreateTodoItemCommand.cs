using AutoMapper;
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
        private readonly IMapper _mapper;

        public CreateTodoItemCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var newTodoItem = _mapper.Map<TodoItem>(request);

            _context.TodoItems.Add(newTodoItem);

            await _context.SaveChangesAsync(cancellationToken);
                
            return Unit.Value;
        }
    }
}
