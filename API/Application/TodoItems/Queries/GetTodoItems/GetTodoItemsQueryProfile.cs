using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.Queries.GetTodoItems
{
    public class GetTodoItemsQueryProfile : Profile
    {
        public GetTodoItemsQueryProfile() => CreateMap<TodoItem, GetTodoItemsQueryResponse>();
    }
}
