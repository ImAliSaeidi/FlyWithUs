using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Roles;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Users
{
    public interface IRoleService
    {
        GridResultDTO<RoleDTO> GetAllRole(int skip,int take);

        bool AddRole(RoleAddDTO dto);

        bool IsRoleExist(string name, int? roleid);

        bool DeleteRole(int roleid);

        bool UpdateRole(RoleUpdateDTO dto);

        RoleUpdateDTO GetRoleForUpdate(int roleid);

    }
}
