using TodoApi.Domains.Common;
using TodoApi.Domains.Todo.Dto;
using TodoApi.Domains.Todo.Entities;
using TodoApi.Domains.Todo.ValueObject;

namespace TodoApi.Domains.Todo.Services;

public interface ITodoService
{
    /// <summary>
    /// 사용자 전체 Todo 목록 조회
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public Task<ResponseMessage<TodoTitleDto>> GetAllTodosAsync(string userId);

    /// <summary>
    /// Todo 상세 정보 조회
    /// </summary>
    /// <param name="todo"></param>
    /// <returns></returns>
    public Task<ResponseMessage<TodoDetialResponseDto>> GetToDetailAsync(TodoDetailRqeustVo todo);

    /// <summary>
    /// Todo 생셩
    /// </summary>
    /// <param name="todo"></param>
    /// <returns></returns>
    public Task<ResponseMessage<TodoResponseDto>> CreateTodoAsync(TodoCreateRequest todo);

    /// <summary>
    /// Todo 업데이트
    /// </summary>
    /// <param name="todo"></param>
    /// <returns></returns>
    public Task<ResponseMessage<TodoResponseDto>> UpdateTodoAsync(TodoCreateRequest todo);

    /// <summary>
    /// Todo 삭제
    /// </summary>
    /// <param name="todo"></param>
    /// <returns></returns>
    public Task<ResponseMessage<bool>> RemoveTodoAsync(TodoDeleteRequestVo todo);

}