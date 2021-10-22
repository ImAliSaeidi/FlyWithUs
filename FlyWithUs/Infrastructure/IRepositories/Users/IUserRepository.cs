using FlyWithUs.Hosted.Service.Models.Users;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users
{
    public interface IUserRepository
    {
        int Add(ApplicationUser user);

        int Update(ApplicationUser user);

        int Delete(string userid);

        ApplicationUser GetById(string userid);

        int Save();

        IQueryable<ApplicationUser> GetAll();

        bool IsPhoneNumberExist(string phonenumber);

        bool IsEmailExist(string email);

        int DeleteUserRoles(string userid);

        ApplicationUser GetUserByEmail(string email);

        ApplicationUser GetUserByPhoneNumber(string phoennumber);

    }
}
