using Domain.Security.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Shared.Filters;

public class CustomAuthorizeAttribute :Attribute,IAsyncAuthorizationFilter
{
    private readonly string[] _roles;

    public CustomAuthorizeAttribute(params string[] roles)
    {
        _roles = roles;
    }
    
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
       var user = context.HttpContext.Items["User"] as User; //User1 role mkt

       if (user == null || !_roles.Contains(user.Role))
       {
           context.Result = new ForbidResult();
       }
    }
}