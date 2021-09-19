using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Roles
{
    public class RoleUpdateDTO : RoleAddDTO
    {
        public int Id { get; set; }

    }
}
