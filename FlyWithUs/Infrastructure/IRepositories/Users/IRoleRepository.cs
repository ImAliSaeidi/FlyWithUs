using FlyWithUs.Hosted.Service.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users
{
    public interface IRoleRepository
    {
        int AddRole(Role role);

        int DeleteRole(int roleid);

        int UpdateRole(Role role);

        Role GetRoleById(int roleid);

        List<Role> GetAllRole();

        int Save();
    }
}
