using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Models.Users
{
    public class UserRole : BaseEntity
    {
        [Required]
        public int UserId { get; set; }


        [Required]
        public int RoleId { get; set; }


        public User User { get; set; }

        public Role Role { get; set; }

    }
}
