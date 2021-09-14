using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.DTOs.Roles;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.Users;
using FlyWithUs.Hosted.Service.Models.Users;
using FlyWithUs.Hosted.Service.Tools.Convertors;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Users
{
    public class RoleService : IRoleService
    {
        private readonly RoleRepository repository;
        public RoleService()
        {
            repository = new RoleRepository();
        }

        #region Add Role
        public bool AddRole(RoleAddDTO dto)
        {
            bool result = false;
            int count = repository.AddRole(Map(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        private Role Map(RoleAddDTO dto)
        {
            return new Role
            {
                Name = dto.Name.ToLower().Trim()
            };
        }
        #endregion


        #region Get Role
        public List<RoleDTO> GetAllRole()
        {
            List<RoleDTO> dtos = new List<RoleDTO>();
            List<Role> roles = repository.GetAllRole();
            foreach (var item in roles)
            {
                dtos.Add(Map(item));
            }
            return dtos;
        }

        private RoleDTO Map(Role role)
        {
            return new RoleDTO
            {
                Id = role.Id,
                Name = role.Name,
                CreateDate = role.CreateDate.ToShamsi()
            };
        }
        #endregion


        #region Validation
        public bool IsRoleExist(string name, int? roleid)
        {
            if (roleid != null)
            {
                bool result = false;
                var role = repository.GetRoleById(roleid.Value);
                if (repository.IsRoleExist(name) == true && role.Name != name)
                {
                    result = true;
                }
                return result;
            }
            else
            {
                return repository.IsRoleExist(name);
            }
        }
        #endregion


        #region Delete Role
        public bool DeleteRole(int roleid)
        {
            bool result = false;
            int count = repository.DeleteRole(roleid);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }
        #endregion


        #region Update Role
        public RoleUpdateDTO GetRoleForUpdate(int roleid)
        {
            Role role = repository.GetRoleById(roleid);
            return new RoleUpdateDTO
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public bool UpdateRole(RoleUpdateDTO dto)
        {
            bool result = false;
            int count = repository.UpdateRole(Map(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        private Role Map(RoleUpdateDTO dto)
        {
            Role role = repository.GetRoleById(dto.Id);
            role.Name = dto.Name;
            return role;
        }
        #endregion
    }
}
