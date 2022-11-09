using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _mapper;


        public GetTodoItemsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<GetTodoItemsQueryResponse>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken) =>
            _context.TodoItems
                .AsNoTracking()
                .ProjectTo<GetTodoItemsQueryResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
    }
}
