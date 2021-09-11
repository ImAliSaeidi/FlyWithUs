using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Models.Users
{
    public class UserRole : BaseEntity
    {
        public User User { get; set; }

        public Role Role { get; set; }
    }
}
