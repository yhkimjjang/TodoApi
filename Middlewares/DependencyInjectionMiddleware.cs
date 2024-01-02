using Microsoft.EntityFrameworkCore;
using TodoApi.Domains.Todo.Controllers;
using TodoApi.Domains.Todo.Repositories;
using TodoApi.Domains.Todo.Services;
using TodoApi.Domains.UserInfo;
using TodoApi.Domains.UserInfo.Repositories;
using TodoApi.Domains.UserInfo.Services;
using TodoApi.Utils;

namespace TodoApi.Middlewares;

public static class DependencyInjectionMiddleware
{
    /// <summary>
    /// Dependency Injection 정의
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static WebApplicationBuilder SetupDependencyInjection(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("todoDB"));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddScoped<UserInfoRepository>();
        builder.Services.AddScoped<SignUpService>();
        builder.Services.AddScoped<UserInfoService>();
        builder.Services.AddScoped<ITodoRepository, TodoRepository>();
        builder.Services.AddScoped<ITodoService, TodoService>();
        builder.Services.AddAutoMapper(typeof(TodoAutoMapperProfile));
        builder.Services.AddScoped<TodoController>();

        return builder;
    }
}