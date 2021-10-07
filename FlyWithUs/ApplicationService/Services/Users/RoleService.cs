using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Roles;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users;
using FlyWithUs.Hosted.Service.Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Users
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository repository;
        private readonly IMapper mapper;

        public RoleService(IRoleRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        public bool AddRole(RoleAddDTO dto)
        {
            bool result = false;
            dto.Name = dto.Name.ToLower().Trim();
            int count = repository.Add(mapper.Map<Role>(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public GridResultDTO<RoleDTO> GetAllRole(int skip, int take)
        {
            var dtos = mapper.Map<List<RoleDTO>>(repository.GetAll().Skip(skip).Take(take).ToList());
            var count = repository.GetAll().Count();
            return new GridResultDTO<RoleDTO>(count, dtos);
        }

        public bool IsRoleExist(string name)
        {
            return repository.IsExist(name);
        }

        public bool IsRoleExist(string name, int roleid)
        {
            bool result = false;
            var role = repository.GetById(roleid);
            if (repository.IsExist(name) == true && role.Name != name)
            {
                result = true;
            }
            return result;
        }

        public bool DeleteRole(int roleid)
        {
            bool result = false;
            int count = repository.Delete(roleid);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public RoleUpdateDTO GetRoleForUpdate(int roleid)
        {
            return mapper.Map<RoleUpdateDTO>(repository.GetById(roleid));
        }

        public bool UpdateRole(RoleUpdateDTO dto)
        {
            bool result = false;
            dto.Name = dto.Name.ToLower().Trim();
            int count = repository.Update(mapper.Map<Role>(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

    }
}
