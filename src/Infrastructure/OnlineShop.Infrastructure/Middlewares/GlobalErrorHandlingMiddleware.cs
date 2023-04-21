using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OnlineShop.Common.Exceptions;
using System.Net;

namespace OnlineShop.Api.Infrastructure.Middleware
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            var stackTrace = exception.StackTrace;
            string message = GetExceptionMessage(exception);

            var exceptionType = exception.GetType();

            if (exceptionType == typeof(BadRequestException))
            {
                status = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(NotFoundException))
            {
                status = HttpStatusCode.NotFound;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                status = HttpStatusCode.NotImplemented;     
            }
            else if (exceptionType == typeof(UnauthorizedAccessException))
            {
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NotAccessException))
            {
                status = HttpStatusCode.Forbidden;
            }
            else if (exceptionType == typeof(DatabaseException))
            {
                status = HttpStatusCode.BadRequest;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
            }

            string exceptionResult = JsonConvert.SerializeObject(new { error = message, stackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(exceptionResult);
        }
        
        private static string GetExceptionMessage(Exception exception)
        {
            return string.Concat(exception.Message, " ", exception.InnerException?.Message, " ", exception.InnerException?.InnerException?.Message);
        }
    }
}
