using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users;
using FlyWithUs.Hosted.Service.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.Users
{
    public class RoleRepository : IRoleRepository
    {
        private readonly FlyWithUsContext context;

        public RoleRepository(FlyWithUsContext context)
        {
            this.context = context;
        }

        public int Add(Role role)
        {
            context.Role.Add(role);
            return Save();
        }

        public int Delete(int roleid)
        {
            var role = GetById(roleid);
            role.IsDeleted = true;
            return Update(role);
        }

        public IQueryable<Role> GetAll()
        {
            return context.Role;
        }

        public Role GetById(int roleid)
        {
            return context.Role.AsNoTracking().First(r => r.Id == roleid);
        }

        public bool IsExist(string name)
        {
            return context.Role.Any(r => r.Name == name);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int Update(Role role)
        {
            context.Role.Update(role);
            return Save();
        }
    }
}
