using FlyWithUs.Hosted.Service.Models.Users;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users
{
    public interface IUserRepository
    {
        int Add(User user);

        int Update(User user);

        int Delete(int userid);

        User GetById(int userid);

        int Save();

        IQueryable<User> GetAll();

        bool IsPhoneNumberExist(string phonenumber);

        bool IsEmailExist(string email);

        string GetNationality(int nationalityid);

    }
}
