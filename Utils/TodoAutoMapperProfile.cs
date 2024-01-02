using AutoMapper;
using TodoApi.Domains.Todo.Dto;
using TodoApi.Domains.Todo.Entities;

namespace TodoApi.Utils;

public class TodoAutoMapperProfile : Profile
{
    public TodoAutoMapperProfile()
    {
        CreateMap<TodoCreateRequest, TodoEntity>();
        CreateMap<TodoEntity, TodoResponseDto>();
        CreateMap<TodoEntity, TodoTitleDto>();
        CreateMap<TodoEntity, TodoDetialResponseDto>();
    }
}