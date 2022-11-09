using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.Commands.CreateTodoItem
{
    internal class CreateTodoItemCommandProfile : Profile
    {
        public CreateTodoItemCommandProfile() => CreateMap<CreateTodoItemCommand, TodoItem>();
    }
}
