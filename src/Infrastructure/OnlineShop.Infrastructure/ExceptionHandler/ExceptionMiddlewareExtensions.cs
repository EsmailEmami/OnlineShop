using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OnlineShop.Common.Dtos;
using OnlineShop.Common.Exceptions;
using System.Net;
using ValidationException = FluentValidation.ValidationException;

namespace OnlineShop.Infrastructure.ExceptionHandler
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionHandlerFeature != null)
                    {
                        var exception = exceptionHandlerFeature.Error;

                        HttpStatusCode status;
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
                        else if (exceptionType == typeof(UnauthorizedException))
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
                        else if (exceptionType == typeof(ArgumentNullException))
                        {
                            status = HttpStatusCode.InternalServerError;
                        }
                        else if (exceptionType == typeof(ValidationException))
                        {
                            status = HttpStatusCode.BadRequest;
                        }
                        else
                        {
                            status = HttpStatusCode.InternalServerError;
                            message = "خطای سیستمی";
                        }

                        context.Response.StatusCode = (int)status;

                        string errorResponse = JsonConvert.SerializeObject(new Response(message));
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
                    }
                });
            });
        }

        private static string GetExceptionMessage(Exception exception)
        {
            return exception.Message +
                (exception.InnerException != null ? " " + exception.InnerException?.Message : string.Empty) +
                (exception.InnerException?.InnerException != null ? " " + exception.InnerException?.InnerException?.Message : "");
        }
    }
}
