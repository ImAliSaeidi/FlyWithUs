﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class UserUpdateDTO : UserAddDTO
    {
        public int Id { get; set; }

    }
}
