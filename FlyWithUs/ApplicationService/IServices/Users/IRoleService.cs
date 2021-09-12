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
        bool IsRoleExistForUpdate(RoleUpdateDTO dto);
        bool IsRoleExistForAdd(string  name);
        bool DeleteRole(int roleid);
        bool UpdateRole(RoleUpdateDTO dto);
        RoleDTO GetRoleById(int roleid);
        RoleUpdateDTO GetRoleForUpdate(int roleid);

    }
}
