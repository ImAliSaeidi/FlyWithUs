using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.Models.Users
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {

        }

        public ApplicationRole(string rolename) : base(rolename)
        {
            ApplicationUserRoles = new HashSet<ApplicationUserRole>();
        }

        public bool IsDeleted { get; set; }

        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
