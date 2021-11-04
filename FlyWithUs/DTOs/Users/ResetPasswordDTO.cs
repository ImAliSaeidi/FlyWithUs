using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class ResetPasswordDTO
    {
        [Required]
        public string ActiveCode { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredEmailError)]
        public string Email { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [Required(ErrorMessage = UserValidation.RequiredNewPasswordError)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z]|[A-Z]).{6,128}$", ErrorMessage = UserValidation.InvalidPasswordError)]
        public string NewPassword { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [Compare("NewPassword", ErrorMessage = UserValidation.PasswordCompareError)]
        [Required(ErrorMessage = UserValidation.RequiredReNewPasswordError)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z]|[A-Z]).{6,128}$", ErrorMessage = UserValidation.InvalidPasswordError)]
        public string ReNewPassword { get; set; }
    }
}
