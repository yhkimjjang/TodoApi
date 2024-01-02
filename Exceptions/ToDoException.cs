using Newtonsoft.Json;

namespace TodoApi.Exceptions;

public class ToDoException : Exception
{
    public string? Boby {get; set;}

    public ToDoException(string message, Exception inner) : base(message, inner) {}

    public ToDoException(string message, Exception inner, object? body = null) : base(message, inner) 
    {
        if(body != null)
        {
            if(body is string) Boby = body as string;
            else JsonConvert.SerializeObject(body);
        }
    }
}
