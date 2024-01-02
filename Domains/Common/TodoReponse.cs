using TodoApi.Codes;

namespace TodoApi.Domains.Common;

public class TodoResponse
{
    public static IResult SendResponse<T>(ResponseMessage<T> message)
    {
        switch(message.Code) {
            case ResultEnum.RequestParameterError : 
            case ResultEnum.ValidationError:
                return TypedResults.BadRequest(message);
            case ResultEnum.NoContnet: 
                return TypedResults.NoContent();
            default: 
                return Results.Ok(message);
        }
    }
}