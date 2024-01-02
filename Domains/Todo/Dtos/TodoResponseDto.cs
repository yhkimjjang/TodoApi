namespace TodoApi.Domains.Todo.Dto;

public class TodoResponseDto
{
    public required string TodoId {get; set;}
    public required string Title {get; set;}
    public required string Content {get; set;}
    public DateTime? TragetEndDate {get; set;}
    public bool IsComplate {get; set;}
}