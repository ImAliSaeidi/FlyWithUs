using Microsoft.AspNetCore.Identity;

namespace FlyWithUs.Hosted.Service.Models.Users
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationUser User { get; set; }

        public ApplicationRole Role { get; set; }

        public bool IsDeleted { get; set; }
    }
}
