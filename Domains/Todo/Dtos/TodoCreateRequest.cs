using Newtonsoft.Json;

namespace TodoApi.Domains.Todo.Dto;

public class TodoCreateRequest
{
    [JsonProperty("title")]
    public required string Title {get; set;}

    [JsonProperty("content")]
    public required string Content {get; set;}

    [JsonProperty("targetEndDate")]
    public DateTime? TragetEndDate {get; set;}

    [JsonProperty("createUser")]
    public required string CreateUser {get; set;}

    [JsonProperty("userId")]
    public required string UserId {get; set;}
}