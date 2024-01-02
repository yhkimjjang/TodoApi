using Newtonsoft.Json.Linq;

namespace TodoApi.Exceptions;

public partial class ToDoExceptionMessage
{
    public JObject MakeJObject()
    {
        return JObject.FromObject(this);
    }

    public override string ToString()
    {
        return $"{this.CreateDate} {this.Message} {this.StackTrace} " 
        + $"{this.RequestMethod} {this.RequestUrl} {this.RequestBoby} {this.ClientIp}";
    }
}