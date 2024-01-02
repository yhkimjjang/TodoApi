using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoApi.Domains.Todo.Dto;
using TodoApi.Domains.Todo.Entities;
using TodoApi.Domains.Todo.ValueObject;

namespace TodoApi.Domains.Todo.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDb _db;
    private readonly IMapper _mapper;

    public TodoRepository(TodoDb db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    /// <summary>
    /// Todo 삭제<br></br>
    /// ExecuteDeleteAsync()를 이용해서 query 처럼 조건식을 만족하는 모든 아이템 삭제함
    /// </summary>
    /// <param name="todo"></param>
    /// <returns></returns>
    public async Task DeleteTodoAsync(TodoDeleteRequestVo todo)
    {
        _ = await _db.Todos
        .Where(t => t.UserId == todo.UserId)
        .Where(t => t.TodoId == todo.TodoId)
        .ExecuteDeleteAsync();
    }

    /// <summary>
    /// Todo 추가
    /// </summary>
    /// <param name="todo"></param>
    /// <returns></returns>
    public async Task<TodoEntity> InsertTodoAsync(TodoEntity todo)
    {
        _db.Todos.Add(todo);
        await _db.SaveChangesAsync();
        return todo;
    }

    /// <summary>
    /// Todo 목록 조회
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<IReadOnlyList<TodoTitleDto>> SelectAllTodosAsync(string userId)
    {
        var query = _mapper.ProjectTo<TodoTitleDto>(
            _db.Todos
            .AsNoTracking()
            .Where(t => t.UserId == userId));

        return await query.ToListAsync();
    }

    /// <summary>
    /// Todo 상세 조회
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="todoId"></param>
    /// <returns></returns>
    public async Task<TodoDetialResponseDto?> SelectTodoByIdAsync(string userId, string todoId)
    {
        var query = _mapper.ProjectTo<TodoDetialResponseDto>(
            _db.Todos
            .AsNoTracking()
            .Where(t => t.UserId == userId)
            .Where(t => t.TodoId == todoId)
        );

        return await query.SingleOrDefaultAsync();
    }

    /// <summary>
    /// Todo 변경
    /// </summary>
    /// <param name="todo"></param>
    /// <returns></returns>
    public async Task UpdateTodoAsync(TodoEntity todo)
    {
        _db.Todos.Update(todo);
        await _db.SaveChangesAsync();
    }
}