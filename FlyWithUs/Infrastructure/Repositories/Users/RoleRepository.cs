using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users;
using FlyWithUs.Hosted.Service.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.Users
{
    public class RoleRepository : IRoleRepository
    {
        private readonly FlyWithUsContext context;

        public RoleRepository(FlyWithUsContext context)
        {
            this.context = context;
        }

        public int AddRole(Role role)
        {
            context.Role.Add(role);
            return Save();
        }

        public int DeleteRole(int roleid)
        {
            var role = GetRoleById(roleid);
            role.IsDeleted = true;
            return UpdateRole(role);
        }

        public List<Role> GetAllRole()
        {
            return context.Role.ToList();
        }

        public Role GetRoleById(int roleid)
        {
            return context.Role.Find(roleid);
        }

        public bool IsRoleExist(string name)
        {
            return context.Role.Any(r => r.Name == name);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int UpdateRole(Role role)
        {
            context.Role.Update(role);
            return Save();
        }
    }
}
