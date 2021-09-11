using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Models.Users
{
    public class Role : BaseEntity
    {
        #region Properties
        public string Name { get; set; }
        #endregion


        #region Relations
        public ICollection<UserRole> UserRoles { get; set; }

        #endregion
    }
}
