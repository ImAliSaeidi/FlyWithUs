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


        public int Add(ApplicationUser user)
        {
            context.Users.Add(user);
            return Save();
        }

        public int Delete(string userid)
        {
            var user = GetById(userid);
            user.IsDeleted = true;
            return Update(user);
        }

        public int DeleteUserRoles(string userid)
        {
            var roles = context.UserRoles.Where(ur => ur.UserId == userid).ToList();
            foreach (var role in roles)
            {
                role.IsDeleted = true;
            }
            return Save();
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return context.Users.Include(u => u.ApplicationUserRoles).ThenInclude(u => u.Role);
        }

        public ApplicationUser GetById(string userid)
        {
            return context.Users.AsNoTracking().FirstOrDefault(u => u.Id == userid);
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            return context.Users.AsNoTracking().SingleOrDefault(u => u.Email == email);
        }

        public ApplicationUser GetUserByPhoneNumber(string phoennumber)
        {
            return context.Users.AsNoTracking().SingleOrDefault(u => u.PhoneNumber == phoennumber);
        }

        public bool IsEmailExist(string email)
        {
            return context.Users.Any(u => u.Email == email);
        }

        public bool IsPhoneNumberExist(string phonenumber)
        {
            return context.Users.Any(u => u.PhoneNumber == phonenumber);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int Update(ApplicationUser user)
        {
            context.Users.Update(user);
            return Save();
        }

    }
}
