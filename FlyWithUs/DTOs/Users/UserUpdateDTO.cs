using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class UserUpdateDTO : UserAddDTO
    {
        public int Id { get; set; }


        [StringLength(128, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        public new string Password { get; set; }



        [StringLength(128, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن یکسان نیست")]
        public new string RePassword { get; set; }

    }
}
