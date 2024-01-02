using System.Reflection;
using TodoApi.Attributes;
using TodoApi.Domains.Todo.Controllers;

namespace TodoApi.Middlewares;

public class SampleReflection
{
    public void DisplayAllAssembly()
    {
        AppDomain currentDoman = AppDomain.CurrentDomain;
        Console.WriteLine($"Current Domain Name: {currentDoman.FriendlyName}");
        foreach(Assembly asm in currentDoman.GetAssemblies())
        {
            Console.WriteLine($" {asm.GetName().Name}");
        }
    }

    public void DisplayAllModuleByTodoApiAssembly()
    {
        Assembly? todoApi = null;
        AppDomain currentDoman = AppDomain.CurrentDomain;
        foreach(Assembly asm in currentDoman.GetAssemblies())
        {
             string? asmName = asm.GetName().Name;
            if("TodoApi".Equals(asmName))
                todoApi = asm;
        }

        foreach(var type in todoApi!.GetTypes())
        {
            Console.WriteLine(type.FullName);
        }
    }

    public void DislayController(WebApplication app)
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

        foreach(var conrollerClass in controllerClasses)
        {
            var apiMethods = conrollerClass.GetMethods()
                .Where(x => x.GetCustomAttributes(typeof(TodApiMethod), true).Any());

            foreach(var apiMethod in apiMethods)
            {
                var todoAttribute = apiMethod.GetCustomAttribute<TodApiMethod>();
                var reqDelegate = RequestDelegateFactory.Create(apiMethod,
                context => context.RequestServices.GetRequiredService(conrollerClass)).RequestDelegate;

                switch(todoAttribute!.HttpMethod)
                {
                    case HttpMethodEnum.GET:  
                        app.MapGet(todoAttribute.Url, reqDelegate);
                        break;
                    case HttpMethodEnum.POST:
                        app.MapPost(todoAttribute.Url, reqDelegate);
                        break;
                    default: break;
                }
            }
        }





        // .SelectMany(x => x.GetMethods())
        // .Where(x => x.GetCustomAttributes(typeof(TodoApiControllerAttribute), false).FirstOrDefault() != null);

        // foreach(var controller in controllers)
        // {
        //     var arrtibute = controller.GetCustomAttributes()
        //     .Where(x => x.GetType() == typeof(TodoApiControllerAttribute))
        //     .FirstOrDefault();

        //     var todoAttribute = arrtibute as TodoApiControllerAttribute;

        //     var reqDelegate = RequestDelegateFactory.Create
        //     (
        //         controller, 
        //         context => context.RequestServices.GetRequiredService<TodoController>()
        //     )
        //     .RequestDelegate;

        //     switch(todoAttribute!.HttpMethod)
        //     {
        //         case HttpMethodEnum.GET:  
        //             app.MapGet(todoAttribute.Url, reqDelegate);
        //             break;
        //         default: break;
        //     }
        // }

    }
}