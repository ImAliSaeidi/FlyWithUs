﻿using FlyWithUs.Hosted.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices
{
    public interface IUserService
    {
        bool AddUser(UserAddDTO dto);

        List<UserDTO> GetAllUser();
    }
}