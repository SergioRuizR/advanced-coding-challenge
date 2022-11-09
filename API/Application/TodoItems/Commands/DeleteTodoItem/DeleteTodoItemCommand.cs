using Application.Common.Attributes;
using Domain.Exceptions;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.Commands.DeleteTodoItem
{
    [AuditLog]
    public class DeleteTodoItemCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
    {
        private readonly ApplicationDbContext _context;

        public DeleteTodoItemCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _context.TodoItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

            if (todoItem == null)
            {
                throw new Domain.Exceptions.NotFoundException(nameof(todoItem), request.Id);
            }

            _context.TodoItems.Remove(todoItem);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
