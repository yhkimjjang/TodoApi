using Newtonsoft.Json;

namespace TodoApi.Domains.Todo.Dto;

public class TodoDetialResponseDto : TodoResponseDto
{
    [JsonProperty("createDate")]
    public DateTime CreateDate {get; set;}
}