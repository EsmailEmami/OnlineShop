using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OnlineShop.Application.Core.Services.UserService;
using OnlineShop.Application.Security.Permissions;
using OnlineShop.Common.Dtos;
using OnlineShop.Common.Extensions;
using System.Security.Claims;

namespace OnlineShop.Application.Security.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class PermissionAttribute : Attribute, IAuthorizationFilter
    {
        public string Permission { get; }
        public PermissionAttribute(string permission)
        {
            Permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity is { IsAuthenticated: true })
            {
                // Retrieve the authorization service from the DI container
                IUserService userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();

                long userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!.Parse<long>() ?? 0;

                if (userService == null)
                {
                    context.Result = new ObjectResult(new Response("خطای سیستمی"))
                    {
                        StatusCode = StatusCodes.Status500InternalServerError
                    };
                }

                IList<string> permissions = userService.GetUserPeymissions(userId);

                if (!permissions.Any(v => v == Permission))
                {
                    string des = "امکان ";
                    var pers = AssignableToRolePermissions.GetPermision();
                    if (pers.Where(q => q.Name == Permission).Any())
                    {
                        des += pers.Where(q => q.Name == Permission).FirstOrDefault()?.Description + " وجود ندارد!";
                    }
                    else
                    {
                        var parentNumber = Permission.ToString().Substring(0, Permission.ToString().IndexOf("-"));
                        var parent = pers.Where(q => q.Name == parentNumber).FirstOrDefault();
                        des += parent?.ChildPermissions.Where(q => q.Name == Permission).FirstOrDefault()?.Description + " وجود ندارد!";
                    }

                    context.Result = new ObjectResult(JsonConvert.SerializeObject(new Response(des)))
                    {
                        StatusCode = StatusCodes.Status403Forbidden
                    };
                }
            }
            else
            {
                context.Result = new ObjectResult(JsonConvert.SerializeObject(new Response("شما به این بخش دسترسی ندارید!")))
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }

    }
}
