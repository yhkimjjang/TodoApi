using System.Reflection;
using TodoApi.Attributes;
using TodoApi.Codes;

namespace TodoApi.Middlewares;

public static class TodoEndpoints
{
    public static void MappingTodoApiController(WebApplication app)
    {
        Assembly? todoApi = null;
        AppDomain currentDoman = AppDomain.CurrentDomain;
        foreach(Assembly asm in currentDoman.GetAssemblies())
        {
             string? asmName = asm.GetName().Name;
            if("TodoApi".Equals(asmName))
                todoApi = asm;
        }

        var controllerClasses = todoApi!.GetModules()
            .SelectMany(x => x.GetTypes())
            .Where(x => x.IsClass)
            .Where(x => x.GetCustomAttribute<TodoApiControllerAttribute>() != null);

        foreach(var controllerClass in controllerClasses)
        {
            var apiMethods = controllerClass.GetMethods()
                .Where(x => x.GetCustomAttributes(typeof(TodApiMethod), true).Any());

            foreach(var apiMethod in apiMethods)
            {
                var todoAttribute = apiMethod.GetCustomAttribute<TodApiMethod>();
                var reqDelegate = RequestDelegateFactory.Create(apiMethod,
                context => context.RequestServices.GetRequiredService(controllerClass)).RequestDelegate;

                switch(todoAttribute!.HttpMethod)
                {
                    case HttpMethodEnum.GET:  
                        app.MapGet(todoAttribute.Url, reqDelegate);
                        break;
                    case HttpMethodEnum.POST:
                        app.MapPost(todoAttribute.Url, reqDelegate);
                        break;
                    case HttpMethodEnum.DLETE:
                        app.MapDelete(todoAttribute.Url, reqDelegate);
                        break;
                    case HttpMethodEnum.PUT:
                        app.MapPut(todoAttribute.Url, reqDelegate);
                        break;
                    default: break;
                }
            }
        }
    }
}