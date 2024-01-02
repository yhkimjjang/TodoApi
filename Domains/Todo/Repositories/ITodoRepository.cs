using TodoApi.Domains.Todo.Dto;
using TodoApi.Domains.Todo.Entities;
using TodoApi.Domains.Todo.ValueObject;

namespace TodoApi.Domains.Todo.Repositories;

public interface ITodoRepository
{
    /// <summary>
    /// 사용자 전체 Todo 목록 조회
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public Task<IReadOnlyList<TodoTitleDto>> SelectAllTodosAsync(string userId);

    /// <summary>
    /// Todo 추가
    /// </summary>
    /// <param name="todo"></param>
    /// <returns></returns>
    public Task<TodoEntity> InsertTodoAsync(TodoEntity todo);

    /// <summary>
    /// Todo 상세 내역 조회
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="todoId"></param>
    /// <returns></returns>
    public Task<TodoDetialResponseDto?> SelectTodoByIdAsync(string userId, string todoId);

    /// <summary>
    /// Todo 업데이트
    /// </summary>
    /// <param name="todo"></param>
    /// <returns></returns>
    public Task UpdateTodoAsync(TodoEntity todo);

    /// <summary>
    /// Todo 삭제
    /// </summary>
    /// <param name="todo"></param>
    /// <returns></returns>
    public Task DeleteTodoAsync(TodoDeleteRequestVo todo);
}