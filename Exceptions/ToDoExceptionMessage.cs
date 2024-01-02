using Newtonsoft.Json;

namespace TodoApi.Exceptions;

public partial class ToDoExceptionMessage
{
    [JsonProperty("createDate")]
    public DateTime CreateDate {get; set;}
    [JsonProperty("message")]
    public string? Message {get; set;}
    [JsonProperty("stackTrace")]
    public string? StackTrace {get; set;}
    [JsonProperty("requestUrl")]
    public string? RequestUrl {get; set;}
    [JsonProperty("requestMethod")]
    public string? RequestMethod {get; set;}
    [JsonProperty("requestBody")]
    public string? RequestBoby {get; set;}
    [JsonProperty("clientIp")]
    public string? ClientIp {get; set;}
}
