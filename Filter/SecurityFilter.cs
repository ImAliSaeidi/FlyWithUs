using FlyWithUs.Hosted.Service.Infrastructure.Common;
using FlyWithUs.Hosted.Service.Tools.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;

namespace FlyWithUs.Hosted.Service.Filter
{
    public class SecurityFilter : ActionFilterAttribute
    {
        private readonly string role;
        public SecurityFilter(string role)
        {
            this.role = role;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool isAccess = false;
            base.OnActionExecuting(context);

            var authorization = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrWhiteSpace(authorization))
            {
                if (authorization.Contains("Bearer "))
                {
                    var token = authorization.Replace("Bearer ", "");
                    var claimsPrincipal = TokenGenerator.Validate(token);
                    if (claimsPrincipal != null)
                    {
                        var roles = claimsPrincipal.Claims.Where(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
                        foreach (var claim in roles)
                        {
                            if (claim.Value == role)
                            {
                                var userId = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
                                var userContext = (IUserContext)context.HttpContext.RequestServices.GetService(typeof(IUserContext));
                                userContext.UserId = userId;
                                isAccess = true;
                                return;
                            }
                        }
                    }
                }
            }
            if (isAccess == false)
            {
                UnAhutorize(context);
            }
        }

        private void UnAhutorize(ActionExecutingContext context)
        {
            var result = new JsonResult(new { Message = "دسترسی مجاز نیست" }) { StatusCode = (int)HttpStatusCode.Unauthorized, ContentType = "application/json" };
            context.Result = result;
        }
    }
}
