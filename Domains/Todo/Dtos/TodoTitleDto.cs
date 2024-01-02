using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace TodoApi.Domains.Todo.Entities;

public class TodoTitleDto
{
    [JsonProperty("todoId")]
    public required string TodoId {get; set;}
    [JsonProperty("title")]
    public required string Title {get; set;}
    [JsonProperty("isComplate")]
    public bool IsComplate {get; set;}
    [JsonProperty("createDate")]
    public DateTime CreateDate {get; set;}
}