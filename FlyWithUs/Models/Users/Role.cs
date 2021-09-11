using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Models.Users
{
    public class Role : BaseEntity
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }


        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

    }
}
