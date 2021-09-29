using FlyWithUs.Hosted.Service.Models.Users;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users
{
    public interface IRoleRepository
    {
        int Add(Role role);

        int Delete(int roleid);

        int Update(Role role);

        Role GetById(int roleid);

        IQueryable<Role> GetAll();

        int Save();

        bool IsExist(string name);
    }
}
