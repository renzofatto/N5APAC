using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].ToString();

            if (string.IsNullOrWhiteSpace(authorizationHeader) || !authorizationHeader.Equals("un token", StringComparison.OrdinalIgnoreCase))
            {
                context.Result = new ContentResult
                {
                    Content = "No puedo autorizarme",
                    StatusCode = 401,
                    ContentType = "text/plain"
                };
            }
        }

    }
}
