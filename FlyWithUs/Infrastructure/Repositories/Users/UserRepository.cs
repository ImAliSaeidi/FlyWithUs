﻿using FlyWithUs.Hosted.Service.Infrastructure.Context;
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

        public IQueryable<ApplicationUser> GetAll()
        {
            return context.Users;
        }

        public ApplicationUser GetById(string userid)
        {
            return context.Users.AsNoTracking().First(u => u.Id == userid);
        }

        public string GetNationality(int nationalityid)
        {
            return context.Countries.Find(nationalityid).PersianName;
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
