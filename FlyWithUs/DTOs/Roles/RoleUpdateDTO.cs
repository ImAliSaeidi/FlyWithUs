using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Roles
{
    public class RoleUpdateDTO
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "لطفا نام نقش را وارد کنید")]
        [StringLength(128, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        public string Name { get; set; }
    }
}
