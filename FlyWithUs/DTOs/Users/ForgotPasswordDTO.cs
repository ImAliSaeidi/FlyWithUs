using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class ForgotPasswordDTO
    {
        public string FullNamePersian { get; set; }


        public string ActiveCode { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredEmailError)]
        public string Email { get; set; }
    }
}
