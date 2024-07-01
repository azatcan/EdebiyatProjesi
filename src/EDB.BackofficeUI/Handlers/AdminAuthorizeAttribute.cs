using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EDB.BackofficeUI.Handlers
{
    public class AdminAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userRoles = context.HttpContext.Session.GetString("UserRoles");
            if (string.IsNullOrEmpty(userRoles) || !userRoles.Contains("Admin"))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
