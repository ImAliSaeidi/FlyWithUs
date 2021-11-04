using System.Linq;

namespace FlyWithUs.Hosted.Service.Tools.Security
{
    public class ValidateAdminToken
    {
        private readonly string role;
        public ValidateAdminToken(string role)
        {
            this.role = role;
        }
        public string GetUserId(string token)
        {
            string result = null;
            var claimsPrincipal = TokenGenerator.Validate(token);
            if (claimsPrincipal != null)
            {
                var roles = claimsPrincipal.Claims.Where(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
                foreach (var claim in roles)
                {
                    if (claim.Value == role)
                    {
                        result = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
                    }
                }
            }
            return result;
        }
    }
}
