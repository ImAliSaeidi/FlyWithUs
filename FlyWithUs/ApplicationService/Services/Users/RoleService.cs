using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.DTOs.Roles;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.Users;
using FlyWithUs.Hosted.Service.Models.Users;
using FlyWithUs.Hosted.Service.Tools.Convertors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Users
{
    public class RoleService : IRoleService
    {
        private readonly RoleRepository repository;
        public RoleService()
        {
            repository = new RoleRepository();
        }

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
                Name = dto.Name
            };
        }
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

        public bool IsRoleExist(string name)
        {
            return repository.IsRoleExist(name.Trim().Replace(" ", ""));
        }

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
    }
}
