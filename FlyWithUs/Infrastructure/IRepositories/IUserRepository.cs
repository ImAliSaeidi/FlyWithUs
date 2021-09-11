﻿using FlyWithUs.Hosted.Service.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories
{
    public interface IUserRepository
    {
        int AddUser(User user);

        int UpdateUser(User user);

        int DeleteUser(int userid);

        User GetUserById(int userid);

        int Save();

        List<User> GetAllUser();
    }
}
