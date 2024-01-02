using TodoApi.Domains.Todo.Entities;

namespace TodoApi.Domains.Category.Entities;

public class CategoryTodoEntity
{
    public long Seq {get; set;}

    public required string CategoryId {get; set;}

    public required CategoryEntity Category {get; set;}

    public required string TodoId {get; set;}

    public required TodoEntity Todo {get; set;}
}