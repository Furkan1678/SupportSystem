using Newtonsoft.Json;
using System.Net;
using SupportRequestManagement.Infrastructure.Services;

namespace SupportRequestManagement.Presentation.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILoggingService loggingService) // ILoggingService’i parametre olarak ekledik
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                loggingService.LogError("Bir hata oluştu", ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            return context.Response.WriteAsync(result);
        }
    }
}
