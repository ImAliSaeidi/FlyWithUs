using FlyWithUs.Hosted.Service.Models.Users;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users
{
    public interface IUserRepository
    {
        int Add(ApplicationUser user);

        int Update(ApplicationUser user);

        int Delete(string userId);

        ApplicationUser GetById(string userId);

        int Save();

        IQueryable<ApplicationUser> GetAll();

        bool IsPhoneNumberExist(string phoneNumber);

        bool IsEmailExist(string email);

        int DeleteUserRoles(string userId);

        ApplicationUser GetUserByEmail(string email);

        ApplicationUser GetUserByPhoneNumber(string phoneNumber);

    }
}
