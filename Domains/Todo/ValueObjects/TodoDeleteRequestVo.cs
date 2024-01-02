namespace TodoApi.Domains.Todo.ValueObject;

public partial class TodoDeleteRequestVo
{
    public string? TodoId {get; set;}
    public string? UserId {get; set;}
}