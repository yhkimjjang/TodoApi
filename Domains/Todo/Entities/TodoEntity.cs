using TodoApi.Domains.Category.Entities;
using TodoApi.Domains.UserInfo.Entities;

namespace TodoApi.Domains.Todo.Entities;
public partial class TodoEntity
{
    public TodoEntity()
    {

        TodoId = CreateId();
        IsComplate = false;
        CreateDate = DateTime.Now;
    }
    
    public long Seq {get; set;}

    public required string TodoId {get; set;}

    public required string Title {get; set;}

    public string? Content {get; set;}

    public DateTime? TragetEndDate {get; set;}

    public bool IsComplate {get; set;}

    public required string CreateUser {get; set;}

    public DateTime CreateDate {get; set;}

    public string? UpdateUser {get; set;}

    public DateTime? UpdateDate {get; set;}

    public required string UserId {get; set;}

    public required UserInfoEntity UserInfo {get; set;}

    public ICollection<CategoryTodoEntity>? CategoryTodos {get; set;}
}