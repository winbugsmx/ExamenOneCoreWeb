using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;

namespace ExamenOneCore.Web.Action_Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthenticatedAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            try
            {
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", returnUrl = filterContext.HttpContext.Request.Path }));
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Unauthorised", action = "Error", _errorMsg = ex.Message }));
            }
        }
    }
}