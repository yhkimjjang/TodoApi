using Newtonsoft.Json;

namespace TodoApi.Domains.Todo.ValueObject;

public partial class TodoDetailRqeustVo
{
    [JsonProperty("todoId")]
    public string? TodoId {get; set;}

    [JsonProperty("userId")]
    public string? UserId {get; set;}
}