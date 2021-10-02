using FlyWithUs.Hosted.Service.Tools.Security;
using Microsoft.AspNetCore.Identity;
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

        private readonly UserManager<IdentityUser> userManager;
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
                    var id = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
                    isAccess = true;
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
