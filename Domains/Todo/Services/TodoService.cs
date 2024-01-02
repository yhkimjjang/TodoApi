using AutoMapper;
using TodoApi.Codes;
using TodoApi.Domains.Common;
using TodoApi.Domains.Todo.Dto;
using TodoApi.Domains.Todo.Entities;
using TodoApi.Domains.Todo.Repositories;
using TodoApi.Domains.Todo.ValueObject;
using TodoApi.Exceptions;

namespace TodoApi.Domains.Todo.Services;

public class TodoService : ITodoService
{
    private readonly IMapper _mapper;
    private readonly ITodoRepository _todoRepository;

    public TodoService(IMapper mapper, ITodoRepository todoRepository)
    {
        _mapper = mapper;
        _todoRepository = todoRepository;
    }

    /// <summary>
    /// Todo 생성
    /// </summary>
    /// <param name="todo"></param>
    /// <returns></returns>
    public async Task<ResponseMessage<TodoResponseDto>> CreateTodoAsync(TodoCreateRequest todo)
    {
        try
        {
            TodoEntity entity = _mapper.Map<TodoEntity>(todo);
            string validateMessage = entity.ValidateTodo();
            if (validateMessage != string.Empty)
            {
                return new ResponseMessageBuilder<TodoResponseDto>()
                    .AddCode(ResultEnum.ValidationError)
                    .AddError(validateMessage)
                    .Build();
            }

            await _todoRepository.InsertTodoAsync(entity);
            var response = _mapper.Map<TodoResponseDto>(entity);
            return new ResponseMessageBuilder<TodoResponseDto>()
                    .AddData(response)
                    .Build();
        }
        catch (Exception ex)
        {
            throw new ToDoException("Server Error", ex, todo);
        }
    }

    /// <summary>
    /// Todo 목록 조회
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<ResponseMessage<TodoTitleDto>> GetAllTodosAsync(string userId)
    {
        try
        {
            var todoTitleDtos = await _todoRepository.SelectAllTodosAsync(userId);
            var resultStatus = todoTitleDtos.Any() ? ResultEnum.Success : ResultEnum.NoContnet;
            return new ResponseMessageBuilder<TodoTitleDto>()
                .AddCode(resultStatus)
                .AddDatas(todoTitleDtos)
                .Build();
        }
        catch (Exception ex)
        {
            throw new ToDoException("Server Error", ex, userId);
        }

    }

    /// <summary>
    /// Tod 상세 정보
    /// </summary>
    /// <param name="todo"></param>
    /// <returns></returns>
    public async Task<ResponseMessage<TodoDetialResponseDto>> GetToDetailAsync(TodoDetailRqeustVo todo)
    {
        try
        {
            string validateResult = todo.ValidateRequest();
            if (validateResult != string.Empty)
            {
                return new ResponseMessageBuilder<TodoDetialResponseDto>()
                    .AddCode(ResultEnum.ValidationError)
                    .AddError(validateResult)
                    .Build();
            }

            var todoResult = await _todoRepository.SelectTodoByIdAsync(todo.UserId!, todo.TodoId!);
            if (todoResult == null)
            {
                return new ResponseMessageBuilder<TodoDetialResponseDto>()
                    .AddCode(ResultEnum.RequestParameterError)
                    .AddError("잘못된 정보")
                    .Build();
            }

            return new ResponseMessageBuilder<TodoDetialResponseDto>()
                    .AddData(todoResult)
                    .Build();
        }
        catch (Exception ex)
        {
            throw new ToDoException("Server Error", ex, todo);
        }

    }

    /// <summary>
    /// Todo 삭제
    /// </summary>
    /// <param name="todo"></param>
    /// <returns></returns>
    /// <exception cref="ToDoException"></exception>
    public async Task<ResponseMessage<bool>> RemoveTodoAsync(TodoDeleteRequestVo todo)
    {
        try
        {
            var vaildeResult = todo.VaildeRequest();
            if (vaildeResult != string.Empty)
            {
                return new ResponseMessageBuilder<bool>()
                    .AddCode(ResultEnum.ValidationError)
                    .AddError(vaildeResult)
                    .Build();
            }

            await _todoRepository.DeleteTodoAsync(todo);
            return new ResponseMessageBuilder<bool>().Build();
        }
        catch (Exception ex)
        {
            throw new ToDoException("Server Error", ex, todo);
        }

    }

    /// <summary>
    /// Todo 업데이트
    /// </summary>
    /// <param name="todo"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ResponseMessage<TodoResponseDto>> UpdateTodoAsync(TodoCreateRequest todo)
    {
        try
        {
            TodoEntity entity = _mapper.Map<TodoEntity>(todo);
            await _todoRepository.UpdateTodoAsync(entity);

            TodoResponseDto resultDto = _mapper.Map<TodoResponseDto>(entity);
            return new ResponseMessageBuilder<TodoResponseDto>()
                .AddData(resultDto)
                .Build();
        }
        catch(Exception ex)
        {
            throw new ToDoException("Server Error", ex, todo);
        }
        

    }
}