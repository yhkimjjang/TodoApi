namespace TodoApi.Attributes;

public class TodoApiDeleteAttribute : TodApiMethod
{
    private readonly HttpMethodEnum _httpMethod = HttpMethodEnum.POST;
    private readonly string _url;

    public override HttpMethodEnum HttpMethod 
    {
        get
        {
            return _httpMethod;
        }
    }

    public override string Url 
    {
        get
        {
            return _url;
        }
    }

    public TodoApiDeleteAttribute(string url)
    {
        _url = url;
    }
}