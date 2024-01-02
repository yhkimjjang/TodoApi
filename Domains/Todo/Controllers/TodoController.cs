using Microsoft.AspNetCore.Mvc;
using TodoApi.Attributes;
using TodoApi.Domains.Common;
using TodoApi.Domains.Todo.Dto;
using TodoApi.Domains.Todo.Services;
using TodoApi.Exceptions;

namespace TodoApi.Domains.Todo.Controllers;

[TodoApiController]
public class TodoController
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    /// <summary>
    /// Todo 추가 API
    /// </summary>
    /// <param name="reqTodo"></param>
    /// <returns></returns>
    [TodoApiPost("/users/{userId}/todos")]
    public async Task<IResult> AddTodo(string userId, TodoCreateRequest reqTodo)
    {
        //TODO: 사용자 아이디를 이용해서 유용한 사용자인지 확인 필요
        var resp = await _todoService.CreateTodoAsync(reqTodo);
        return TodoResponse.SendResponse(resp);
    }
}