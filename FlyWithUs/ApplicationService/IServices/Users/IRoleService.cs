using FlyWithUs.Hosted.Service.DTOs.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Users
{
   public interface IRoleService
    {
        List<RoleDTO> GetAllRole();
        bool AddRole(RoleAddDTO dto);
        bool IsRoleExist(string name);
        bool DeleteRole(int roleid);

    }
}
