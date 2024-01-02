using TodoApi.Domains.Common;
using TodoApi.Exceptions;

namespace TodoApi.Middlewares
{
    public class ExcpetionHandleMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExcpetionHandleMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("TodoApi");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(ex, httpContext);
            }
        }

        private async Task HandleException(Exception ex, HttpContext httpContext)
        {
            var errorMessage = new ToDoExceptionMessage();

            if(ex is ToDoException)
            {
                var todoException = ex as ToDoException;
                errorMessage.CreateDate = DateTime.Now;
                errorMessage.Message = todoException?.InnerException?.Message;
                errorMessage.StackTrace = todoException?.InnerException?.StackTrace;
                errorMessage.RequestMethod = httpContext.Request.Method;
                errorMessage.RequestUrl = httpContext.Request.Path;
                errorMessage.RequestBoby = todoException?.Boby;
            }
            else
            {
                errorMessage.CreateDate = DateTime.Now;
                errorMessage.Message = ex?.Message;
                errorMessage.StackTrace = ex?.StackTrace;
                errorMessage.RequestMethod = httpContext.Request.Method;
                errorMessage.RequestUrl = httpContext.Request.Path;
            }

            _logger.LogError(errorMessage.ToString());

            httpContext.Response.StatusCode = 500;
            var message = new ResponseMessageBuilder<string>()
                .AddCode(System.Net.HttpStatusCode.InternalServerError)
                .AddError("Internal Server Error")
                .Build();
            await httpContext.Response.WriteAsJsonAsync(message);
        }
    }

    public static class ExcpetionHandleMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExcpetionHandleMiddleware>();
        }
    }
}