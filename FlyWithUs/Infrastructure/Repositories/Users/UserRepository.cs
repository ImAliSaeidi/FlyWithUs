using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users;
using FlyWithUs.Hosted.Service.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly FlyWithUsContext context;

        public UserRepository(FlyWithUsContext context)
        {
            this.context = context;
        }


        public int Add(User user)
        {
            context.User.Add(user);
            return Save();
        }

        public int Delete(int userid)
        {
            var user = GetById(userid);
            user.IsDeleted = true;
            return Update(user);
        }

        public IQueryable<User> GetAll()
        {
            return context.User;
        }

        public User GetById(int userid)
        {
            return context.User.AsNoTracking().First(u => u.Id == userid);
        }

        public string GetNationality(int nationalityid)
        {
            return context.Countries.Find(nationalityid).PersianName;
        }

        public bool IsEmailExist(string email)
        {
            return context.User.Any(u => u.Email == email);
        }

        public bool IsPhoneNumberExist(string phonenumber)
        {
            return context.User.Any(u => u.PhoneNumber == phonenumber);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int Update(User user)
        {
            context.User.Update(user);
            return Save();
        }

    }
}
