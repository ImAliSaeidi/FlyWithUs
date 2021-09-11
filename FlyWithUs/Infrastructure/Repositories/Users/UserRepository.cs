using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users;
using FlyWithUs.Hosted.Service.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly FlyWithUsContext context;
        public UserRepository()
        {
            context = new FlyWithUsContext();
        }

        public int AddUser(User user)
        {
            context.User.Add(user);
            return Save();
        }

        public int DeleteUser(int userid)
        {
            var user = GetUserById(userid);
            user.IsDeleted = true;
            return UpdateUser(user);
        }

        public List<User> GetAllUser()
        {
            return context.User.ToList();
        }

        public User GetUserById(int userid)
        {
            return context.User.Find(userid);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int UpdateUser(User user)
        {
            context.User.Update(user);
            return Save();
        }
    }
}
