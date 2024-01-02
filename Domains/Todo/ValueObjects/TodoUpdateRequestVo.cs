namespace TodoApi.Domains.Todo.ValueObject;

public partial class TodoUpdateRequestVo
{
    public required string UserId {get; set;}

    public string? UpdateUser {get; set;}

    public DateTime? UpdateDate {get; set;}

    public bool IsComplate {get; set;}

    public required string TodoId {get; set;}

    public required string Title {get; set;}

    public string? Content {get; set;}

    public DateTime? TragetEndDate {get; set;}
}