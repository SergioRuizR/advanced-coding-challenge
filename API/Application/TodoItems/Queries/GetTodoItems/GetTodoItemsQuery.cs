using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.Queries.GetTodoItems
{
    public class GetTodoItemsQuery : IRequest<List<GetTodoItemsQueryResponse>>
    {
    }

    public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, List<GetTodoItemsQueryResponse>>
    {
        private readonly ApplicationDbContext _context;

        public GetTodoItemsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<GetTodoItemsQueryResponse>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken) =>
            _context.TodoItems
                .AsNoTracking()
                .Select(s => new GetTodoItemsQueryResponse
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description
                })
                .ToListAsync();
    }
}
