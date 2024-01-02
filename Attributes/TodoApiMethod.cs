namespace TodoApi.Attributes;

public abstract class TodApiMethod : Attribute
{
    public abstract HttpMethodEnum HttpMethod {get;}
    public abstract string Url {get;}
}